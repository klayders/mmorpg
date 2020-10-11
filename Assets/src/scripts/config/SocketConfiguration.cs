using System.Net;
using System.Net.Sockets;
using UnityEngine;

// [CreateAssetMenu(menuName = "Socket/Configuration", fileName = "SocketData")]
// public class SocketConfiguration : ScriptableObject
namespace src.scripts.config
{
    public class SocketConfiguration
    {
        private Socket socket;

        public SocketConfiguration()
        {
            Debug.Log("start init socket");
            var ipAddr = getIPAddress();
            var ipEndPoint = new IPEndPoint(ipAddr, Port);
            socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipEndPoint);
            Debug.Log("connected");
        }


        public Socket getSocket()
        {
            return socket;
        }

        public static string Host { get; set; } = "localhost";
        public static int Port { get; set; } = 6666;

        public bool isEnable()
        {
            bool part1 = socket.Poll(1000, SelectMode.SelectRead);
            bool part2 = (socket.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }


        private IPAddress getIPAddress()
        {
            var ipHost = Dns.GetHostEntry(Host);
            var ipAddr = ipHost.AddressList[0];
            return ipAddr;
        }
    }
}