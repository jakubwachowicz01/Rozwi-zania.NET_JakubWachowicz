using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z4
{
    class Model
    {
        /*Prawdopodobnie brakuje jawnego pola z listą, właściwości jawnie zaimplementowanej i notyfikacji o zmianie*/
        public LinkedList<Film> Lista { get; set; } = new LinkedList<Film>(new Film[] {
            new Film() {
                Tytuł = "Skazani na Shawshank",
                Reżyser = "Frank Darabont",
                Wydawca = "Castle Rock Entertainment",
                Nośnik = "DVD",
                DataNagrania = DateTime.Parse("16.04.1995")
            },
            new Film() {
                Tytuł = "Zielona mila",
                Reżyser = "Frank Darabont",
                Wydawca = "Warner Bros. Pictures",
                Nośnik = "Bluray",
                DataNagrania = DateTime.Parse("09.12.1999")
            },
            new Film() {
                Tytuł = "Forrest Gump",
                Reżyser = "Robert Zemeckis",
                Wydawca = "Paramount Pictures",
                Nośnik = "BluRay i DVD",
                DataNagrania = DateTime.Parse("06.07.1994")
            },
        });

        internal void OtwórzSzczegóły(Film wybrany)
        {
            Szczegóły szczegóły = new Szczegóły(wybrany);
            szczegóły.Show();
        }
        internal void DodajNowy()
        {
            Film nowa = new Film();
            Lista.AddLast(nowa);
            Szczegóły szczegóły = new Szczegóły(nowa);
            szczegóły.Show();
            /*aktualizowanie widoku samej listy*/
        }
    }
}