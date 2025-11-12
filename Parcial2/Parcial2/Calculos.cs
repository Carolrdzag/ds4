using System; // Importa el espacio de nombres para clases básicas
using System.Data; // Importa el espacio de nombres para DataTable
using System.Text.RegularExpressions; // Importa el espacio de nombres para expresiones regulares

namespace Parcial2 //Nombre del Proyecto
{
    public static class Calculos
    {
        // Método para convertir de Libras a Kilogramos
        public static double LibrasAKilogramos(double libras)
        {
            // 1 libra = 0.45359237 kilogramos
            return libras * 0.4535;
        }

        // Método para convertir de Kilogramos a Libras
        public static double KilogramosALibras(double kilogramos)
        {
            // 1 kilogramo = 2.20462262 libras
            return kilogramos * 2.2046;
        }

    }

}
