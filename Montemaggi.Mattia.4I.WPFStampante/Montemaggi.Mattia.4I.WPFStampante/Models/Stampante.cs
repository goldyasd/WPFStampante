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

        public bool Stampa(Pagina p)
        {
            if (p.B > _B || p.Y > _Y || p.C > _C || p.M > _M || _Fogli == 0)
            {
                return false;
            }
            else
            {
                _Fogli--;
                _B -= p.B;
                _C -= p.C;
                _M -= p.M;
                _Y -= p.Y;
                return true;
            }
        }

        public int StatoInchiostro(Colore c)
        {
            switch (c)
            {
                case Colore.Ciano:
                    return _C;
                case Colore.Magenta:
                    return _M;
                case Colore.Giallo:
                    return _Y;
                case Colore.Nero:
                    return _B;
                default:
                    throw new Exception("Colore non trovato");
            }
        }

        public int StatoCarta()
        {
            return _Fogli;
        }

        public void SostituisciColore(Colore c)
        {
            switch (c)
            {
                case Colore.Ciano:
                    _C = 100;
                    break;
                case Colore.Magenta:
                    _M = 100;
                    break;
                case Colore.Giallo:
                    _Y = 100;
                    break;
                case Colore.Nero:
                    _B = 100;
                    break;
            }
        }

        public void AggiungiCarta(int qta)
        {
            _Fogli += qta;
        }

    }
}
