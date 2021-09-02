using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public class ProductoModel
    {
        private Producto[] productos;

        #region CRUD
        public void Add(Producto p)
        {
            Add(p, ref productos);            
        }

        public bool Update(Producto p)
        {
            bool success = false;
            int index = GetIndex(p);
            if(index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Codigo} no existe.");
            }

            productos[index] = p;
            return !success;
        }

        public bool Delete(Producto p)
        {
            bool flag = false;
            int index = GetIndex(p);
            if(index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Codigo} no existe.");
            }
            Producto[] tmp = new Producto[productos.Length - 1];
            productos[index] = productos[productos.Length - 1]; 
            Array.Copy(productos, tmp, productos.Length - 1);
            productos = tmp;
            
            return !flag;
        }
        public Producto[] GetProductos()
        {
            return productos;
        }

        public Producto FindById(int id)
        {
            int index = -1;
            for(int i = 0; i < productos.Length; i++)
            {
                if(productos[i].Codigo == id)
                {
                    index = i;
                    break;
                }
            }
            
            return index < 0 ? null : productos[index];
        }
        #endregion

        #region Private Methods
        private int GetIndex(Producto p)
        {
            int index = -1, i = 0;
            foreach(Producto prod in productos)
            {
                if(prod.Codigo == p.Codigo)
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }

        private void Add(Producto p, ref Producto[] pdts)
        {
            if(p == null)
            {
                throw new ArgumentException("El objeto no puede ser null.");
            }
            
            if (pdts == null)
            {
                pdts = new Producto[1];
                pdts[pdts.Length - 1] = p;             
            }

            Producto[] tmp = new Producto[pdts.Length + 1];
            Array.Copy(pdts, tmp, pdts.Length);
            tmp[tmp.Length - 1] = p;
            pdts = tmp;
        }
        #endregion

        #region Get
        public Producto[] GetProductosPorUnidadMedida(UnidadMedida unidadMedida)
        {
            Producto[] pdts = null;
            if(productos == null)
            {
                return pdts;
            }

            foreach(Producto p in productos)
            {
                if (p.UnidadMedida.Equals(unidadMedida))
                {
                    Add(p, ref pdts);
                }
            }

            return pdts;
        }

        public Producto[] GetProductosPorCaducidad(DateTime dt)
        {
            Producto[] pdts = null;
            if (productos == null)
            {
                return pdts;
            }

            foreach (Producto p in productos)
            {
                if (p.Caducidad <= dt)
                {
                    Add(p, ref pdts);
                }
            }

            return pdts;
        }

        private string GetProductosAsJson(Producto[] pdts)
        {
            return JsonConvert.SerializeObject(pdts);
        }
        #endregion
    }
}
