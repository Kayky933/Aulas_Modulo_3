using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2._0.Context;
using API_2._0.Models;
using API_2._0.Interfaces.Service;
using API_2._0.Models.Contracts;

namespace API_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        // GET: api/Conta
        [HttpGet]
        public ActionResult<IEnumerable<ContaModel>> GetConta()
        {
            return Ok(_contaService.GetAll());
        }

        // GET: api/Conta/5
        [HttpGet("{id}")]
        public ActionResult<ContaModel> GetContaModel(int id)
        {
            var contaModel = _contaService.GetOne(id);

            if (contaModel == null)
            {
                return NotFound();
            }

            return Ok(contaModel);
        }

        // PUT: api/Conta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutContaModel(int id, ContaModel contaModel)
        {
            if (id != contaModel.Id_Conta)
            {
                return BadRequest();
            }
            var response = _contaService.Update(contaModel);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST: api/Conta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ContaModel> PostContaModel(ContaModelRequest contaModel)
        {
            var response = _contaService.Insert(contaModel);

            if (response.GetType() != typeof(ContaModel))
                return BadRequest(response);

            var response2 = (ContaModel)response;

            return CreatedAtAction("GetContaModel", new { id = response2.Id_Conta }, response2);
        }

        // DELETE: api/Conta/5
        [HttpDelete("{id}")]
        public ActionResult<ContaModel> DeleteContaModel(int id)
        {
            var contaModel = _contaService.Delete(id);
            var exist = _contaService.GetOne(id);
            if (exist == null)
            {
                return NotFound();
            }
            if (!contaModel)
                return BadRequest();

            return Ok(contaModel);
        }
        /*
        private bool ContaModelExists(int id)
        {
            var conta = _contaService.GetOne(id);
            if (conta != null)
                return true;

            return false;
        }
        */
    }
}
