using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Alta_Media_Manager.Class;

namespace Alta_Media_Manager.Alta_net
{
    class TCPListen
    {
        TcpListener UserTCP;
        TcpListener AdminTCP;
        TcpListener requestTCP;
        TcpClient client;

        public Thread UserReq;

        private Thread UserThread;
        /// <summary>
        /// 
        /// </summary>
        private Thread backgroundThread;
        /// <summary>
        /// 
        /// </summary>
        public int userControlFlag;
        /// <summary>
        /// 
        /// </summary>
        public int requestControl;
        /// <summary>
        /// Flag Control từ admin panel
        /// </summary>
        public int dataControl;
        /// <summary>
        /// Stream server 
        /// </summary>
        public string StreamSever;
        /// <summary>
        /// data nhận được từ phái server
        /// </summary>
        public string returnData;
        /// <summary>
        /// đường dẫn thư mục chơi nhạc từ phía admin control
        /// </summary>
        public string pathMedia;
        /// <summary>
        /// camera ID
        /// </summary>
        public int CameraID;
        /// <summary>
        /// chuỗi rtsp
        /// </summary>
        public string rtsp_camera;
        /// <summary>
        /// tên user connect
        /// </summary>
        public string user;
        /// <summary>
        /// mật khẩu kết nối
        /// </summary>
        public string pass;
        /// <summary>
        /// iP user connect
        /// </summary>
        public string IpUser;
        /// <summary>
        /// port user connect
        /// </summary>
        public int portUser;

        public IPEndPoint IpEndPointUser;
        Socket socket;

        ~TCPListen()
        {
            try
            {
                if (UserThread != null)
                    UserThread.Abort();
                backgroundThread.Abort();
                listenUserConnect.Abort();
            }
            catch (Exception)
            {
            }
            finally
            {

            }
        }
        public TCPListen()
        {
            CameraID = -1;
            dataControl = _controlVLC._CONTROL_FREE;
            requestControl = _controlVLC._CONTROL_FREE;
            userControlFlag = _controlVLC._CONTROL_FREE;
            pathMedia = "";
            AdminThreadStart();
            UserConnect();
        }

        #region Admin Control
        /// <summary>
        /// 
        /// </summary>
        private void AdminControl()
        {
            try
            {
                socket = AdminTCP.AcceptSocket();
                byte[] clientData = new byte[1024];
                int byteData = socket.Receive(clientData, clientData.Length, SocketFlags.None);
                returnData = System.Text.Encoding.ASCII.GetString(clientData, 0, byteData);
                if (returnData == "Play")
                    dataControl = _controlVLC._CONTROL_PLAY;
                else if (returnData == "Pause")
                    dataControl = _controlVLC._CONTROL_PAUSE;
                else if (returnData == "Stop")
                    dataControl = _controlVLC._CONTROL_STOP;
                else if (returnData == "Open")
                    dataControl = _controlVLC._CONTROL_WAIT;
                else if (dataControl == _controlVLC._CONTROL_WAIT && returnData != "")
                {
                    pathMedia = returnData;
                    dataControl = _controlVLC._CONTROL_OPEN;
                }
                else if (returnData != "" && dataControl == _controlVLC._CONTROL_FREE)
                {
                    StreamSever = returnData;
                    dataControl = _controlVLC._CONTROL_STREAM;
                }
                else if (dataControl != _controlVLC._CONTROL_WAIT)
                {

                }
                socket.Close();
            }
            catch (Exception)
            {
            }
        }
        public void stopAdminControl()
        {
            try
            {
                AdminTCP.Stop();
                if (backgroundThread != null && backgroundThread.ThreadState != ThreadState.Aborted)
                    backgroundThread.Abort();

            }
            catch (Exception)
            {
            }
        }

