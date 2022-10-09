using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppRegistroVendas.Models;

namespace WebAppRegistroVendas.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        public IEnumerable<Departamento> Get()
        {
            Departamento departamento = new Departamento();

            return departamento.ListarDepartamentos();
        }

        // GET: api/Departamento/Id
        public Departamento Get(int id)
        {
            Departamento departamento = new Departamento();
            return departamento.ListarDepartamentos().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Departamento
        public List<Departamento> Post(Departamento departamento)
        {
            Departamento _departamento = new Departamento();
            _departamento.Inserir(departamento);
            return _departamento.ListarDepartamentos();
        }




        // PUT: api/Departamento/Id
        public Departamento Put(int Id, [FromBody] Departamento departamento)
        {
            Departamento _departamento = new Departamento();
            return _departamento.Atualizar(Id, departamento);
        }


        // DELETE: api/Departamento/Id
        public void Delete(int Id)
        {
            Departamento _departamento = new Departamento();
            _departamento.Deletar(Id);
        }
    }
}