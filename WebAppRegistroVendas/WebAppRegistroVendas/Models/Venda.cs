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
        public int IdVendedor { get; set; }
        public int IdDepartamento { get; set; }


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
            Vendedor v = new Vendedor();
            Departamento d = new Departamento();

            var listaVendedores = v.ListarVendedores();            
            var itemIndex = listaVendedores.FindIndex(p => p.Id == venda.IdVendedor);
            if (itemIndex < 0)
            {
                throw new Exception("Id vendedor não cadastrado.");
            }

            var listaDepartamentos = d.ListarDepartamentos();            
            itemIndex = listaDepartamentos.FindIndex(p => p.Id == venda.IdDepartamento);
            if (itemIndex < 0)
            {
                throw new Exception("Id departamento não cadastrado.");
            }

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