using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;


namespace HypotecniKalkulacka
{
        class VypocetHypoteky : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

      
            public double Splatka { get; set; }
            public double Umor { get; set; }
            public double Uver { get; set; }
            public double Dluh { get; set; }
            public double Urok { get; set; }
            public int UrokovaMira { get; set; }
            public int Roky { get; set; }
            public int n{ get; set; }
            public double i { get; set; }
            public double ny { get; set; }


            private double _mesicniSplatka;
            private double _celkemZaplatite;

            public double MesicniSplatka
            {
                get { return _mesicniSplatka; }
                set { _mesicniSplatka = value; OnPropertyChanged(nameof(MesicniSplatka)); }
            }
            public double CelkemZaplatite
            {
                get { return _celkemZaplatite; }
                set { _celkemZaplatite = value; OnPropertyChanged(nameof(CelkemZaplatite)); }
            }

            public Command CommandVypocet;

            public VypocetHypoteky()
            {
                n = Roky * 12;
                i = UrokovaMira / 100 / 12;
                ny = 1 / (1 + i);
                Dluh = Uver;
            do
            {
                Splatka = i * Uver / (1 - Math.Pow(ny, n));
                Urok = Uver * i;
                Umor = Splatka - Urok;
                Dluh = Dluh - Umor;

            } while (Dluh <= 0);

            CommandVypocet = new Command(()=> MesicniSplatka = Splatka);
                
   
            }

        }
    }

