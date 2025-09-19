using System;
// Clase CalculosMatematicos.cs
    public class CalculosMatematicos
    {
        public static int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }

        // Nuevo método para calcular el área de un círculo
        public static double CalculoArea(double radio)
        {
            return 3.1416 * radio * radio;
        }

        public static double CalculoPerimetro(double largo, double ancho)
        {
            return 2 * (largo + ancho);
        }

    }
// Clase


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el primer número: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int resultado = CalculosMatematicos.Calcular(a, b);

        Console.WriteLine("El resultado de ({0} + {1}) * ({0} - {1}) es: {2}", a, b, resultado);

    }
}
