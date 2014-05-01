using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alta_Media_Manager.Class
{
    public class alta_client
    {
        
        // My Attributes
        private Socket m_sock;						// Server connection
        private byte[] m_byBuff = new byte[256];	// Recieved data buffer
        public String key = "";
        public String sRecieved = "";
        public bool isConnected;
        public bool autoConnect;
        public String ip;
        public alta_client()
        {
            isConnected = false;
            autoConnect = true;
        }

        public void sendData(String m_tbMessage)
        {
            if (m_sock == null || !m_sock.Connected)
            {
                MessageBox.Show("bạn phải kết nối trước khi gửi dữ liệu", "Thông báo");
                return;
            }

            // Read the message from the text box and send it
            try
            {
                // Convert to byte array and send.
                Byte[] byteDateLine = Encoding.ASCII.GetBytes(m_tbMessage);
                m_sock.Send(byteDateLine, byteDateLine.Length, 0);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, "Send Message Failed!");
#endif
            }
        }
        public void connect(String ip)
        {
           
            try
            {
                // Close the socket if it is still open
                if (m_sock != null && m_sock.Connected)
                {
                    m_sock.Shutdown(SocketShutdown.Both);
                    System.Threading.Thread.Sleep(10);
                    m_sock.Close();
                }

                // Create the socket object
                m_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint epServer = new IPEndPoint(IPAddress.Parse(ip), 399);
                m_sock.Blocking = false;
                AsyncCallback onconnect = new AsyncCallback(OnConnect);
                m_sock.BeginConnect(epServer, onconnect, m_sock);
            }
            catch (Exception ex)
            {
                isConnected = false;
#if DEBUG
                MessageBox.Show(ex.Message, "Server Connect failed!"+ip);
#endif
            }
            this.ip = ip;
        }
        public void OnConnect(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;
            // Check if we were sucessfull
            try
            {

                if (sock.Connected)
                {
                    isConnected = true;
                    SetupRecieveCallback(sock);
                }
                else
                {
#if DEBUG
                   MessageBox.Show("Unable to connect to remote machine", "Connect Failed!"+this.ip);
#endif
                    isConnected = false;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show( ex.Message, "Unusual error during Connect!");
#endif
                isConnected = false;
            }
        }
        public void SetupRecieveCallback(Socket sock)
        {
            try
            {
                AsyncCallback recieveData = new AsyncCallback(OnRecievedData);
                sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, sock);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show( ex.Message, "Setup Recieve Callback failed!");
#endif
            }
        }
        public void OnRecievedData(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;
            // Check if we got any data
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    // Wrote the data to the List
                    sRecieved = Encoding.ASCII.GetString(m_byBuff, 0, nBytesRec);
                    pareMsg(sRecieved);
                    SetupRecieveCallback(sock);
                }
                else
                {
                    // If no data was recieved then the connection is probably dead
                    Console.WriteLine("Client {0}, disconnected", sock.RemoteEndPoint);
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
                if (Disconnect != null)
                {
                    Disconnect(this, new EventArgs());
                }
#if DEBUG
                MessageBox.Show(ex.Message, "Unusual error druing Recieve!");
#endif
            }

        }
        private void pareMsg(string msRecieved)
        {
            String[] reMsg = msRecieved.Split('_');
            if (reMsg[0].ToUpper() == "NOONCE")
            {
                this.key = reMsg[1];
                if (NoOnceEvent != null)
                    NoOnceEvent(this, this.key);
            }
            else if (reMsg[0].ToUpper() == "OK")
            {
                if (OkEvent != null)
                    OkEvent(this, msRecieved);
            }
            else if (reMsg[0].ToUpper() == "FAIL")
            {
                if (FailEvent != null)
                    FailEvent(this, msRecieved);
            }
            else 
            {
                String[] pareMsg = msRecieved.Split('|');
                if (pareMsg[0].ToUpper() == "PLAY")
                {
                    if (MediaPlaying != null)
                    {
                        String[] mediaStr = pareMsg[1].Split('_');
                        mediaTCP media = new mediaTCP() { id =Convert.ToInt32(mediaStr[0]), File = mediaStr[1] };
                        MediaPlaying(this,media);
                    }
                }
                else if (pareMsg[0].ToUpper() == "OK")
                {
                    if (OkEvent != null)
                    {
                        OkEvent(this, msRecieved);
                    }
                }
                else if (pareMsg[0].ToUpper() == "FAIL")
                {
                    if (FailEvent != null)
                    {
                        FailEvent(this, msRecieved);
                    }
                }
                else
                {
                    if (MsgEvent != null)
                        MsgEvent(this, msRecieved);
                }
            }
        }
        public event EventHandler<mediaTCP> MediaPlaying;
        public event EventHandler<String> NoOnceEvent;
        public event EventHandler<String> MsgEvent;
        public event EventHandler<String> OkEvent;
        public event EventHandler<String> FailEvent;
        public event EventHandler Disconnect;
        ~alta_client()
        {
            if (m_sock != null && m_sock.Connected)
            {
                m_sock.Shutdown(SocketShutdown.Both);
                m_sock.Close();
            }
        }
    }
    public class mediaTCP
    {
       public int id { get; set; }
       public String File { get; set; }
    }
}
