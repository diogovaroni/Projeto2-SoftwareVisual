using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppRegistroVendas.Models;

namespace WebAppRegistroVendas.Controllers
{
    public class VendedorController : ApiController
    {
        // GET: api/Vendedor
        public IEnumerable<Vendedor> Get()
        {
            Vendedor vendedor = new Vendedor();

            return vendedor.ListarVendedores();
        }

        // GET: api/Vendedor/id (Com tratamento de exceção)
        public IHttpActionResult Get(int id)
        {
            Vendedor v = new Vendedor().ListarVendedores().Where(x => x.Id == id).FirstOrDefault();

            if (v != null)
            {
                return ResponseMessage(Request.CreateResponse<Vendedor>(HttpStatusCode.OK, v));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Vendedor não localizado."));
            }
        }

        // POST: api/Vendedor
        public IHttpActionResult Post([FromBody] Vendedor vendedor)
        {
            Vendedor v = new Vendedor();

            var listaVendedores = v.ListarVendedores();
            var itemIndex = listaVendedores.FindIndex(p => p.Id == vendedor.Id);

            if (itemIndex < 0)
            {
                return ResponseMessage(Request.CreateResponse<Vendedor>(HttpStatusCode.OK, v.Inserir(vendedor)));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Id já cadastrado para outro vendedor."));
            }
        }

        // PUT: api/Vendedor/id (Com tratamento de exceção)
        public IHttpActionResult Put(int id, [FromBody] Vendedor vendedor)
        {
            Vendedor v = new Vendedor().ListarVendedores().Where(x => x.Id == id).FirstOrDefault();

            if (v != null)
            {
                return ResponseMessage(Request.CreateResponse<Vendedor>(HttpStatusCode.OK, v.Atualizar(id, vendedor)));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Vendedor não localizado para atualizar."));
            }
        }

        // DELETE: api/Vendedor/id (Com tratamento de exceção)
        public IHttpActionResult Delete(int id)
        {
            Vendedor v = new Vendedor().ListarVendedores().Where(x => x.Id == id).FirstOrDefault();

            if (v != null)
            {
                v.Deletar(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Vendedor não localizado para exclusão."));
            }
        }
    }
}
