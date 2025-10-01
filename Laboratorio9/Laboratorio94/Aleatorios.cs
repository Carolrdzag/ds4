using System;

namespace Laboratorio94
{
    public class Aleatorios
    {
        private Random random;

        public Aleatorios()
        {
            random = new Random();
        }

        // Genera un número aleatorio entre min y max (inclusive)
        public int GenerarNumeroEntre(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        // Genera un arreglo de números aleatorios entre min y max
        public int[] GenerarArregloEntre(int min, int max, int cantidad)
        {
            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = GenerarNumeroEntre(min, max);
            }
            return arreglo;

        }

        // Generar un arreglo de números no repetidos entre dos números aleatorios
        public int[] ArregloSinRepetidos(int min, int max, int cantidad)
        {
            if (cantidad > (max - min + 1))
                throw new ArgumentException("La cantidad solicitada excede el rango disponible.");

            List<int> todos = new List<int>();
            for (int i = min; i <= max; i++)
            {
                todos.Add(i);
            }

            // Mezclar la lista
            Random rnd = new Random();
            for (int i = todos.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int temp = todos[i];
                todos[i] = todos[j];
                todos[j] = temp;
            }

            int[] resultado = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                resultado[i] = todos[i];
            }
            return resultado;

        }

    }
}
