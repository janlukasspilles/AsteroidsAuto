using AsteroidsModel;
using AsteroidsModel.VektorInstruktionen;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
//using System.Numerics;
using System.Threading;
using System.Windows;

namespace AsteroidsControllers
{
    public class AsteroidsController
    {
        private int _port;
        private string _adresse;
        private readonly string _prefix = "ctmame";
        private GameField gf;
        private string example = "01E20CA20CE2009000000FF6C8FABDF9006500C3006500C7B9F921A14301007000001AC9C1A24500007000001AC9A7A08A00007000000DC985A0A100007000000DC952C86CA36410007000002CCB2CCB2CCBDDCADDCA54A3A0E06DCA6DCA6DCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA3001300500000FCA1FC11B0B07C11004000002CCB32CB004000402CCB2CCB2CCB2ECB32CBDDCA2CCB78CA2CCB2CCB5CA27C11004000002CCB3ACB004000402CCB2CCB2CCB2CCB63CBDDCA2CCB78CA2CCB2CCB3CA27C11004000002CCB41CB004000402CCB2CCB2CCB2CCB4FCBDDCA2CCB78CA2CCB2CCB1CA27C11004000002CCB48CB004000402CCB2CCB2CCB2CCB4FCBDDCA2CCB78CA2CCB2CCB52C86CA36410007000002CCB2CCB2CCB63CBDDCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B001F872F801F852C86CA36410007000002CCB2CCB2CCB63CBDDCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0DDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000009730";
        private string example1 = "01E210A22DF300800000007000F0D1A293F20080000029C9A8A052E30090000080430005204780C64044E0C62065F8C2B062B0C5E04640C090A0460100700000FFC802A34601007000000DC96DA192F0008000000DC9B5A1D7F1008000001AC936A27CF200800000FFC8A8A2FFF2008000001AC952C86CA36410007000002CCB2CCB2CCB32CBDDCA54A3A0E06DCA6DCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA3001300500000FCA1FC11B0B0001300500000FCA1FC11B0B0B0B000500000FCA1FC11B0B0001300500000FCA1FC11B0B0FC11B0B0FC11B0B0FC11B0B0F3CA08CB9BCA8DCAC7CA9BCAD8CA48A230100070000013CB9BCAD8CAD8CA2CCB80CA08CB8DCAB3CAFBCA02CB78CA80CA9BCA2CCBDDCAC7CA2CCBB3CA1FCBE3CA9BCAF3CAFBCAE3CA78CA8DCA9BCA2CCB93CAF3CA08CB9BCA8DCAC7CA9BCAD8CAE4A090210070000078CA72F801F872F801F852C86CA36410007000002CCB2CCB2ECB41CBDDCA6CA3E001005000002CCB2CCB2ECB41CBDDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0DDCA6CA30013005000002CCB2CCB2CCBDDCADDCAFCA1FC11B0B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002930";

        public static byte[] BitReverseTable =
{
    0x00, 0x80, 0x40, 0xc0, 0x20, 0xa0, 0x60, 0xe0,
    0x10, 0x90, 0x50, 0xd0, 0x30, 0xb0, 0x70, 0xf0,
    0x08, 0x88, 0x48, 0xc8, 0x28, 0xa8, 0x68, 0xe8,
    0x18, 0x98, 0x58, 0xd8, 0x38, 0xb8, 0x78, 0xf8,
    0x04, 0x84, 0x44, 0xc4, 0x24, 0xa4, 0x64, 0xe4,
    0x14, 0x94, 0x54, 0xd4, 0x34, 0xb4, 0x74, 0xf4,
    0x0c, 0x8c, 0x4c, 0xcc, 0x2c, 0xac, 0x6c, 0xec,
    0x1c, 0x9c, 0x5c, 0xdc, 0x3c, 0xbc, 0x7c, 0xfc,
    0x02, 0x82, 0x42, 0xc2, 0x22, 0xa2, 0x62, 0xe2,
    0x12, 0x92, 0x52, 0xd2, 0x32, 0xb2, 0x72, 0xf2,
    0x0a, 0x8a, 0x4a, 0xca, 0x2a, 0xaa, 0x6a, 0xea,
    0x1a, 0x9a, 0x5a, 0xda, 0x3a, 0xba, 0x7a, 0xfa,
    0x06, 0x86, 0x46, 0xc6, 0x26, 0xa6, 0x66, 0xe6,
    0x16, 0x96, 0x56, 0xd6, 0x36, 0xb6, 0x76, 0xf6,
    0x0e, 0x8e, 0x4e, 0xce, 0x2e, 0xae, 0x6e, 0xee,
    0x1e, 0x9e, 0x5e, 0xde, 0x3e, 0xbe, 0x7e, 0xfe,
    0x01, 0x81, 0x41, 0xc1, 0x21, 0xa1, 0x61, 0xe1,
    0x11, 0x91, 0x51, 0xd1, 0x31, 0xb1, 0x71, 0xf1,
    0x09, 0x89, 0x49, 0xc9, 0x29, 0xa9, 0x69, 0xe9,
    0x19, 0x99, 0x59, 0xd9, 0x39, 0xb9, 0x79, 0xf9,
    0x05, 0x85, 0x45, 0xc5, 0x25, 0xa5, 0x65, 0xe5,
    0x15, 0x95, 0x55, 0xd5, 0x35, 0xb5, 0x75, 0xf5,
    0x0d, 0x8d, 0x4d, 0xcd, 0x2d, 0xad, 0x6d, 0xed,
    0x1d, 0x9d, 0x5d, 0xdd, 0x3d, 0xbd, 0x7d, 0xfd,
    0x03, 0x83, 0x43, 0xc3, 0x23, 0xa3, 0x63, 0xe3,
    0x13, 0x93, 0x53, 0xd3, 0x33, 0xb3, 0x73, 0xf3,
    0x0b, 0x8b, 0x4b, 0xcb, 0x2b, 0xab, 0x6b, 0xeb,
    0x1b, 0x9b, 0x5b, 0xdb, 0x3b, 0xbb, 0x7b, 0xfb,
    0x07, 0x87, 0x47, 0xc7, 0x27, 0xa7, 0x67, 0xe7,
    0x17, 0x97, 0x57, 0xd7, 0x37, 0xb7, 0x77, 0xf7,
    0x0f, 0x8f, 0x4f, 0xcf, 0x2f, 0xaf, 0x6f, 0xef,
    0x1f, 0x9f, 0x5f, 0xdf, 0x3f, 0xbf, 0x7f, 0xff
};

