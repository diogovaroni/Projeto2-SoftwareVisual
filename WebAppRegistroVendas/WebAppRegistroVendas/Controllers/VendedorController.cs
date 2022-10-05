﻿using System;
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
        public List<Vendedor> Post(Vendedor vendedor)
        {
            Vendedor _vendedor = new Vendedor();
            _vendedor.Inserir(vendedor);
            return _vendedor.ListarVendedores();
        }


        // PUT: api/Vendedor/5
        public Vendedor Put(int Id, [FromBody]Vendedor vendedor)
        {
            Vendedor _vendedor = new Vendedor();
            return _vendedor.Atualizar(Id, vendedor);
        }

        // DELETE: api/Vendedor/5
        public void Delete(int Id)
        {
            Vendedor _vendedor = new Vendedor();
            _vendedor.Deletar(Id);
        }
    }
}
