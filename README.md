# WPFStampante

WPFStampante è un progetto che permette di simulare una stampante su C#

# Classi e Funzionalità
### `Stampante`
La classe `Stampante` rappresenta la stampante e gestisce le operazioni principali come la stampa di pagine, la verifica dello stato dell'inchiostro e la gestione della carta.

#### Metodi Principali
`Stampa(Pagina p) -> bool`: Questo metodo tenta di stampare una pagina. Restituisce true se la stampa è riuscita, altrimenti false. Verifica la quantità di inchiostro disponibile e il numero di fogli.

 ```c#
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
 ```

`StatoInchiostro(Colore c) -> int`: Restituisce lo stato corrente dell'inchiostro per il colore specificato.

 ```c#
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
 ```


`StatoCarta() -> int`: Restituisce il numero di fogli di carta disponibili.
 ```c#
public int StatoCarta()
        {
            return _Fogli;
        }
 ```

`SostituisciColore(Colore c)`: Sostituisce completamente l'inchiostro del colore specificato, riportandolo al livello massimo (100).
 ```c#
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
 ```

`AggiungiCarta(int qta)`: Aggiunge una quantità specifica di fogli di carta alla stampante.
 ```c#
public void AggiungiCarta(int qta)
        {
            _Fogli += qta;
        }
 ```

### `Pagina`
La classe `Pagina` rappresenta una pagina da stampare, con le quantità specifiche di inchiostro per ciascun colore.

#### Costruttori
`public Pagina(int c, int m, int y, int b)`: Crea una pagina con le quantità specificate di inchiostro per i colori Ciano, Magenta, Giallo e Nero.
 ```c#
public Pagina(int c, int m, int y, int b)
        {
            if (c < 4) _C = c;
            if (m < 4) _M = m;
            if (y < 4) _Y = y;
            if (b < 4) _B = b;
        }
 ```

`public Pagina()`: Crea una pagina con quantità di inchiostro casuali (tra 0 e 3) per ciascun colore.
 ```c#
public Pagina()
        {
            Random rnd = new Random();
            _C = rnd.Next(0, 4);
            _M = rnd.Next(0, 4);
            _Y = rnd.Next(0, 4);
            _B = rnd.Next(0, 4);
        }
 ```

### Proprietà
`C`, `M`, `Y`, `B`: Proprietà che consentono di accedere e modificare le quantità di inchiostro per i colori Ciano, Magenta, Giallo e Nero.

 ```c#
public int C { get => _C; set => _C = value; }
        public int M { get => _M; set => _M = value; }
        public int Y { get => _Y; set => _Y = value; }
        public int B { get => _B; set => _B = value; }
 ```

