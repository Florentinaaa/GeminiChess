using System.Net.Sockets;


namespace GeminiChess
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream serverStream;

        public Client()
        {
            clientSocket = new TcpClient();
        }

        public TcpClient getClientSocket()
        {
            return clientSocket;
        }

        public void Connect(string ipAddress)
        {
            clientSocket.Connect(ipAddress, 8888);
        }

        public void sendResponseToServer(string response)
        {
            this.serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public string receiveResponseFromServer()
        {
            if (clientSocket.Connected)
            {
                byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
                serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);
                string dataFromServer= System.Text.Encoding.ASCII.GetString(inStream);
                dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                return dataFromServer;
            }
            else
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            clientSocket.Close();
        }
    }
}
