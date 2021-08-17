using System;
using System.Collections.Generic;

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


                // Araçlar sırayla keşfe çıkarılılarak talimatları yerine getirmesi sağlanıyor.
                var result = new List<Arac>();

                foreach (var arac in araclar)
                {
                    result.Add(arac.TalimatlariYerineGetir(arac, sagUstKoordinatX, sagUstKoordinatY));
                }
                

                Console.WriteLine("--------------------");

                for (var i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(i + ". araç : " + result[i].X + " " + result[i].Y + " " + result[i].Yonu.ToString()[..1]);
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
        

    }
}
