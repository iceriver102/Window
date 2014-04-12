using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alta_Media_Manager.Class;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Runtime.Serialization.Formatters.Binary;

namespace Alta_Media_Manager.Alta_net
{
    class alta_class_net
    {
        private ArrayList m_aryClients = new ArrayList();
        Socket listener;
        public int dataControl = _controlVLC._CONTROL_FREE;
        public int adminControl = _controlVLC._CONTROL_FREE;
        public String ipHostStream = "";
        public alta_class_net()
        {
            //int nPortListen = CommonUtilities.config.Outport_Stream;
            int nPortListen = 339;
            // Determine the IPAddress of this machine
            IPAddress[] aryLocalAddr = null;
            String strHostName = "";
           
            try
            {
                // NOTE: DNS lookups are nice and all but quite time consuming.
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
                aryLocalAddr = ipEntry.AddressList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to get local address {0} ", ex.Message);
            }

            // Verify we got an IP address. Tell the user if we did
            if (aryLocalAddr == null || aryLocalAddr.Length < 1)
            {
                Console.WriteLine("Unable to get local address");
                return;
            }
            Console.WriteLine("Listening on : [{0}] {1}:{2}", strHostName, aryLocalAddr[0], nPortListen);

            // Create the listener socket in this machines IP address
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(aryLocalAddr[0], 399));
            //listener.Bind( new IPEndPoint( IPAddress.Loopback, 399 ) );	// For use with localhost 127.0.0.1
            listener.Listen(10);

