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
        public ActionResult<Producto> Post(Producto productoPost)
        {
            //obtner el id mas alto de la lista de productos y sumarle 1 para asignarlo al nuevo producto
            int maxId = 0;
            foreach (Producto producto in productos)
            {
                if (producto.Id > maxId)
                {
                    maxId = producto.Id;
                }
            }
            productoPost.Id = maxId + 1;


            productos.Add(productoPost);

            return productoPost;
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

        [HttpPut("{id}")]
        public ActionResult<Producto> Put(int id, Producto productoPut)
        {
            foreach (Producto producto in productos)
            {
                if (producto.Id == id)
                {
                   producto.Nombre = productoPut.Nombre;
                   producto.Descripcion = productoPut.Descripcion;
                   producto.Precio = productoPut.Precio;
                   producto.Stock = productoPut.Stock;
                   return producto;
                }
            }
            return NotFound();
        }
    }
}



