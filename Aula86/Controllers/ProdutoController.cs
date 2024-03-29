﻿using Aula86.AcessoDados;
using Aula86.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Aula86.Controllers
{

    [Route("api/[Controller]")]

    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepository.ListarProdutos());
            }
            catch (Exception ex)
            {

                return BadRequest("Erro" + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var produto = _produtoRepository.ObterProdutoPorId(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            try
            {
                _produtoRepository.Salvar(produto);
                return Created("/api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
                throw;
            }
        }


    }
}
