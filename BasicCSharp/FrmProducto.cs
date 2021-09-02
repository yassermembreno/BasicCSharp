using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCSharp
{
    public partial class FrmProducto : Form
    {
        private ProductoModel productoModel;
        public FrmProducto()
        {
            productoModel = new ProductoModel();
            InitializeComponent();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            ValidateProducto(txtCod.Text,txtName.Text,txtDesc.Text,txtCant.Text,txtPre.Text,dtpCadu.Text,out int id,out int q, out decimal pre, out DateTime caducity);

            
            Producto p = new Producto
            {
                Codigo = id,
                Nombre = txtName.Text,
                Descripcion = txtDesc.Text,
                Cantidad = q,
                Precio = pre,
                Caducidad = caducity
            };

            productoModel.Add(p);
            PrintProducto(p);

        }

        private void PrintProducto(Producto p)
        {
            string text = $@"Cod:{p.Codigo} 
                          Nombre:{p.Nombre}
                     Descripcion:{p.Descripcion}
                        Cantidad:{p.Cantidad}
                          Precio:{p.Precio}
                       Caducidad:{p.Caducidad}";
            MessageBox.Show(text,"Mensaje de informacion",MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ValidateProducto(string id, string name, string desc, string cantidad,string precio, string caducidad,out int cod, out int q, out decimal p, out DateTime caducity)
        {
            if(string.IsNullOrWhiteSpace(id)   || 
               string.IsNullOrWhiteSpace(name) || 
               string.IsNullOrWhiteSpace(desc) || 
               string.IsNullOrWhiteSpace(cantidad) || 
               string.IsNullOrWhiteSpace(caducidad))
            {
                throw new ArgumentException("Error, todos los campos son requeridos.");
            }

            if (!int.TryParse(id, out cod))
            {
                throw new ArgumentException("Error, la cantidad no tiene el formato correcto.");
            }

            if (!decimal.TryParse(precio, out p))
            {
                throw new ArgumentException("Error, el precio no tiene un formato correcto.");
            }

            if(!int.TryParse(cantidad, out q))
            {
                throw new ArgumentException("Error, la cantidad no tiene el formato correcto.");
            }

            if(!DateTime.TryParse(caducidad, out  caducity))
            {
                throw new ArgumentException("Error, la fecha no tiene el formato correcto");
            }
        }
    }
}
