using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2._0.Data;
using API_2._0.Models;
using API_2._0.Interfaces.Service;
using API_2._0.Models.ModelsPost;

namespace API_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _serviceContext;

        public ContaController(IContaService serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET: api/Conta
        [HttpGet]
        public ActionResult<IEnumerable<ContaModel>> GetConta()
        {
            return Ok(_serviceContext.GetAll());
        }

        // GET: api/Conta/5
        [HttpGet("{id}")]
        public ActionResult<ContaModel> GetContaModel(int id)
        {
            var contaModel = _serviceContext.GetOne(id);

            if (contaModel == null)
            {
                return NotFound();
            }

            return contaModel;
        }

        // PUT: api/Conta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<ContaModel> PutContaModel(int id, ContaModel contaModel)
        {
            if (id != contaModel.Id_Conta)
            {
                return BadRequest();
            }

            var response = _serviceContext.Update(contaModel);

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
            var response = _serviceContext.Insert(contaModel);

            if (response.GetType() != typeof(ContaModel))
                return BadRequest(response);

            var resposta = (ContaModel)response;

            return CreatedAtAction("GetContaModel", new { id = resposta.Id_Conta }, resposta);
        }

        // DELETE: api/Conta/5
        [HttpDelete("{id}")]
        public ActionResult<ContaModel> DeleteContaModel(int id)
        {
            var contaModel = _serviceContext.Delete(id);
            if (!contaModel)
            {
                return NotFound();
            }

            return Ok(contaModel);
        }

        public bool ContaModelExists(int id)
        {
            var response = _serviceContext.GetOne(id);
            if (response != null)
                return true;

            return false;
        }
    }
}
