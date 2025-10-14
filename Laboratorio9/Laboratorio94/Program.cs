using System;

namespace Laboratorio94
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problema 4: Generar un número entre 2 números y generar un arreglo");

            Aleatorios aleatorios = new Aleatorios();

            // Prueba del método para generar un número entre dos valores
            int numero = aleatorios.GenerarNumeroEntre(5, 20);
            Console.WriteLine($"Número aleatorio entre 5 y 20: {numero}");

            // Prueba del método para generar un arreglo de números aleatorios
            int[] arreglo = aleatorios.GenerarArregloEntre(1, 100, 16);
            Console.WriteLine("Arreglo aleatorio:");

            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write(arreglo[i] + " ");
            }

            Console.WriteLine(); // Salto de línea final
        }
    }
}
