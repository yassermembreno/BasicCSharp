using Domain;
using Domain.Enums;
using Infraestructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCSharp
{
    public partial class Form1 : Form
    {
        public int Id { get; set; }
        private EmpleadoModel eModel;

        public Form1()
        {
            eModel = new EmpleadoModel();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string dni, nombres, apellidos;
            decimal salario;

            try
            {
                //dni = txtDni.Text;
                //nombres = txtNombres.Text;
                //apellidos = txtApellidos.Text;

                ////ValidateEmpleado(dni, nombres, apellidos, txtSalario.Text);
                //salario = decimal.Parse(txtSalario.Text);

                //Empleado emp = new Empleado()
                //{
                //    Id = ++Id,
                //    DNI = dni,
                //    Nombres = nombres,
                //    Apellidos = apellidos,
                //    Salario = salario,
                //    NivelAcademico = (NivelAcademico) Enum.GetValues(typeof(NivelAcademico))
                //                                          .GetValue(cmbNivel.SelectedIndex)
                //};

                //string jsonEmp = JsonConvert.SerializeObject(emp);

                string fromJson = @"{
                                       ""Id"":1,
                                       ""DNI"":""001-000000-0000U"",
                                       ""Nombres"":""Pepito"",
                                       ""Apellidos"":""Perez"",
                                       ""Salario"":10000,
                                       ""NivelAcademico"":4
                                    }";

                Empleado emp = JsonConvert.DeserializeObject<Empleado>(fromJson);
                eModel.Add(emp);

                //PrintEmpleado(jsonEmp);
                MessageBox.Show($@"
                                Id: {emp.Id} {Environment.NewLine} 
                               DNI: {emp.DNI} {Environment.NewLine} 
                           Nombres: {emp.Nombres} {Environment.NewLine} 
                         Apellidos: {emp.Apellidos} {Environment.NewLine} 
                           Salario: {emp.Salario}
                         Count:{eModel.GetEmpleados().Length}");

                CleanTexbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void PrintEmpleado(string json)
        {
            MessageBox.Show(json);
        }

        private void CleanTexbox()
        {
            txtDni.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtSalario.Text = string.Empty;
        }
       
        private void ValidateEmpleado(string dni, string name, string lastname, string wage)
        {
            string patternDni = @"\d{3}-\d{6}-\d{4}[A-Z]{1}";

            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(wage))
            {
                throw new ArgumentException("Error, todos los datos son requeridos.");
            }
            //if (!Regex.Match(dni, patternDni).Success)
            //{
            //    throw new ArgumentException("Error, dni no tiene el formato correcto [000-000000-0000U]");
            //}

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentException("Error, Nombres o apellidos no pueden ser vacios");
            }

            if(name.Length > 20 || lastname.Length > 20)
            {
                throw new ArgumentException("Error, maximo de caracteres pemitido es 20");
            }

            if (!decimal.TryParse(txtSalario.Text, out decimal salario))
            {
                throw new ArgumentException($"Error el salario: {txtSalario.Text} no se pudo convertir");
            }
            
        }

        private void BtnFragmentar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                return;
            }

            try
            {
                if (!decimal.TryParse(txtSalario.Text, out decimal salario))
                {
                    throw new ArgumentException($"Error el salario: {txtSalario.Text} no se pudo convertir");
                }

                SalarioFragmentado sf = MathExtension.GetFragmentos(salario);

                MessageBox.Show($"Miles: {sf.Miles} Centenas:{sf.Centenas} " +
                                $"Decencas:{sf.Decenas} Unidades:{sf.Unidades}" +
                                $"Centimos:{sf.Centimos}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"Salario maximo:{eModel.GetSalarioMaximo()}");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Salario minimo:{eModel.GetSalarioMinimo()}");
        }
    }
}
