using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using WebAppRegistroVendas.Controllers;

namespace WebAppRegistroVendas.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public String NomeVendedor { get; set; }
        public String NomeDepartamento { get; set; }




        public List<Venda> ListarVendas()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Vendas.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaVendas = JsonConvert.DeserializeObject<List<Venda>>(json);
            return listaVendas;
        }



        public bool ReescreverArquivo(List<Venda> listaVendas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Vendas.json");

            var json = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }


        public Venda Inserir(Venda venda)
        {
            var listaVendas = this.ListarVendas();
            listaVendas.Add(venda);
            ReescreverArquivo(listaVendas);
            return venda;
        }


        public Venda Atualizar(int Id, Venda venda)
        {
            var listaVendas = this.ListarVendas();

            var itemIndex = ListarVendas().FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                venda.Id = Id;
                listaVendas[itemIndex] = venda;
            }
            else
            {
                return null;
            }
            ReescreverArquivo(listaVendas);
            return venda;
        }

        public bool Deletar(int Id)
        {
            var listaVendas = this.ListarVendas();

            var itemIndex = listaVendas.FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                listaVendas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaVendas);
            return true;
        }
    }
}