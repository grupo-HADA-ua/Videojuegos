using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.CAD;

namespace Modelo.EN
{
    /// <summary>
    /// Esta clase representa a los productos de la tienda
    /// </summary>
    public class ProductoEN
    {
        private ProductoCAD cad;

        private bool descuento;
        public bool Descuento { get { return descuento; } set { descuento = value; } }

        private DescuentoEN descontar = new DescuentoEN(0.0);

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private double precio;
        public double Precio { 
            get {
                if (descuento)
                    return precio = precio - (precio * descontar.Descuento);
                else
                    return precio;
            }
            set { precio = value; } 
        }

        private int cantidadstock;
        public int CantidadStock { get { return cantidadstock; } set { cantidadstock = value; } }

        private int id;
        public int Id { get { return id; } set { id = value; } }

         public ProductoEN()
        {
            cad = new ProductoCAD();
        }

        public ProductoEN(int id, string nombre, double precio, int cantidadstock)
        {
            inicializar(id, nombre, precio, cantidadstock);
        }

        public ProductoEN(ProductoEN c)
        {
            inicializar(c.Id, c.Nombre, c.Precio, c.CantidadStock);
        }

        private void inicializar(int id, string nombre, double precio, int cantidadstock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            CantidadStock = cantidadstock;
            cad = new ProductoCAD();
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is ProductoEN)) return false;

            ProductoEN p = (ProductoEN)obj;
            return id == p.id & nombre == p.nombre & precio == p.precio & cantidadstock == p.cantidadstock;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 37 * Nombre.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Método para guardar el producto en la base de datos
        /// </summary>
        public void Guardar()
        {
            cad.Crear(this);
        }

        /// <summary>
        /// Método para obtener un producto de la base de datos
        /// </summary>
        /// <param name="id">el id del producto a buscar</param>
        /// <returns>Entidad del producto</returns>
        public ProductoEN Obtener(int id)
        {
            return cad.Obtener(id);
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos
        /// </summary>
        /// <returns>Lista con todos los productos</returns>
        public IList<ProductoEN> ObtenerTodos()
        {
            return cad.ObtenerTodos();
        }

        /// <summary>
        /// Método para actualizar la columna correspondiente de la base de datos
        /// con el objeto actual
        /// </summary>
        public void Actualizar()
        {
            cad.Actualizar(this);
        }

        /// <summary>
        /// Borra de la base de datos la columna correspondiente
        /// al objeto actual
        /// </summary>
        public void Borrar()
        {
            cad.Borrar(this);
        }
    }
}
