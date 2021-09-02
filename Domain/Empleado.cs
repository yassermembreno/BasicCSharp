using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Empleado
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        [JsonRequired]
        public string DNI { get; set; }
        [JsonProperty]
        public string Nombres { get; set; }
        [JsonProperty]
        public string Apellidos { get; set; }
        [JsonProperty]
        public decimal Salario { get; set; }
        [JsonProperty]
        public NivelAcademico NivelAcademico { get; set; }

        public class SalarioComparer : IComparer<Empleado>
        {
            public int Compare(Empleado e1, Empleado e2)
            {
                if (e1.Salario > e2.Salario)
                {
                    return 1;
                }
                else if (e1.Salario < e2.Salario)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class NivelAcademicoComparer : IComparer<Empleado>
        {
            public int Compare(Empleado x, Empleado y)
            {
                if(x.NivelAcademico > y.NivelAcademico)
                {
                    return 1;
                } else if(x.NivelAcademico < y.NivelAcademico)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class ApellidosComparer : IComparer<Empleado>
        {
            public int Compare(Empleado x, Empleado y)
            {
                return x.Apellidos.CompareTo(y.Apellidos);
            }
        }
    }
}
