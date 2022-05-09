using AsteroidsControllers;
using AsteroidsModel;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AsteroidsControllers
{
    public class AsteroidsController
    {
        private int _port;
        private string _adresse;
        private readonly string _prefix = "ctmame";
        private GameField gf;
        private string example = "01E20CA20CE2009000000FF6C8FABDF9006500C3006500C7B9F921A14301007000001AC9C1A24500007000001AC9A7A08A00007000000DC985A0A100007000000DC952C86CA36410007000002CCB2CCB2CCBDDCADDCA54A3A0E06DCA6DCA6DCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA3001300500000FCA1FC11B0B07C11004000002CCB32CB004000402CCB2CCB2CCB2ECB32CBDDCA2CCB78CA2CCB2CCB5CA27C11004000002CCB3ACB004000402CCB2CCB2CCB2CCB63CBDDCA2CCB78CA2CCB2CCB3CA27C11004000002CCB41CB004000402CCB2CCB2CCB2CCB4FCBDDCA2CCB78CA2CCB2CCB1CA27C11004000002CCB48CB004000402CCB2CCB2CCB2CCB4FCBDDCA2CCB78CA2CCB2CCB52C86CA36410007000002CCB2CCB2CCB63CBDDCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B001F872F801F852C86CA36410007000002CCB2CCB2CCB63CBDDCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0DDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000009730";
        public AsteroidsController(int port, string adresse)
        {
            Port = port;
            Adresse = adresse;
        }

        public int Port { get => _port; set => _port = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public GameField Gf { get => gf; set => gf = value; }

        public void SendToServer(Befehl befehl)
        {
            using (UdpClient client = new UdpClient(Adresse, Port))
            {
                client.Send(GetCommand(befehl), 8);
                Thread.Sleep(10);
                client.Send(GetCommand(Befehl.Pause), 8);
                var b = client.ReceiveAsync().Result.Buffer;
            }
        }

        private byte[] GetCommand(Befehl befehl)
        {
            return new byte[] { (byte)'c', (byte)'t', (byte)'m', (byte)'a', (byte)'m', (byte)'e', (byte)befehl, (byte)'0' };
        }
        public void Start()
        {
            //using (UdpClient Client = new(Adresse, Port))
            //{
            //    Client.Send(GetCommand(Befehl.Pause), 8);
            //    void recv(IAsyncResult res)
            //    {
            //        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 1979);
            //        byte[] received = Client.EndReceive(res, ref RemoteIpEndPoint);
            //        string hex = Convert.ToHexString(received);
            //        //Process codes
            //        Gf = LadeSpielfeld(received);
            //    }
            //    Client.BeginReceive(new AsyncCallback(recv), null);

            //}
            byte[] b = Enumerable.Range(0, example.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(example.Substring(x, 2), 16))
                .ToArray();

            GameField gf = LadeSpielfeld(b);
        }        
        
        public GameField LadeSpielfeld(byte[] information)
        {
            int dx = 0, dy = 0, sf = 0, vx = 0, vy = 0, vz = 0, vs = 0;

            GameField gameField = new();
            int i = 2;
            while (i < information.Length)
            {
                //Ein Wort = 16 Bit, daher 2 Bytes nehmen
                BitArray word = new BitArray(new byte[] { information[i+1], information[i]}).Reverse();
                int[] tmp = new int[1];
                word.CopyTo(tmp, 0);
                Console.WriteLine(tmp[0]);
                switch (GetOperationWord(word))
                {
                    case Operation.VCTR:
                        i += 4;
                        break;
                    case Operation.LABS:
                        i += 4;
                        break;
                    case Operation.HALT:
                        i += 2;
                        break;
                    case Operation.JSRL:
                        switch (GetSubRoutineWord(word))
                        {
                            case Subroutine.Copyright:
                                break;
                            case Subroutine.Explosion_Gross:
                                break;
                            case Subroutine.Explosion_Mittel2:
                                break;
                            case Subroutine.Explosion_Mittel1:
                                break;
                            case Subroutine.Explosion_Klein:
                                break;
                            case Subroutine.Asteroid_Typ1:
                                gameField.Asteroids.Add(new Asteroid(vx, vy, 1, vs));
                                break;
                            case Subroutine.Asteroid_Typ2:
                                gameField.Asteroids.Add(new Asteroid(vx, vy, 2, vs));
                                break;
                            case Subroutine.Asteroid_Typ3:
                                gameField.Asteroids.Add(new Asteroid(vx, vy, 3, vs));
                                break;
                            case Subroutine.Asteroid_Typ4:
                                gameField.Asteroids.Add(new Asteroid(vx, vy, 4, vs));
                                break;
                            case Subroutine.Ufo:
                                gameField.Ufo = new Ufo(vx, vy, vs);
                                break;
                            case Subroutine.Raumschiff_Aufrecht:
                                break;
                            case Subroutine.Buchstabe_A:
                                break;
                            case Subroutine.Unknown:
                                break;
                        }
                        i += 2;
                        break;
                    case Operation.RTSL:
                        i += 2;
                        break;
                    case Operation.JMPL:
                        break;
                    case Operation.SVEC:
                        i += 2;
                        break;
                }
            }
            return gameField;
        }
        private BitArray GetValueWithoutOperationWord(BitArray word)
        {
            return word.And(new BitArray(new bool[] { false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true }));
        }
        private Subroutine GetSubRoutineWord(BitArray word)
        {
            int[] res = new int[1];
            GetValueWithoutOperationWord(word).CopyTo(res, 0);
            switch (res[0])
            {
                case 0x852:
                    return Subroutine.Copyright;
                case 0x880:
                    return Subroutine.Explosion_Gross;
                case 0x896:
                    return Subroutine.Explosion_Mittel2;
                case 0x8B5:
                    return Subroutine.Explosion_Mittel1;
                case 0x8D0:
                    return Subroutine.Explosion_Klein;
                case 0x8F3:
                    return Subroutine.Asteroid_Typ1;
                case 0x8FF:
                    return Subroutine.Asteroid_Typ2;
                case 0x90D:
                    return Subroutine.Asteroid_Typ3;
                case 0x91A:
                    return Subroutine.Asteroid_Typ4;
                case 0x929:
                    return Subroutine.Ufo;
                case 0xA6D:
                    return Subroutine.Raumschiff_Aufrecht;
                case 0xA78:
                    return Subroutine.Buchstabe_A;
                default:
                    return Subroutine.Unknown;
            }
        }
        private Operation GetOperationWord(BitArray word)
        {
            int[] res = new int[1];
            word.RightShift(12).CopyTo(res, 0);            

            if (res[0] >= 0 && res[0] <= 9)
                return Operation.VCTR;
            else if (res[0] == 10)
                return Operation.LABS;
            else if (res[0] == 11)
                return Operation.HALT;
            else if (res[0] == 12)
                return Operation.JSRL;
            else if (res[0] == 13)
                return Operation.RTSL;
            else if (res[0] == 14)
                return Operation.JMPL;
            else if (res[0] == 15)
                return Operation.SVEC;
            else
                throw new ArgumentException($"Ungültige Operation {res[0]:X}");
        }
    }
}
