using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GeminiChessServer
{
    class Server
    {
        TcpListener serverSocket;
        int requestCount;
        TcpClient clientSocket;
        NetworkStream networkStream;

        public Server()
        {
            IPAddress localAddr = IPAddress.Parse(GetLocalIPAddress());
            this.serverSocket = new TcpListener(localAddr, 8888);
            this.requestCount = 0;
            this.clientSocket = default(TcpClient);
        }

        public int getRequestCount()
        {
            return this.requestCount;
        }

        public void startServer()
        {
            serverSocket.Start();
        }
        public void acceptConnections()
        {
            clientSocket = serverSocket.AcceptTcpClient();
            this.requestCount++;
        }

        public void stopServer()
        {
            clientSocket.Close();
            serverSocket.Stop();
        }

        public string getResponseFromClient()
        {
            try
            {
                requestCount = requestCount + 1;
                networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                return dataFromClient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void sendResponseToClient(string response)
        {
            if (response != null)
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes(response+"$");
                networkStream = clientSocket.GetStream();
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public string GetIpAddress()
        {
            return GetLocalIPAddress();
        }
    }

}
