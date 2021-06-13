﻿using ApiOnlineShop.Dtos;
using ApiOnlineShop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public SaleController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddSale(SaleForCreationDto sale)
        {
            try
            {
                var product = await _productRepository.GetProduct(sale.ProductCode);

                if (product == null) return NotFound();

                product.Stock -= sale.Amount;

                await _productRepository.UpdateProduct(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "The server is not available to process this request. Try later");
            }
        }
    }
}