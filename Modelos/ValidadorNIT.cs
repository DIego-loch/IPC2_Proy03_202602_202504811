using System;

namespace Proyecto_3
{
    public class ValidadorNIT
    {
        public string NIT { get; set; }

        public ValidadorNIT(string NIT)
        {
            this.NIT = NIT;
        }

        public bool Validacion()
        {
            //12345670
            char digitoVerificador = NIT[NIT.Length - 1]; // 0
            string cuerpo = NIT.Substring(0, NIT.Length - 1); //1234567


            int suma = 0;
            int posicion = 1;

            for (int i = cuerpo.Length - 1; i > 0; i--)
            {
                int digito = cuerpo[i] - '0';
                suma += digito * posicion;
                posicion++;
            }


            int resultado = (11 - (suma % 11)) % 11;

            if (resultado == 10)
            {
                return digitoVerificador == 'K';
            }

            int verificadorNumerico = digitoVerificador - '0';
            return resultado == verificadorNumerico;
        }
    }
}
