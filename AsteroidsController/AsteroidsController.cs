using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AsteroidsControllers
{
    public class AsteroidsController
    {
        private int _port;
        private string _adresse;
        private readonly string _prefix = "ctmame";
        public AsteroidsController(int port, string adresse)
        {
            Port = port;
            Adresse = adresse;
        }

        public int Port { get => _port; set => _port = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }

        public byte[] SendToServer(Befehl befehl)
        {
            using (UdpClient client = new UdpClient(Adresse, Port))
            {
                client.Send(GetCommand(befehl), 8);
                client.Send(GetCommand(Befehl.Pause), 8);
                return client.ReceiveAsync().Result.Buffer;
            }
        }

        private byte[] GetCommand(Befehl befehl)
        {            
            return new byte[] { (byte)'c', (byte)'t', (byte)'m', (byte)'a', (byte)'m', (byte)'e', (byte)befehl, (byte)'0' };
        }
    }
}
