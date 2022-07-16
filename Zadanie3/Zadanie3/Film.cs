using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z4
{
    public class Film : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly static Dictionary<string, string[]> relatedProperties = new Dictionary<string, string[]>()
        {
            ["Tytuł"] = new string[] { "TytułReżyser", "FormatListy" },
            ["Reżyser"] = new string[] { "TytułReżyser", "FormatListy" },
            ["DataNagrania"] = new string[] { "Wiek", "FormatListy" },
            ["Wydawca"] = new string[] { "Wydawca", "FormatListy" },
            ["Nośnik"] = new string[] { "Nośnik", "FormatListy" }
        };
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (relatedProperties.ContainsKey(propertyName))
                foreach (string relatedProperty in relatedProperties[propertyName])
                    OnPropertyChanged(relatedProperty);
            //śledzenie zapobiegające stack overflow?
        }

        static uint następneID = 0;
        /*uint wiek = 0;*/
        string
            tytuł,
            reżyser,
            wydawca,
            nośnik
            ;
        DateTime?
            dataNagrania = null
            ;

        public string Tytuł
        {
            get => tytuł;
            set
            {
                tytuł = value;
                OnPropertyChanged();
            }
        }
        public string Reżyser
        {
            get => reżyser;
            set
            {
                reżyser = value;
                OnPropertyChanged();
            }
        }
        public string Wydawca
        {
            get => wydawca;
            set
            {
                wydawca = value;

            }
        }
        public string Nośnik
        {
            get => nośnik;
            set
            {
                nośnik = value;

            }
        }
        public string WiekFilmu
        {
            get
            {
                if (dataNagrania != null)
                {
                    DateTime koniec;
                    koniec = DateTime.Now;
                    return ((koniec - (DateTime)dataNagrania).Days / 365).ToString();
                }
                else
                    return "Brak informacji";
            }
        }
        public DateTime? DataNagrania
        {
            get => dataNagrania;
            set
            {
                dataNagrania = value;
                OnPropertyChanged();
            }
        }

        public string TytułReżyser { get => $"{tytuł}, {reżyser}"; }
        public string FormatListy { get => $"{tytuł}, {reżyser}, {WiekFilmu} lat"; }
        public uint ID { get; } = następneID++;
        public string FormatID { get => "ID: " + ID; }
    }
}