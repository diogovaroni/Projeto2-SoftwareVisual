using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppRegistroVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public double BaseSalarial { get; set; }

        public List<Vendedor> ListarVendedores()
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Id = 1;
            vendedor.Nome = "Diogo";
            vendedor.Email = "diogo@gmail.com";
            vendedor.BaseSalarial = 3000;

            List<Vendedor> listaVendedores = new List<Vendedor>();
            listaVendedores.Add(vendedor);

            return listaVendedores;
        }
    }
}