using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Arac : IArac
    {
        public string GirilenKonum { get; set; }  // 22E 
        public string Talimat { get; set; }  // LMLMRM

        public Yon Yonu { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Yon YonuHesapla()
        {
            char aracYonu = Convert.ToChar(GirilenKonum[^1..]);  // Yönü belirten son karakteri al.
            return aracYonu switch
            {
                'N' => Yon.North,
                'S' => Yon.South,
                'E' => Yon.East,
                'W' => Yon.West,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Arac Ileri(Arac arac, int x, int y)
        {
            // Araç x ve y koordinatlarından hareket ettiriliyor ve dışarı taşması kontrol ediliyor.
            if (arac.Yonu == Yon.East)
                if (arac.X <= x)
                    arac.X++;
                else
                    Console.WriteLine("Hata : X Koordinatı aşıldı.");

            else if (arac.Yonu == Yon.South)
                if (arac.Y > 0)
                    arac.Y--;
                else
                    Console.WriteLine("Hata : Y Koordinatı aşıldı.");

            else if (arac.Yonu == Yon.West)
                if (arac.X > 0)
                    arac.X--;
                else
                    Console.WriteLine("Hata : X Koordinatı aşıldı.");
            else
            {
                if (arac.Y <= y)
                    arac.Y++;

                else
                    Console.WriteLine("Hata : Y Koordinatı aşıldı.");
            }

            return arac;
        }

        public Yon SagaDon(Arac arac)
        {
            return arac.Yonu = arac.Yonu switch
            {
                Yon.East => Yon.South,
                Yon.South => Yon.West,
                Yon.West => Yon.North,
                _ => Yon.East
            };
        }

        public Yon SolaDon(Arac arac)
        {
            return arac.Yonu switch
            {
                Yon.East => Yon.North,
                Yon.North => Yon.West,
                Yon.West => Yon.South,
                _ => Yon.East
            };
        }

        public Arac TalimatlariYerineGetir(Arac arac, int x, int y)
        {
            var talimatDizisi = arac.Talimat.ToCharArray();

            foreach (var talimat in talimatDizisi)
            {
                switch (talimat.ToString().ToLower())
                {
                    case "l":
                        {
                            arac.Yonu = arac.SolaDon(arac);
                            break;
                        }

                    case "r":
                        {
                            arac.Yonu = arac.SagaDon(arac);
                            break;
                        }
                    case "m":
                        {
                            arac = Ileri(arac, x, y);
                            break;
                        }
                }
            }

            return arac;
        }
    }
}
