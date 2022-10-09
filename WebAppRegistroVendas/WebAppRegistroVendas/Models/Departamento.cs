using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebAppRegistroVendas.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public String Nome { get; set; }



        public List<Departamento> ListarDepartamentos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Departamentos.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaDepartamentos = JsonConvert.DeserializeObject<List<Departamento>>(json);
            return listaDepartamentos;
        }

        public bool ReescreverArquivo(List<Departamento> listaDepartamentos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~\App_Data\Departamentos.json");

            var json = JsonConvert.SerializeObject(listaDepartamentos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }



        public Departamento Inserir(Departamento departamento)
        {
            var listaDepartamentos = this.ListarDepartamentos();

            listaDepartamentos.Add(departamento);

            ReescreverArquivo(listaDepartamentos);
            return departamento;
        }



        public Departamento Atualizar(int Id, Departamento departamento)
        {
            var listaDepartamento = this.ListarDepartamentos();

            var itemIndex = ListarDepartamentos().FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                departamento.Id = Id;
                listaDepartamento[itemIndex] = departamento;
            }
            else
            {
                return null;
            }
            ReescreverArquivo(listaDepartamento);
            return departamento;
        }

        public bool Deletar(int Id)
        {
            var listaDepartamentos = this.ListarDepartamentos();

            var itemIndex = listaDepartamentos.FindIndex(p => p.Id == Id);
            if (itemIndex >= 0)
            {
                listaDepartamentos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaDepartamentos);
            return true;
        }


    }
}