        public static byte ReverseWithLookupTable(byte toReverse)
        {
            return BitReverseTable[toReverse];
        }

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
                //client.Send(GetCommand(Befehl.Pause), 8);
                var b = client.ReceiveAsync().Result.Buffer;
            }
        }

        private byte[] GetCommand(Befehl befehl)
        {
            return new byte[] { (byte)'c', (byte)'t', (byte)'m', (byte)'a', (byte)'m', (byte)'e', (byte)befehl, (byte)'0' };
        }

        public void StartBot()
        {
            var cmd = Befehl.Pause;
            int t = 0;
            using (UdpClient Client = new(Adresse, Port))
            {
                for (; ; )
                {
                    t++;
                    if (cmd == Befehl.Schuss || cmd == Befehl.Hyperspace)
                    {
                        if (t % 2 == 0)
                            Client.Send(GetCommand(cmd), 8);
                        else
                            Client.Send(GetCommand(Befehl.Pause), 8);
                    }
                    else
                    {
                        Client.Send(GetCommand(cmd), 8);
                    }

                    var b = Client.ReceiveAsync().Result.Buffer;
                    var gf = LadeSpielfeld(b);
                    if (gf.SpaceShip != null)
                        cmd = NextMove(gf);
                }
            }
            //byte[] b = Enumerable.Range(0, example1.Length)
            //    .Where(x => x % 2 == 0)
            //    .Select(x => Convert.ToByte(example1.Substring(x, 2), 16))
            //    .ToArray();

            //GameField gf = LadeSpielfeld(b);
        }
        private double GetDistanceBetweenVectors(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        public Befehl NextMove(GameField gf)
        {
            double distNearestObject;
            int dirXNearestObject;
            int dirYNearestObject;

            var nearestAsteroid = gf.Asteroids.FirstOrDefault(y => GetDistanceBetweenVectors(gf.SpaceShip.Position, y.Position) == gf.Asteroids.Min(x => GetDistanceBetweenVectors(gf.SpaceShip.Position, x.Position)));

            if ((nearestAsteroid == null && gf.Ufo == null)||nearestAsteroid == null)
            {
                return Befehl.Pause;
            }
            distNearestObject = GetDistanceBetweenVectors(gf.SpaceShip.Position, nearestAsteroid.Position);
            dirXNearestObject = nearestAsteroid.Position.X - gf.SpaceShip.Position.X;
            dirYNearestObject = nearestAsteroid.Position.Y - gf.SpaceShip.Position.Y;

            switch (nearestAsteroid.Type)
            {
                case 1:
                    distNearestObject -= 6;
                    break;

                case 2:
                    distNearestObject -= 12;
                    break;

                case 3:
                    distNearestObject -= 25;
                    break;

                case 4:
                    distNearestObject -= 50;
                    break;
            }

            if (gf.Ufo != null)
            {
                var distSaucer = GetDistanceBetweenVectors(gf.SpaceShip.Position, gf.Ufo.Position);
                if (distSaucer < distNearestObject)
                {
                    distNearestObject = distSaucer;
                    dirXNearestObject = gf.Ufo.Position.X - gf.SpaceShip.Position.X;
                    dirYNearestObject = gf.Ufo.Position.Y - gf.SpaceShip.Position.Y;
                }
            }


            Vector2 spaceShipDirection = new Vector2(gf.SpaceShip.Direction.X, gf.SpaceShip.Direction.Y);
            Vector2 nearestAsteroidDirection = new Vector2(dirXNearestObject, dirYNearestObject);



            if (distNearestObject <= 50)
            {
                return Befehl.Schub;
            }
            else
            {
                Console.WriteLine(Math.Abs(Vector2.Dot(spaceShipDirection, nearestAsteroidDirection)) - Math.Abs(spaceShipDirection.Length() * nearestAsteroidDirection.Length()));
                if (Math.Abs(Vector2.Dot(spaceShipDirection, nearestAsteroidDirection)) - Math.Abs(spaceShipDirection.Length() * nearestAsteroidDirection.Length()) < 500 && Math.Abs(Vector2.Dot(spaceShipDirection, nearestAsteroidDirection)) - Math.Abs(spaceShipDirection.Length() * nearestAsteroidDirection.Length()) > -500)
                {

                    return Befehl.Schuss;
                }
                else if (Vector2.Dot(spaceShipDirection, nearestAsteroidDirection) == -1 * (spaceShipDirection.Length() * nearestAsteroidDirection.Length()))
                {
                    return Befehl.Schub;
                }
                else if (Vector2.Multiply(spaceShipDirection, nearestAsteroidDirection).Length() > 0)
                {
                    return Befehl.Linksdrehen;
                }
                else if (Vector2.Multiply(spaceShipDirection, nearestAsteroidDirection).Length() < 0)
                {
                    return Befehl.Rechtsdrehen;
                }
                else
                {
                    return Befehl.Schub;
                }
            }
        }

        public GameField LadeSpielfeld(byte[] information)
        {
            LABS labs = null;
            GameField gameField = new();
            int v1x = 0;
            int v1y = 0;
            int i = 2;
            while (i < information.Length - 2)
            {
                //Ein Wort = 16 Bit, daher 2 Bytes nehmen
                BitArray word = new BitArray(new byte[] { information[i], information[i + 1] });
                int[] tmp = new int[1];
                word.CopyTo(tmp, 0);
                switch (GetOperationWord(word))
                {
                    case Operation.VCTR:
                        VCTR vctr = new VCTR(word, new BitArray(new byte[] { information[i + 2], information[i + 3] }), labs.GlobalerSkalierungsFaktor);
                        if (vctr.IsShot())
                            gameField.Shots.Add(new Shot(labs.X, labs.Y));
                        else if (vctr.IsShip())
                        {
                            if (v1x == 0 && v1y == 0)
                            {
                                v1x = vctr.X;
                                v1y = vctr.Y;
                            }
                            else
                            {
                                gameField.SpaceShip = new SpaceShip(new Point(labs.X, labs.Y), new Point(v1x - vctr.X, v1y - vctr.Y));
                            }
                        }
                        i += 4;

                        break;

                    case Operation.LABS:
                        labs = new LABS(word, new BitArray(new byte[] { information[i + 2], information[i + 3] }));
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
                                gameField.Asteroids.Add(new Asteroid(labs.X, labs.Y, 1, labs.GlobalerSkalierungsFaktor));
                                break;

                            case Subroutine.Asteroid_Typ2:
                                gameField.Asteroids.Add(new Asteroid(labs.X, labs.Y, 2, labs.GlobalerSkalierungsFaktor));
                                break;

                            case Subroutine.Asteroid_Typ3:
                                gameField.Asteroids.Add(new Asteroid(labs.X, labs.Y, 3, labs.GlobalerSkalierungsFaktor));
                                break;

                            case Subroutine.Asteroid_Typ4:
                                gameField.Asteroids.Add(new Asteroid(labs.X, labs.Y, 4, labs.GlobalerSkalierungsFaktor));
                                break;

                            case Subroutine.Ufo:
                                gameField.Ufo = new Ufo(labs.X, labs.Y, labs.GlobalerSkalierungsFaktor);
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
                        SVEC svec = new SVEC(word, labs.GlobalerSkalierungsFaktor);
                        i += 2;
                        break;
                }
            }
            return gameField;
        }

        private BitArray GetValueWithoutOperationWord(BitArray word)
        {
            return new BitArray(word).And(new BitArray(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false }));
        }

        private Subroutine GetSubRoutineWord(BitArray word)
        {
            BitArray tmp = new BitArray(word);
            int[] res = new int[1];
            GetValueWithoutOperationWord(tmp).CopyTo(res, 0);
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
            BitArray tmp = new BitArray(word);
            int[] res = new int[1];
            tmp.RightShift(12).CopyTo(res, 0);

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