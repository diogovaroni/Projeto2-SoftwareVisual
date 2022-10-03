using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

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
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Vendedores.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaVendedores = JsonConvert.DeserializeObject<List<Vendedor>>(json);
            return listaVendedores;
        }
    }
}