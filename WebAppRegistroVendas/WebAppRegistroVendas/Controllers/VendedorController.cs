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

        // GET: api/Vendedor/5
        public Vendedor Get(int id)
        {
            Vendedor vendedor = new Vendedor();
            return vendedor.ListarVendedores().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Vendedor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vendedor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vendedor/5
        public void Delete(int id)
        {
        }
    }
}
