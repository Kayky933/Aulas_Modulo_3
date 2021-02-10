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
    public class PessoaController : ControllerBase
    {
        public ICollection<PessoaModel> Pessoa;

        public PessoaController()
        {
            Pessoa = new List<PessoaModel>();
            Pessoa.Add(new PessoaModel() { Id = 1,Nome = "JOAO", Numero = "12321321"});
            Pessoa.Add(new PessoaModel() { Id = 2, Nome = "MARCOS", Numero = "33333333" });
            Pessoa.Add(new PessoaModel() { Id = 3, Nome = "JULIA", Numero = "4444444" });
            Pessoa.Add(new PessoaModel() { Id = 4, Nome = "MARIA", Numero = "5555555" });
            Pessoa.Add(new PessoaModel() { Id = 5, Nome = "PEDRO", Numero = "6666666" });
        }
        // GET: api/Pessoa
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pessoa
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pessoa/5
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
