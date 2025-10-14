using System;
// Clase CalculosMatematicos.cs
    public class CalculosMatematicos    // Creación de la clase
    {
        public static int Calcular(int a, int b)    // Metodo Calcular que retorna un valor y Static para usarlo sin tener que crear un objeto.
        {
            return (a + b) * (a - b);   // Instrucción
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

        int resultado = CalculosMatematicos.Calcular(a, b);  // "CalculosMatematicos.Calcular(a, b)" es la clase donde esta el metodo.se llama al metodo(son los valores que se le pasan al metodo).

        Console.WriteLine("El resultado de ({0} + {1}) * ({0} - {1}) es: {2}", a, b, resultado);  // Diferencia de cuadrados

    }
}
