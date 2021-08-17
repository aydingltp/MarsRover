using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IArac
    {
        public Arac TalimatlariYerineGetir(Arac arac, int x, int y);
        public Yon YonuHesapla();
        public Arac Ileri(Arac arac, int x, int y);
        public Yon SagaDon(Arac arac);
        public Yon SolaDon(Arac arac);  

    }
}
