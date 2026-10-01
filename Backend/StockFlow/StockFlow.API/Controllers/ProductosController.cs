using Microsoft.AspNetCore.Mvc;
using StockFlow.API.Models;

namespace StockFlow.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        static List<Producto> productos = new List<Producto>
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


        // Agregar un nuevo producto a la lista
        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            //obtner el id mas alto de la lista de productos y sumarle 1 para asignarlo al nuevo producto
            int maxId = 0;
            foreach (Producto product in productos)
            {
                if (product.Id > maxId)
                {
                    maxId = product.Id;
                }
            }
            producto.Id = maxId + 1;


            productos.Add(producto);

            return producto;
        }

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



