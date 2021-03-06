﻿using API_01.Contracts.Post;
using API_01.Interfaces.Service;
using API_01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_01.Controllers
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

            return contaModel;
        }

        // PUT: api/Conta/5
        [HttpPut("{id}")]
        public ActionResult<ContaModel> PutContaModel(int id, ContaModel contaModel)
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
        [HttpPost]
        public ActionResult<ContaModel> PostContaModel(ContaModelRequest contaModel)
        {

            var response = _contaService.Insert(contaModel);

            if (response.GetType() != typeof(ContaModel))
                return BadRequest(response);

            var resposta = (ContaModel)response;

            return CreatedAtAction("GetContaModel", new { id = resposta.Id_Conta }, resposta);

        }


        // DELETE: api/Conta/5
        [HttpDelete("{id}")]
        public ActionResult<ContaModel> DeleteContaModel(int id)
        {
            var response = _contaService.GetOne(id);
            if (response == null)
            {
                return NotFound();
            }
            if (!_contaService.Delete(id))
                return BadRequest();

            return Ok();
        }
    }
}

