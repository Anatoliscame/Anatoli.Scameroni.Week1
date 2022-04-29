using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol
{
    internal class Alimentare : Prodotto
    {
        
        public int Quantita { get; set; }
        public  DateTime Data_scadenza { get; set; }
        // private  double somma = 0;
        public Alimentare() { }
   
        public Alimentare(int quantita, DateTime data_sc, string codice, string descr, double prezzo)
            :base(codice, descr, prezzo)
        {
            
            Quantita = quantita;  
            Data_scadenza = data_sc;
            Codice = codice;
            Descrizione = descr;
            //prezzo = somma;
        }
/*
        public double PrezzoQuantita()
        {
            double somma = 0;int count = 0;
            for (int i = 0; i <= Quantita; i++)
            {
                somma= count * Prezzo;
                count++;
            }
            return somma;
        }
*/
        public int  GiorniMancDataScaden()
        {

           return (Data_scadenza-DateTime.Now).Days;
            /*
                  DateTime dataOggi = DateTime.Now;// Data reale
                  int day = dataOggi.Day;
                  int day_r = day - Data_scadenza;
                  if(day_r == 0 || day_r < 0 )
                  {
                      Console.WriteLine("Non esiste");
                  }
                  else
                  {
                  Console.WriteLine(day);
                  Console.WriteLine(day_r);
                  }
       */
        }


        public override string Disegno()
        {
            return $"Quantita = {Quantita}, Data Scadenza = {Data_scadenza}, Codice = {Codice},\n Descrizione = {Descrizione}, Prezzo = {Prezzo}";
        }
    }
}
