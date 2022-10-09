﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppRegistroVendas.Models;

namespace WebAppRegistroVendas.Controllers
{
    public class VendaController : ApiController
    {
        // GET: api/Venda
        public IEnumerable<Venda> Get()
        {
            Venda v = new Venda();

            return v.ListarVendas();
        }

        // GET: api/Venda/id (Com tratamento de exceção)
        public IHttpActionResult Get(int id)
        {
            Venda v = new Venda().ListarVendas().Where(x => x.Id == id).FirstOrDefault();


            if (v != null)
            {
                return ResponseMessage(Request.CreateResponse<Venda>(HttpStatusCode.OK, v));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Venda não localizada."));
            }
        }

        // POST: api/Venda
        public List<Venda> Post(Venda venda)
        {
            Venda v = new Venda();
            v.Inserir(venda);
            return v.ListarVendas();
        }

        // PUT: api/Venda/id (Com tratamento de exceção)
        public IHttpActionResult Put(int id, [FromBody] Venda venda)
        {
            Venda v = new Venda().ListarVendas().Where(x => x.Id == id).FirstOrDefault();
            if (v != null)
            {
                return ResponseMessage(Request.CreateResponse<Venda>(HttpStatusCode.OK, v.Atualizar(id, venda)));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Venda não localizado para atualizar."));
            }
        }

        // DELETE: api/Venda/id (Com tratamento de exceção)
        public IHttpActionResult Delete(int id)
        {
            Venda v = new Venda().ListarVendas().Where(x => x.Id == id).FirstOrDefault();

            if (v != null)
            {
                v.Deletar(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Venda não localizado para exclusão."));
            }
        }
    }
}