            // Setup a callback to be notified of connection requests
            listener.BeginAccept(new AsyncCallback(this.OnConnectRequest), listener);
        }
        ~alta_class_net()
        {
            listener.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Callback used when a client requests a connection. 
        /// Accpet the connection, adding it to our list and setup to 
        /// accept more connections.
        /// </summary>
        /// <param name="ar"></param>
        public void OnConnectRequest(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                NewConnection(listener.EndAccept(ar));
                listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        /// <summary>
        /// Add the given connection to our list of clients
        /// Note we have a new friend
        /// Send a welcome to the new client
        /// Setup a callback to recieve data
        /// </summary>
        /// <param name="sockClient">Connection to keep</param>
        //public void NewConnection( TcpListener listener )
        public void NewConnection(Socket sockClient)
        {
            // Program blocks on Accept() until a client connects.
            //SocketChatClient client = new SocketChatClient( listener.AcceptSocket() );
            SocketControlClient client = new SocketControlClient(sockClient);
            m_aryClients.Add(client);
            Console.WriteLine("Client {0}, joined", client.Sock.RemoteEndPoint);

            // Get current date and time.           
            String strDateLine ="NOONCE_"+ CommonUtilities.keySerect;

            // Convert to byte array and send.
            Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes(strDateLine.ToCharArray());
            client.Sock.Send(byteDateLine, byteDateLine.Length, 0);
            client.SetupRecieveCallback(this);
        }
        private byte[] getByteText(String input)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(input);
            return array;
        }

        /// <summary>
        /// Get the new data and send it out to all other connections. 
        /// Note: If not data was recieved the connection has probably 
        /// died.
        /// </summary>
        /// <param name="ar"></param>
        public void OnRecievedData(IAsyncResult ar)
        {
            SocketControlClient client = (SocketControlClient)ar.AsyncState;
            byte[] aryRet = client.GetRecievedData(ar);
            if (aryRet.Length < 1)
            {
                Console.WriteLine("Client {0}, disconnected", client.Sock.RemoteEndPoint);
                client.Sock.Close();
                m_aryClients.Remove(client);
                return;
            }
            String str = System.Text.Encoding.Default.GetString(aryRet);
            if (client.flag_can_Coltrol == false)
            {
                String[] dataStr = str.Split('_');
                if (dataStr.Length > 1 & dataStr[0].ToUpper() == "ADMIN")
                {
                    if (CommonUtilities.checkAdminColtrol(dataStr[1]))
                    {
                        client.flag_admin_Control = true;
                        client.flag_can_Coltrol = true;
                        client.Sock.Send(getByteText("OK|200|ADMIN"));
                        client.SetupRecieveCallback(this);
                    }
                    else
                    {
                        client.flag_can_Coltrol = false;
                        client.Sock.Send(getByteText("OK|205|ADMIN"));
                        client.Sock.Close();
                        m_aryClients.Remove(client);
                    }
                }
                else
                {
                    if (CommonUtilities.userColtrol.checkLoginNetWork(CommonUtilities.keySerect,str) && flag_login_user)
                    {
                        client.flag_admin_Control = false;
                        client.flag_can_Coltrol = true;
                        client.Sock.Send(getByteText("OK|200"));
                        client.SetupRecieveCallback(this);

                    }
                    else
                    {
                        client.flag_admin_Control = false;
                        client.flag_can_Coltrol = false;
                        client.Sock.Send(getByteText("FAIL|205"));
                        client.Sock.Close();
                        m_aryClients.Remove(client);
                    }

                }
            }
            else
            {
                if (client.flag_admin_Control)
                {
                    if (str.ToUpper() == "PLAY")
                    {
                        this.adminControl = _controlVLC._CONTROL_PLAY;
                    }
                    else if (str.ToUpper() == "PAUSE")
                    {
                        this.adminControl = _controlVLC._CONTROL_PAUSE;
                    }
                    else if (str.ToUpper() == "STOP")
                    {
                        this.adminControl = _controlVLC._CONTROL_STOP;
                    }
                    else if (str.ToUpper() == "NEXT")
                    {
                        this.adminControl = _controlVLC._CONTROL_NEXT;
                    }
                    else if (str.ToUpper() == "BACK")
                    {
                        this.adminControl = _controlVLC._CONTROL_BACK;
                    }
                    else if (str.ToUpper() == "STREAM")
                    {
                        this.adminControl = _controlVLC._CONTROL_STREAM;
                        this.ipHostStream = parseIP(client.Sock.RemoteEndPoint);
                    }
                    else if(str.ToUpper()=="ABORT")
                    {
                        this.adminControl = _controlVLC._CONTROL_ABORT_USER;
                    }
                    else if (str.ToUpper() == "ACCEPT")
                    {
                        this.adminControl = _controlVLC._CONTROL_ACCEPT_USER;
                    }
                    else if (str.ToUpper() == "SCREEN")
                    {
                        this.adminControl = _controlVLC._CONTROL_SCREEN;
                    }
                    else
                    {
                        this.adminControl = _controlVLC._CONTROL_FREE;
                    }
                }
                else
                {
                    if (str.ToUpper() == "PLAY")
                    {
                        this.dataControl = _controlVLC._CONTROL_PLAY;
                    }
                    else if (str.ToUpper() == "PAUSE")
                    {
                        this.dataControl = _controlVLC._CONTROL_PAUSE;
                    }
                    else if (str.ToUpper() == "STOP")
                    {
                        this.dataControl = _controlVLC._CONTROL_STOP;
                    }
                    else if (str.ToUpper() == "NEXT")
                    {
                        this.dataControl = _controlVLC._CONTROL_NEXT;
                    }
                    else if (str.ToUpper() == "BACK")
                    {
                        this.dataControl = _controlVLC._CONTROL_BACK;
                    }
                    else if (str.ToUpper() == "STREAM")
                    {
                        this.dataControl = _controlVLC._CONTROL_STREAM;
                        this.ipHostStream = parseIP(client.Sock.RemoteEndPoint);
                    }
                    else if (str.ToUpper() == "SCREEN"){
                        
                        this.dataControl = _controlVLC._CONTROL_SCREEN;
                    }
                    else if (str.ToUpper() == "STOPSTREAM")
                    {
                        this.dataControl = _controlVLC._CONTROL_STREAM_STOP;
                       
                    }
                    else
                    {
                        this.dataControl = _controlVLC._CONTROL_FREE;
                    }
                }
                client.Sock.Send(getByteText("OK|200|" + str.ToUpper()));
                client.SetupRecieveCallback(this);
            }
        }


        String parseIP(EndPoint ip)
        {
            String tmp = ip.ToString();
            string[] rIP = tmp.Split(':');
            return rIP[0];
        }

        public void abort_user()
        {
            foreach (SocketControlClient client in m_aryClients)
            {
                if (client.flag_can_Coltrol && client.flag_admin_Control != true)
                {
                    client.Sock.Close();
                    m_aryClients.Remove(client);
                    return;
                }
            }
        }

    
     

        public void sendImage(String file )
        {
            if (file != "")
            {
                foreach (SocketControlClient clientd in m_aryClients)
                {
                    if (clientd.flag_admin_Control || clientd.flag_can_Coltrol)
                    {
                        clientd.Sock.Send(getByteText(file));
                    }
                }
            }
        }
        

        public bool checkClient(EndPoint ip)
        {
            foreach (SocketControlClient client in this.m_aryClients)
            {
                if (client.Sock.RemoteEndPoint == ip)
                    return true;
            }
            return false;
        }

        public bool flag_login_user = true;
    }
    internal class SocketControlClient
    {
        public bool flag_can_Coltrol { get; set; }
        public bool flag_admin_Control { get; set; }
        private Socket m_sock;						// Connection to the client
        private byte[] m_byBuff = new byte[1024];		// Receive data buffer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sock">client socket conneciton this object represents</param>
        public SocketControlClient(Socket sock)
        {
            flag_can_Coltrol = false;
            m_sock = sock;
        }

       

