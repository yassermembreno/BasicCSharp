using Domain;
using System;
using System.Collections;
using System.Linq;

namespace Infraestructure
{
    public class EmpleadoModel
    {
        private Empleado[] empleados;

        public EmpleadoModel() { }

        public void Add(Empleado e)
        {
            if(e == null)
            {
                throw new ArgumentException("Error, el empleado no puede ser null.");
            }

            if(empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = e;
                return;
            }

            Empleado[] tmp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, tmp, empleados.Length);
            tmp[tmp.Length - 1] = e;
            empleados = tmp;
        }

        public Empleado[] GetEmpleados()
        {
            return this.empleados;
        }

        public decimal GetSalarioMaximo()
        {
            decimal max = decimal.MinValue;

            foreach (Empleado e in empleados)
            {
                if(e.Salario > max)
                {
                    max = e.Salario;
                }
            }

            return max;
        }

        public decimal GetSalarioMinimo()
        {
            if(empleados == null)
            {
                return 0;
            }

            Array.Sort(empleados, SalarioComparer);
            return empleados[0].Salario;
        }

        public decimal GetSalarioPromedio()
        {
            decimal suma = 0M;            
            foreach(Empleado e in empleados)
            {
                suma += e.Salario;
            }

            return (suma / empleados.Length);
        }

        //Salarios por encima del promedio

        //Salarios por debajo del promedio

        #region Private methods
        private int SalarioComparer(Empleado e1, Empleado e2)
        {
            if(e1.Salario > e2.Salario)
            {
                return 1;
            }else if(e1.Salario < e2.Salario)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        #endregion

    }
}
