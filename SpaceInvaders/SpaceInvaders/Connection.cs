using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Connection
    {
        IPEndPoint serverEP;
        IPEndPoint player2EP;
        EndPoint remote;
        Socket player1;
        Socket player2;
        

        public void connectP2()
        {
            serverEP = new IPEndPoint(IPAddress.Any, 9050);
            player1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            player1.Bind(serverEP);
            //player1.Listen(2);
            //player2 = player1.Accept();

            player2EP = new IPEndPoint(IPAddress.Any, 0);
            remote = (EndPoint)player2EP;
            
        }

        public void receiveData()
        {
            byte[] data = new byte[1024];
            int recv = player1.ReceiveFrom(data, ref remote);
            //details of client in message box

            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

        }

        public void sendData(string a)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(a);
            player1.SendTo(data, data.Length, SocketFlags.None, remote);

        }
    }
}
