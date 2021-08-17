﻿using System;

namespace MarsRover
{
    public class Arac
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
                'N' => Yon.N,
                'S' => Yon.S,
                'E' => Yon.E,
                'W' => Yon.W,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