        // Readonly access
        public Socket Sock
        {
            get { return m_sock; }
        }

        /// <summary>
        /// Setup the callback for recieved data and loss of conneciton
        /// </summary>
        /// <param name="app"></param>
        public void SetupRecieveCallback(alta_class_net app)
        {
            try
            {
                AsyncCallback recieveData = new AsyncCallback(app.OnRecievedData);
                m_sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Recieve callback setup failed! {0}", ex.Message);
            }
        }

        /// <summary>
        /// Data has been recieved so we shall put it in an array and
        /// return it.
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>Array of bytes containing the received data</returns>
        public byte[] GetRecievedData(IAsyncResult ar)
        {
            int nBytesRec = 0;
            try
            {
                nBytesRec = m_sock.EndReceive(ar);
            }
            catch { }
            byte[] byReturn = new byte[nBytesRec];
            Array.Copy(m_byBuff, byReturn, nBytesRec);

            /*
            // Check for any remaining data and display it
            // This will improve performance for large packets 
            // but adds nothing to readability and is not essential
            int nToBeRead = m_sock.Available;
            if( nToBeRead > 0 )
            {
                byte [] byData = new byte[nToBeRead];
                m_sock.Receive( byData );
                // Append byData to byReturn here
            }
            */
            return byReturn;
        }


    }
    public static class _controlVLC
    {
        public const int _CONTROL_PLAY = 1;
        public const int _CONTROL_PAUSE = 2;
        public const int _CONTROL_STOP = 3;
        public const int _CONTROL_FREE = -1;
        public const int _CONTROL_STREAM = 4;
        public const int _CONTROL_WAIT = 6;
        public const int _CONTROL_OPEN = 5;
        public const int _CONTROL_Camera = 7;
        public const int _CONTROL_Connect = 8;
        public const int _CONTROL_NEXT = 9;
        public const int _CONTROL_BACK = 10;
        public const int _CONTROL_ABORT_USER = 11;
        public const int _CONTROL_ACCEPT_USER = 12;
        public const int _CONTROL_SCREEN = 13;
        public const int _CONTROL_STREAM_STOP = 14;
    }
  
}
