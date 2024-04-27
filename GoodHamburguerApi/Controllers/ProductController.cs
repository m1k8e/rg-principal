using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using Rg_Service.Interfaces;
using Rg_Service;
using Rg_Domain.Models;

namespace GoodHamburguerApi.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet()]
        [Route("GetSandwiches")]
        public IEnumerable<Product> GetSandwiches()
        {
            return productService.GetSandwich();
        }

        [HttpGet()]
        [Route("GetExtras")]
        public IEnumerable<Product> GetExtras()
        {
            return productService.GetExtras();
        }

        [HttpGet()]
        [Route("GetSandwichesAndExtras")]
        public IEnumerable<Product> GetSandwichesAndExtras()
        {
            return productService.Get();
        }
    }
}