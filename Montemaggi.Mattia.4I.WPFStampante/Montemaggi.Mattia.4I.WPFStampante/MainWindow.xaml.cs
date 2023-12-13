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
            InitializeComponent();
            Stampante stamp = new Stampante();
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
            Fogli.Content = $"Fogli {stamp.StatoCarta()}/200";
            Ciano.Content = $"Ciano {stamp.StatoInchiostro(Colore.Ciano)}/100";
            Magenta.Content = $"Magenta {stamp.StatoInchiostro(Colore.Magenta)}/100";
            Giallo.Content = $"Giallo {stamp.StatoInchiostro(Colore.Giallo)}/100";
            Nero.Content = $"Nero {stamp.StatoInchiostro(Colore.Nero)}/100";
            StampConsole.Content = "Stampa Riuscita";
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
            Ciano.Content = $"Ciano {stamp.StatoInchiostro(Colore.Ciano)}/100";
        }

        public void ChangeM(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Magenta);
            Magenta.Content = $"Magenta {stamp.StatoInchiostro(Colore.Magenta)}/100";
        }

        public void ChangeY(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Giallo);
            Giallo.Content = $"Giallo {stamp.StatoInchiostro(Colore.Giallo)}/100";
        }

        public void ChangeB(object sender, RoutedEventArgs e)
        {
            stamp.SostituisciColore(Colore.Nero);
            Nero.Content = $"Nero {stamp.StatoInchiostro(Colore.Nero)}/100";
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
        }


    }
}
