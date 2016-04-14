using System;
using System.Linq;
using System.Text;
using System.Net.Sockets;

public class SocketTestClient : IDisposable
    {
        private string _ServerAddress;
        private int _ServerPort;
        private Socket _Socket;

        public SocketTestClient(string serverAddress, int port)
        {
            _ServerAddress = serverAddress;
            _ServerPort = port;
        }
        public SocketTestClient()
        {
            _ServerAddress = "59.175.180.218";
            _ServerPort = 8365;
         }

    public bool Connect()
        {
            DisConnect();

            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Socket.Connect(_ServerAddress, _ServerPort);
            return _Socket.Connected;
        }

        public void DisConnect()
        {
            if (_Socket != null && _Socket.Connected)
            {
                _Socket.Disconnect(false);
            }
        }

        public void Dispose()
        {
            if (_Socket != null && _Socket.Connected)
            {
                _Socket.Disconnect(false);
                _Socket.Dispose();
            }
        }

        public void SendMessage(string message)
        {
            _Socket.Send(Encoding.Default.GetBytes(message));
        }

        public string ReceiveMessage()
        {
            StringBuilder sb = new StringBuilder();
            byte[] buffer = new byte[102400];
            int count = _Socket.Receive(buffer, buffer.Length, 0);
            if (count > 0)
            {
                sb.Append(Encoding.Default.GetString(buffer.Take(count).ToArray()));
            }
            return sb.ToString();
        }


    }
