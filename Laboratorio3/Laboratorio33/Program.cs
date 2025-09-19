using System;
class Program
{
    static void Main(string[] args)
    {
        double largo, ancho, perimetro;

        Console.WriteLine("Ingrese el largo: ");
        largo = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese el ancho: ");
        ancho = Convert.ToDouble(Console.ReadLine());   

        perimetro = CalculosMatematicos.CalculoPerimetro(largo, ancho);

        Console.WriteLine("El perímetro del rectángulo es {0}", perimetro);

    }
}
