using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var araclar = new List<Arac>();

            Console.WriteLine("Platonun sağ üst koordinatlarını giriniz : Orn => 66");

            try
            {
                var sagUstKoordinatAsString = Console.ReadLine();

                int sagUstKoordinat;

                // Kullanıcının sadece sayı olarak girmesi için validasyon
                while (!int.TryParse(sagUstKoordinatAsString, out sagUstKoordinat))
                {
                    Console.WriteLine("Lütfen '66' formatında sayı olarak giriniz.");
                    sagUstKoordinatAsString = Console.ReadLine();
                }

                // Koordinatlar belirlendi.
                int sagUstKoordinatX = Convert.ToInt16(sagUstKoordinat.ToString().Substring(0, 1));
                int sagUstKoordinatY = Convert.ToInt16(sagUstKoordinat.ToString().Substring(0, 1));

                do
                {
                    var arac = new Arac();

                    Console.WriteLine("Aracın konumunu giriniz : ");
                    arac.GirilenKonum = Console.ReadLine();

                    // Girilen konuma göre aracın x, y koordinatları ve yönü hesaplanıyor.
                    arac.Yonu = arac.YonuHesapla();
                    arac.X = Convert.ToInt32(arac.GirilenKonum.Substring(0, 1));
                    arac.Y = Convert.ToInt32(arac.GirilenKonum.Substring(1, 1));

                    Console.WriteLine("Araca talimat giriniz : ");
                    arac.Talimat = Console.ReadLine();

                    araclar.Add(arac);

                    Console.WriteLine("Yeni araç için Enter'a bas. Araç bitti ise ESC'a basınız : ");

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
                } while (Console.ReadKey().Key == ConsoleKey.Enter);

                // Araçlar Keşfe Çıkarılıyor.
                var result = AraclariKesfeCikar(sagUstKoordinatX, sagUstKoordinatY, araclar);

                Console.WriteLine("--------------------");

                for (var i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(i + ". araç : " + result[i].X + " " + result[i].Y + " " + result[i].Yonu);
                }

                Console.WriteLine("--------------------");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }

        }

        private static List<Arac> AraclariKesfeCikar(int sagUstX, int sagUstY, List<Arac> araclar)
        {
            var result = new List<Arac>();

            // Araçlar sırayla talimatları yerine getiriyor.
            foreach (var arac in araclar)
            {
                result.Add(TalimatlariYerineGetir(arac, sagUstX, sagUstY));
            }

            return result;
        }

        private static Arac TalimatlariYerineGetir(Arac arac, int x, int y)
        {
            char[] talimatDizisi = arac.Talimat.ToCharArray();

            foreach (var talimat in talimatDizisi)
            {
                switch (talimat.ToString().ToLower())
                {
                    case "l":
                    {
                        arac.Yonu = arac.Yonu switch
                        {
                            Yon.East => Yon.North,
                            Yon.North => Yon.West,
                            Yon.West => Yon.South,
                            _ => Yon.East
                        };
                        break;
                    }

                    case "r":
                    {
                        arac.Yonu = arac.Yonu switch
                        {
                            Yon.East => Yon.South,
                            Yon.South => Yon.West,
                            Yon.West => Yon.North,
                            _ => Yon.East
                        };
                        break;
                    }
                    case "m":
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
                            break;
                        }
                }
            }

            return arac;
        }

    }
}
