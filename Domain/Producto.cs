using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Caducidad { get; set; }
        
    }
}
