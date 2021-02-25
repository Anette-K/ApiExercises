using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise2and3_WebApi.Models;

namespace Exercise2and3_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product {
                Id = 1006368,
                Name = "Austin and Barbeque AABQ Wifi Food Thermometer",
                Description = "Termometer med WiFi för en optimal innertemperatur",
                Price = 399
            },
            new Product {
                Id = 1009334,
                Name = "Andersson Elektrisk Tändare ECL 1.1",
                Description ="Elektrisk stormsäker tändare helt utan gas och bränsle",
                Price = 89
            },
            new Product {
                Id = 1002266,
                Name = "Weber Super-Stick Spray",
                Description = "BBQ-oljespray som motverkar att råvaror fastnar på gallret",
                Price = 99
            }
        };

        [HttpGet] //get ALL products
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")] //get a specific product
        public Product Get(int id)
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }

        [HttpPost] //add new product
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        [HttpDelete("{id}")] // delete specific product
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id); //find the item to delete
            products = products.Except(product).ToList(); // change the productlist to one without the item
        }

        [HttpPut("{id}")] //update product
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id); //find the existing old item 
            products = products.Except(existingProduct).ToList(); // change the productlist to one without the item
            
            products.Add(product); //add the updated item (from body)

        }
                
    }
}
