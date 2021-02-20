using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Conta2Controller : ControllerBase
    {
        public ICollection<ContaModel> contas;

        public Conta2Controller()
        {
            contas = new List<ContaModel>();
            contas.Add(new ContaModel() { Id = 1, NomeDoCredor = "MARCOS", DataDoVencimento = DateTime.Parse("10/01/2020"), ValorAPagar = 10, DataDoPagamento = null });
            contas.Add(new ContaModel() { Id = 2, NomeDoCredor = "JUNIOR", DataDoVencimento = DateTime.Parse("13/02/2020"), ValorAPagar = 12, DataDoPagamento = null });
            contas.Add(new ContaModel() { Id = 3, NomeDoCredor = "MARIA", DataDoVencimento = DateTime.Parse("20/04/2020"), ValorAPagar = 40, DataDoPagamento = null });
            contas.Add(new ContaModel() { Id = 4, NomeDoCredor = "PEDRO", DataDoVencimento = DateTime.Parse("22/02/2020"), ValorAPagar = 14, DataDoPagamento = null });
        }
        // GET: api/Conta2
        [HttpGet]
        public ActionResult<ContaModel> Get()
        {
            return Ok(contas.OrderBy(a => a.NomeDoCredor).ToList());
        }

        // GET: api/Conta2/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ContaModel> Get(int id)
        {
            return Ok(contas.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: api/Conta2
        [HttpPost]
        public ActionResult<ContaModel> Post([FromBody] ContaModel conta )
        {
            if (conta == null)
                return BadRequest();

            contas.Add(conta);

            return Ok(conta);
        }

        // PUT: api/Conta2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
