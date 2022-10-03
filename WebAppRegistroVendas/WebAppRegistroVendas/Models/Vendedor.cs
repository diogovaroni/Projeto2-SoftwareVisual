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
            //Criação dos objetos da classe 'Vendedor'
            Vendedor vendedor = new Vendedor();
            vendedor.Id = 1;
            vendedor.Nome = "Diogo";
            vendedor.Email = "diogo@gmail.com";
            vendedor.BaseSalarial = 3000;

            Vendedor vendedor2 = new Vendedor();
            vendedor2.Id = 2;
            vendedor2.Nome = "João";
            vendedor2.Email = "joao@gmail.com";
            vendedor2.BaseSalarial = 2500;

            Vendedor vendedor3 = new Vendedor();
            vendedor3.Id = 3;
            vendedor3.Nome = "José";
            vendedor3.Email = "jose@gmail.com";
            vendedor3.BaseSalarial = 2400;


            List<Vendedor> listaVendedores = new List<Vendedor>();
            listaVendedores.Add(vendedor);
            listaVendedores.Add(vendedor2);
            listaVendedores.Add(vendedor3);

            return listaVendedores;
        }
    }
}