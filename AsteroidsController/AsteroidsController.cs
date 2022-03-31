using AsteroidsModel;
using System;
using System.Collections;
using System.Net.Sockets;

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
        private void LadeSpielfeld(byte[] information)
        {
            int dx = 0, dy = 0, sf = 0, vx = 0, vy = 0, vz = 0, vs = 0;
            GameField gameField = new();
            for (int i = 0; i + 1 < information.Length - 2; i += 2)
            {
                //Ein Wort = 16 Bit, daher 2 Bytes nehmen
                byte b1 = information[i];
                byte b2 = information[i + 1];
                switch (GetOperation(b1))
                {
                    case Operation.VCTR:
                        byte b3 = information[i + 2];
                        byte b4 = information[i + 3];
                        dy = GetValueWithoutOperation(b1, b2);
                        if (GetBitOutOfBytes(5, b1, b2))
                            dy *= -1;
                        dx = GetValueWithoutOperation()
                        break;
                    case Operation.LABS:
                        byte b3 = information[i + 2];
                        byte b4 = information[i + 3];
                        vy = GetValueWithoutOperation(b1, b2);
                        vx = GetValueWithoutOperation(b3, b4);
                        vs = GetOperationWithoutValue(b3, b4);
                        break;
                    case Operation.HALT:
                        break;
                    case Operation.JSRL:
                        switch (GetSubRoutine(b1, b2))
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
                        break;
                    case Operation.RTSL:
                        break;
                    case Operation.JMPL:
                        break;
                    case Operation.SVEC:
                        break;
                }
            }
        }
        private bool GetBitOutOfBytes(int pos, params byte[] b)
        {
            return new BitArray(b).Get(pos);
        }
        private int GetOperationWithoutValue(byte b1, byte b2)
        {
            BitArray bits = new BitArray(new byte[] { b1, b2 });
            
            bits.RightShift(12);
            int[] res = new int[1];
            bits.CopyTo(res, 0);
            return res[0];
        }
        private int GetValueWithoutOperation(byte b1, byte b2)
        {
            BitArray bits = new BitArray(new byte[] { b1, b2 });
            //Die ersten 4 Bits müssen auf 0 gesetzt werden, da hier die auszuführende Operation stand.
            //4x nach Links löscht die führenden 4 Bits
            //4x nach Rechts schiebt den nun richtigen Wert an die richtige Position
            //Alternativ ein AND mit 0000 1111 1111 1111 (ersten 4 Bits werden damit zu 0, die restlichen behalten ihren Wert, siehe player.cpp)
            bits.LeftShift(4);
            bits.RightShift(4);
            int[] res = new int[1];
            bits.CopyTo(res, 0);
            return res[0];
        }
        private Subroutine GetSubRoutine(byte b1, byte b2)
        {
            switch (GetValueWithoutOperation(b1, b2))
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
        private Operation GetOperation(byte b1)
        {
            //Ersten 4 Bits holen. Dazu Shift nach rechts um 4, dadurch wird vorne mit 0 aufgefüllt.
            int intVal = b1 >> 4;
            if (intVal >= 0 && intVal <= 9)
                return Operation.VCTR;
            else if (intVal == 10)
                return Operation.LABS;
            else if (intVal == 11)
                return Operation.HALT;
            else if (intVal == 12)
                return Operation.JSRL;
            else if (intVal == 13)
                return Operation.RTSL;
            else if (intVal == 14)
                return Operation.JMPL;
            else if (intVal == 15)
                return Operation.SVEC;
            else
                throw new ArgumentException($"Ungültige Operation {intVal:X}");
        }
    }
}
