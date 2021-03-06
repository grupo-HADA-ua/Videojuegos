﻿using System;
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
        private ProductoCAD _cad;

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

        private string descripcion;
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }

         public ProductoEN()
        {
            _cad = new ProductoCAD();
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
            _cad = new ProductoCAD();
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is ProductoEN)) return false;

            ProductoEN p = (ProductoEN)obj;
            return id == p.id;
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
        public virtual void Guardar()
        {
            _cad.Crear(this);
        }

        /// <summary>
        /// Método para obtener un producto de la base de datos
        /// </summary>
        /// <param name="id">el id del producto a buscar</param>
        /// <returns>Entidad del producto</returns>
        public ProductoEN Obtener(int id)
        {
            return _cad.Obtener(id);
        }

        public IList<ProductoEN> ObtenerTodos()
        {
            var productos = new List<ProductoEN>();
            var v = new VideojuegoEN();
            var p = new PerifericoEN();
            var c = new ConsolaEN();
            productos.AddRange(v.ObtenerTodos());
            productos.AddRange(p.ObtenerTodos());
            productos.AddRange(c.ObtenerTodos());
            return productos;
        }

        /// <summary>
        /// Método para actualizar la columna correspondiente de la base de datos
        /// con el objeto actual
        /// </summary>
        public virtual void Actualizar()
        {
            _cad.Actualizar(this);
        }

        /// <summary>
        /// Borra de la base de datos la columna correspondiente
        /// al objeto actual
        /// </summary>
        public void Borrar()
        {
            _cad.Borrar(this);
        }
    }
}
