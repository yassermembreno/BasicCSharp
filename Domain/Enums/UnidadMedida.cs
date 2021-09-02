using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public class UnidadMedida : Enumeration
    {
        public static UnidadMedida Unidad = new UnidadMedida(0,"Unidad");
        public static UnidadMedida Litros = new UnidadMedida(1, "Litros");
        public static UnidadMedida MiliLitros = new UnidadMedida(2, "MiliLitros");
        public static UnidadMedida Gramos = new UnidadMedida(3, "Gramos");
        public static UnidadMedida Kilogramos = new UnidadMedida(4, "Kilogramos");
        public static UnidadMedida Libras = new UnidadMedida(5, "Libras");

        private UnidadMedida() { }
        private UnidadMedida(int value, string name) : base(value, name) { }
    }
}
