using System;

namespace Montemaggi.Mattia._4I.WPFStampante
{
    internal class Pagina
    {
        private int _C;
        private int _M;
        private int _Y;
        private int _B;

        public Pagina(int c, int m, int y, int b)
        {
            if (c < 4) _C = c;
            if (m < 4) _M = m;
            if (y < 4) _Y = y;
            if (b < 4) _B = b;
        }

        public Pagina()
        {
            Random rnd = new Random();
            _C = rnd.Next(0, 4);
            _M = rnd.Next(0, 4);
            _Y = rnd.Next(0, 4);
            _B = rnd.Next(0, 4);
        }

        public int C { get => _C; set => _C = value; }
        public int M { get => _M; set => _M = value; }
        public int Y { get => _Y; set => _Y = value; }
        public int B { get => _B; set => _B = value; }
    }
}
