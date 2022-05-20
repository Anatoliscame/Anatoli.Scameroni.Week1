using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Entita
{
    internal class Categorie
    {
        [Key]
        public int Id { get; set; }
        public string Categoria { get; set; }

        public ICollection<Spese> Spese { get; set; } = new List<Spese>();

        public override string ToString()
        {
            return $"{Id} - {Categoria} ";
        }
    }
}
