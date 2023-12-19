using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Montemaggi.Mattia._4I.WPFStampante
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stampante stamp = new Stampante();
        
        
        public MainWindow()
        {
            StreamReader rd = new StreamReader("dati.csv");
            InitializeComponent();

            string r = rd.ReadLine();
            stamp.C = Convert.ToInt32(r.Split(';')[0]);
            stamp.M = Convert.ToInt32(r.Split(';')[1]);
            stamp.Y = Convert.ToInt32(r.Split(';')[2]);
            stamp.B = Convert.ToInt32(r.Split(';')[3]);
            stamp.Fogli = Convert.ToInt32(r.Split(';')[4]);
        }

        public void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            Pagina p;
            try
            {
                p = new Pagina(Convert.ToInt16(CBox.Text), Convert.ToInt16(MBox.Text), Convert.ToInt16(YBox.Text), Convert.ToInt16(BBox.Text));
            }
            catch
            {
                StampConsole.Content = "Valori Colore Invalidi";
                ColorSfondo.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                ColorTesto.Content = "STAMPA FALLITA";
                return;
            }
            bool result = stamp.Stampa(p);
            if (result)
            {
                ColorSfondo.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                ColorTesto.Content = "STAMPA RIUSCITA";
            }
            else
            {
                ColorSfondo.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                ColorTesto.Content = "STAMPA FALLITA";
                if(stamp.StatoCarta() == 0)
                {
                    StampConsole.Content = "Carta Mancante";
                }
                else
                {
                    StampConsole.Content = "Inchiostro Mancante";
                }
                return;
            }
            LoadPaper(new object(), new RoutedEventArgs());
            LoadC(new object(), new RoutedEventArgs());
            LoadM(new object(), new RoutedEventArgs());
            LoadY(new object(), new RoutedEventArgs());
            LoadB(new object(), new RoutedEventArgs());
            Upload();
            StampConsole.Content = "Stampa Riuscita";
        }

        private void Upload()
        {
            StreamWriter sw = new StreamWriter("dati.csv");
            sw.WriteLine($"{stamp.C};{stamp.M};{stamp.Y};{stamp.B};{stamp.Fogli}");
            sw.Close();
        }

        public void RandomPage(object sender, RoutedEventArgs e)
        {
            Pagina p = new Pagina();
            CBox.Text = Convert.ToString(p.C);
            MBox.Text = Convert.ToString(p.M);
            YBox.Text = Convert.ToString(p.Y);
            BBox.Text = Convert.ToString(p.B);
        }

        public void ChangeC(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Ciano);
            Ciano.Content = $"Ciano {stamp.StatoInchiostro(Colore.Ciano)}";
            Upload();
        }

        public void LoadC(object sender, RoutedEventArgs e)
        {
            Ciano.Content = $"Ciano {stamp.StatoInchiostro(Colore.Ciano)}";
        }

        public void ChangeM(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Magenta);
            Magenta.Content = $"Magenta {stamp.StatoInchiostro(Colore.Magenta)}";
            Upload();
        }

        public void LoadM(object sender, RoutedEventArgs e)
        {
            Magenta.Content = $"Magenta {stamp.StatoInchiostro(Colore.Magenta)}";
        }

        public void ChangeY(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Giallo);
            Giallo.Content = $"Giallo {stamp.StatoInchiostro(Colore.Giallo)}";
            Upload();
        }

        public void LoadY(object sender, RoutedEventArgs e)
        {
            Giallo.Content = $"Giallo {stamp.StatoInchiostro(Colore.Giallo)}";
        }

        public void ChangeB(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Nero);
            Nero.Content = $"Nero {stamp.StatoInchiostro(Colore.Nero)}";
            Upload();
        }

        public void LoadB(object sender, RoutedEventArgs e)
        {
            Nero.Content = $"Nero {stamp.StatoInchiostro(Colore.Nero)}";
        }

        public void ChangePaper(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Convert.ToInt16(Carta.Text) > (200 - stamp.StatoCarta()))
                {
                    StampConsole.Content = $"Valore inserito troppo grande\n\nEccesso:{(stamp.StatoCarta() + Convert.ToInt16(Carta.Text)) - 200}";
                }
                stamp.AggiungiCarta(Convert.ToInt16(Carta.Text));
                Fogli.Content = $"Fogli {stamp.StatoCarta()}/200";
                Carta.Text = "";
            }
            catch {
                StampConsole.Content = "Valore inserito\nnon valido";
                Carta.Text = "";
            }
            Upload();
        }

        public void LoadPaper(object sender, RoutedEventArgs e)
        {
            Fogli.Content = $"Fogli {stamp.StatoCarta()}/200";
        }


    }
}
