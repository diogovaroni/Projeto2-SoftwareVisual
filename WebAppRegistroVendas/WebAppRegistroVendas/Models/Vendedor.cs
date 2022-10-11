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
        // RECOMEÇAR DAQUI
        public int Id { get; set; }
        public String Nome { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
        public double BaseSalarial { get; set; }



        public List<Vendedor> ListarVendedores()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Vendedores.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaVendedores = JsonConvert.DeserializeObject<List<Vendedor>>(json);
            return listaVendedores;
        }

        public bool ReescreverArquivo(List<Vendedor> listaVendedores)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Vendedores.json");

            var json = JsonConvert.SerializeObject(listaVendedores, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }       

        public Vendedor Inserir(Vendedor vendedor)
        {
            var listaVendedores = this.ListarVendedores();

            listaVendedores.Add(vendedor);

            ReescreverArquivo(listaVendedores);
            return vendedor;
        }



        public Vendedor Atualizar(int Id, Vendedor vendedor)
        {
            var listaVendedores = this.ListarVendedores();

            var itemIndex = ListarVendedores().FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                vendedor.Id = Id;
                listaVendedores[itemIndex] = vendedor;
            }
            else
            {
                return null;
            }
            ReescreverArquivo(listaVendedores);
            return vendedor;
        }

        public bool Deletar(int Id)
        {
            var listaVendedores = this.ListarVendedores();

            var itemIndex = listaVendedores.FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                listaVendedores.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaVendedores);
            return true;
        }


    }
}