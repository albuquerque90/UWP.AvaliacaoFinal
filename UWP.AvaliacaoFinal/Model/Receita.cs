using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.AvaliacaoFinal.Model
{
    public class Receita
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ModoPreparo { get; set; }
        public string Ingredientes { get; set; }
        public TipoReceita TipoReceita { get; set; }
    }

    public class TipoReceita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