        private void AdminControlThread()
        {
            while (true)
            {
                AdminControl();
                Thread.Sleep(80);
            }
        }
        public void AdminThreadStart(string Ip = "127.0.0.1")
        {
            AdminTCP = new TcpListener(IPAddress.Parse(Ip), CommonUtilities.config.Outport_Stream);
            AdminTCP.Start();
            backgroundThread = new Thread(AdminControlThread);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        #endregion Admin Control


        //var stream = new NetworkStream(socketUser);
        //           var writer = new StreamWriter(stream);
        //           writer.AutoFlush = true;
        //           writer.WriteLine("Hello");
        //           stream.Close();
        #region Connect

        public void EndUserReq()
        {
            try
            {
                ReqStream.Close();
                client.Close();
                if (UserReq != null && UserReq.ThreadState != ThreadState.Aborted)
                    UserReq.Abort();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        public void ReceviceDataRequest()
        {
            while (true)
            {
                DataRequest();
                Thread.Sleep(100);
            }
        }
        public void StartRequest(IPEndPoint IP)
        {
            client = new TcpClient();
            client.Connect(IP.Address, CommonUtilities.config.OutPort_Cer);
            ReqStream = client.GetStream();
            UserReq = new Thread(ReceviceDataRequest);
            UserReq.IsBackground = true;
            UserReq.Start();
        }
        Stream ReqStream;
        public void ENDUSERCONECT()
        {
            UserConnect();
         //   MainWindow.flag_user_connected = false;
            EndUserControl();
            EndUserReq();
        }

        private void DataRequest()
        {
            try
            {
                var reader = new StreamReader(ReqStream);
                string str;
                sendRequestData("alow");
                str = reader.ReadLine();
                if (str.ToUpper() == "EXIT")
                {
                    ENDUSERCONECT();
                }
                else if (str.ToUpper() == "ENDCONNECT")
                {

                    ENDUSERCONECT();
                }
                else if (str != string.Empty)
                {

                }
            }
            catch (Exception ex)
            {

                UserConnect();
                MessageBox.Show(ex.Message);
                EndUserReq();

            }
        }
        public void sendRequestData(string data)
        {
            try
            {
                var writer = new StreamWriter(ReqStream);
                writer.AutoFlush = true;
                writer.WriteLine(data);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #endregion

        #region Request User

        public void StopConnect()
        {
            try
            {
                requestTCP.Stop();
                if (listenUserConnect != null && listenUserConnect.ThreadState != ThreadState.Aborted)
                    listenUserConnect.Abort();

            }
            catch (Exception)
            {
            }
        }
        public void listenConnectThread()
        {
            while (true)
            {
                listenConnect();
                Thread.Sleep(80);
            }
        }

        private void listenConnect()
        {
            if (requestControl != _controlVLC._CONTROL_Connect)
            {
                try
                {
                    socketRequest = requestTCP.AcceptSocket();
                    byte[] clientData = new byte[1024];
                    int byteData = socketRequest.Receive(clientData, clientData.Length, SocketFlags.None);
                    string returnData = System.Text.Encoding.ASCII.GetString(clientData, 0, byteData);
                    if (returnData.IndexOf("Connect_") >= 0)
                    {
                        IpEndPointUser = (IPEndPoint)socketRequest.RemoteEndPoint;
                        requestControl = _controlVLC._CONTROL_Connect;
                        string[] data = returnData.Split('_');
                        user = data[1];
                        pass = data[2];
                    }
                    if (requestControl != _controlVLC._CONTROL_Connect)
                        socketRequest.Close();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);
#endif
                }
            }

        }
        public void responseData(string data)
        {
            try
            {
                var stream = new NetworkStream(socketRequest);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.WriteLine(data);
                stream.Close();
                socketRequest.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            finally
            {
                requestControl = _controlVLC._CONTROL_FREE;
            }
        }
        public void UserConnect()
        {
            try
            {
                requestTCP = new TcpListener(IPAddress.Any,CommonUtilities.config.Request_Stream);
                requestTCP.Start();
                listenUserConnect = new Thread(listenConnectThread);
                listenUserConnect.IsBackground = true;
                listenUserConnect.Start();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        #endregion

        #region User Control
        public void EndUserControl()
        {
            UserTCP.Stop();
            if (UserThread != null && UserThread.ThreadState == ThreadState.Running)
                UserThread.Abort();
        }

        public void ListenUserControl(IPEndPoint IP)
        {
            try
            {
                IpUser = IP.Address.ToString();
                UserTCP = new TcpListener(IPAddress.Any, CommonUtilities.config.Outport_Stream);
                UserTCP.Start();
                UserThread = new Thread(userControlThread);
                UserThread.IsBackground = true;
                UserThread.Start();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void userControlThread()
        {
            while (true)
            {
                userControl();
                Thread.Sleep(80);
            }
        }
        public void userControl()
        {
            try
            {
                socketUser = UserTCP.AcceptSocket();
                IPEndPoint thisIp = (IPEndPoint)socketUser.RemoteEndPoint;
                if (IpUser == thisIp.Address.ToString())
                {
                    byte[] clientData = new byte[1024];
                    int byteData = socketUser.Receive(clientData, clientData.Length, SocketFlags.None);
                    string returnData = System.Text.Encoding.ASCII.GetString(clientData, 0, byteData);
                    if (returnData == "Play")
                        userControlFlag = _controlVLC._CONTROL_PLAY;
                    else if (returnData == "Pause")
                        userControlFlag = _controlVLC._CONTROL_PAUSE;
                    else if (returnData == "Stop")
                        userControlFlag = _controlVLC._CONTROL_STOP;
                    else if (returnData == "Back")
                        userControlFlag = _controlVLC._CONTROL_BACK;
                    else if (returnData == "Next")
                        userControlFlag = _controlVLC._CONTROL_NEXT;
                    else if (returnData == "connect")
                    {

                    }
                    else if (dataControl != _controlVLC._CONTROL_WAIT)
                    {

                    }
                }
                socketUser.Close();
            }
            catch (Exception)
            {
            }
        }
        #endregion
        public Thread listenUserConnect;
        private Socket socketUserReq;
        private Socket socketUser;
        public Socket socketRequest { get; set; }
    }
   
}
