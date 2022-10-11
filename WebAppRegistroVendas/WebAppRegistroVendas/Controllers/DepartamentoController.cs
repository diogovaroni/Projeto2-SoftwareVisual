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

        // GET: api/Departamento/id (Com tratamento de exceção)
        public IHttpActionResult Get(int id)
        {
            Departamento d = new Departamento().ListarDepartamentos().Where(x => x.Id == id).FirstOrDefault();

            if (d != null)
            {
                return ResponseMessage(Request.CreateResponse<Departamento>(HttpStatusCode.OK, d));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Departamento não cadastrado."));
            }
        }

        // POST: api/Departamento
        public IHttpActionResult Post([FromBody] Departamento departamento)
        {
            Departamento d = new Departamento();
            var listaDepartamentos = d.ListarDepartamentos();
            var itemIndex = listaDepartamentos.FindIndex(p => p.Id == departamento.Id);
            if (itemIndex < 0)
            {
                return ResponseMessage(Request.CreateResponse<Departamento>(HttpStatusCode.OK, d.Inserir(departamento)));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Id já cadastrado para outro departamento."));
            }
        }


        // PUT: api/Departamento/id (Com tratamento de exceção)
        public IHttpActionResult Put(int id, [FromBody] Departamento departamento)
        {
            Departamento d = new Departamento().ListarDepartamentos().Where(x => x.Id == id).FirstOrDefault();
            if (d != null)
            {
                return ResponseMessage(Request.CreateResponse<Departamento>(HttpStatusCode.OK, d.Atualizar(id, departamento)));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Departamento não localizado para atualizar."));
            }
        }


        // DELETE: api/Vendedor/id (Com tratamento de exceção)
        public IHttpActionResult Delete(int id)
        {
            Departamento d = new Departamento().ListarDepartamentos().Where(x => x.Id == id).FirstOrDefault();

            if (d != null)
            {
                d.Deletar(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Departamento não localizado para exclusão."));
            }
        }

    }
}