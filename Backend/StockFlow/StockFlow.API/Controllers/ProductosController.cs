using Microsoft.AspNetCore.Mvc;
using StockFlow.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockFlow.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        List<Producto> productos = new List<Producto>
            {

                new Producto
                {
                Id = 1,
                Nombre = "Teclado",
                Descripcion = "Descripción del producto 1",
                Precio = 25.50m,
                Stock = 20,
                }, new Producto
                {
                Id = 2,
                Nombre = "Mouse",
                Descripcion = "Descripción del producto 2",
                Precio = 15.75m,
                Stock = 30
                }
            };

        //Obtener la lista completa de los productos
        [HttpGet]
        public List<Producto> Get()
        {
            return productos;
        
        }

        // Obtener un Producto por su identificador 
        [HttpGet("{id}")]
        public ActionResult <Producto> Get(int id)
        {
           

            foreach (Producto producto in productos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }
            return NotFound();
        }
    }
}



