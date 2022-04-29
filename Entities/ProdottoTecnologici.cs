using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Prodotti_Alim_Tecnol
{
    internal class ProdottoTecnologici : Prodotto
    {

        public string Marca { get; set; }
        public bool NuovoUsato { get; set; }

        public ProdottoTecnologici() { }

        public ProdottoTecnologici(string marca, bool nuovoUsato, string codice, string descr, double prezzo)
            :base(codice,descr, prezzo)
        {
            Marca = marca;
            NuovoUsato = nuovoUsato;
        }

       

        public override string Disegno()
        {
            return $"Marca = {Marca}, Se prodotto NEW or Used = {NuovoUsato}, Codice = {Codice},\n Descrizione = {Descrizione}, Prezzo = {Prezzo}";
        }
    }
}
