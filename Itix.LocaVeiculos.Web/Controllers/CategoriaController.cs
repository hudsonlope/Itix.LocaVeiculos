﻿using Itix.LocaVeiculos.Dominio.Contratos;
using Itix.LocaVeiculos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.LocaVeiculos.Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _db;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _db = categoriaRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_db.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _db.Insert(categoria);
                return Created("api/categoria", categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
