using System;

namespace Montemaggi.Mattia._4I.WPFStampante
{

    enum Colore
    {
        Ciano,
        Magenta,
        Giallo,
        Nero
    }
    internal class Stampante
    {
        private int _C = 100;
        private int _M = 100;
        private int _Y = 100;
        private int _B = 100;
        private int _Fogli = 200;

        public int C { get => _C; set => _C = value; }
        public int M { get => _M; set => _M = value; }
        public int Y { get => _Y; set => _Y = value; }
        public int B { get => _B; set => _B = value; }
        public int Fogli { get => _Fogli; set => _Fogli = value; }

        public bool Stampa(Pagina p)
        {
            if (p.B > B || p.Y > Y || p.C > C || p.M > M || Fogli == 0)
            {
                return false;
            }
            else
            {
                Fogli--;
                B -= p.B;
                C -= p.C;
                M -= p.M;
                Y -= p.Y;
                return true;
            }
        }

        public int StatoInchiostro(Colore c)
        {
            switch (c)
            {
                case Colore.Ciano:
                    return C;
                case Colore.Magenta:
                    return M;
                case Colore.Giallo:
                    return Y;
                case Colore.Nero:
                    return B;
                default:
                    throw new Exception("Colore non trovato");
            }
        }

        public int StatoCarta()
        {
            return Fogli;
        }

        public void SostituisciColore(Colore c)
        {
            switch (c)
            {
                case Colore.Ciano:
                    C = 100;
                    break;
                case Colore.Magenta:
                    M = 100;
                    break;
                case Colore.Giallo:
                    Y = 100;
                    break;
                case Colore.Nero:
                    B = 100;
                    break;
            }
        }

        public void AggiungiCarta(int qta)
        {
            if (qta >= 0)
            {
                Fogli += qta;
                if (Fogli > 200)
                    Fogli = 200;
            }
        }

    }
}
