using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class MathExtension    {

        public static SalarioFragmentado GetFragmentos(decimal salario)
        {
            int m = 0, c = 0, d = 0, u = 0, cm = 0;

            m = (int)salario / 1000;
            salario %= 1000;            
            c = (int)salario / 100;
            salario %= 100;
            d = (int)salario / 10;
            salario %= 10;
            u = (int)salario;
            cm = (int)((salario - u) * 100);

            return new SalarioFragmentado()
            {
                Miles = m,
                Centenas = c,
                Decenas = d,
                Unidades = u,
                Centimos = cm
            };
        }
        
    }
}
