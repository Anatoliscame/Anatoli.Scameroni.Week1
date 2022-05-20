using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Entita
{
    internal class Spese
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }

        public int CategoriaId { get; set; }
        public Categorie Categoria { get; set; }


        public int idCategoria { get; set; }
        public Categorie Categoria { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Data} - {Descrizione} - {Utente} - {Importo} - {Approvato} - {CategoriaId} ";
        }

    }
}
