using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPNETMVC5_019_Core_WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]s")]
    [Route("products")]
    public class ProductController: ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Guitarra Eléctrica", Price = 1200, Descripcion = "Ideal para el jazz"},
            new Product{ Id = 2, Name = "Apmplificador", Price = 1200, Descripcion = "Excelente amplificador"},
        };


        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            //// pruebas en devolver un string que sean los datos de todo el array 
            //string prod = string.Empty;
            //foreach (var item in products)
            //{
            //    prod = prod + item.ToString();
            //}
            //return Content(prod);


            //Antes se hacia
            //return Ok(products);

            //pero ahora aplicando el atributo [ApiController] no es necesario el Ok
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            // si uso Single y la ficha no existe me da siempre una excepcion
            //var product = products.Single(x => x.Id == id); 

            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return products.Single(x => x.Id == id);
        }


        // Devuelve un status 201 y location (url de la ficha creada)
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = products.Count() + 1;
            products.Add(model);

            return CreatedAtAction("Get", 
                                    new { id = model.Id }, 
                                    model 
                                    );
        }


        // Devuelve un 200 sin location (url de la ficha creada)
        [Route("CreateModel")]
        [HttpPost]
        public ActionResult<Product> CreateModel(Product model)
        {
            model.Id = products.Count() + 1;
            products.Add(model);

            return model;
        }



        [Route("PutVacio/{productId:int}")]
        [HttpPut("{productId}")]
        public ActionResult UpdateNoContent(int productId, Product model)
        {
            //var originalEntry = products.Single(x => x.Id == productId);
            var originalEntry = products.FirstOrDefault(x => x.Id == productId);

            originalEntry.Name = model.Name;
            originalEntry.Descripcion = model.Descripcion;
            originalEntry.Price = model.Price;

            return NoContent();
        }


        [Route("PutModel/{productId:int}")]
        [HttpPut("{productId}")]
        public ActionResult<Product> Update(int productId, Product model)
        {
            //var originalEntry = products.Single(x => x.Id == productId);
            var originalEntry = products.FirstOrDefault(x => x.Id == productId);

            originalEntry.Name = model.Name;
            originalEntry.Descripcion = model.Descripcion;
            originalEntry.Price = model.Price;

            return originalEntry;
        }


        [HttpDelete("{productId}")]
        public ActionResult Delete(int productID)
        {
            products = products.Where(x => x.Id != productID).ToList();

            return NoContent();
        }


    }
}
