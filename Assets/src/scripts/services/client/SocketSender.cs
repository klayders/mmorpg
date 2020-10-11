using System.Net.Sockets;
using System.Text;
using src.scripts.config;
using UnityEngine;
using Zenject;

namespace src.scripts.services.clinet
{
    public class SocketSender : ClientSender
    {
        private Socket socket;
        
        // [Inject]
        public SocketSender(SocketConfiguration socketConfiguration)
        {
            socket = socketConfiguration.getSocket();
        }

        public void sendMessage(object obj)
        {
            Debug.Log("send=" + obj);
            var bytes = new byte[8192];
            var message = JsonUtility.ToJson(obj) + "\0";
            var msg = Encoding.UTF8.GetBytes(message);
            
            var bytesSent = socket.Send(msg);
            Debug.Log("finishSend=" + obj);

        }
    }
}