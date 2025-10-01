class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Problema 3: Clasificación de triángulo");
        Console.Write("Ingrese lado 1: ");
        int lado1 = int.Parse(Console.ReadLine());
        Console.Write("Ingrese lado 2: ");
        int lado2 = int.Parse(Console.ReadLine());
        Console.Write("Ingrese lado 3: ");
        int lado3 = int.Parse(Console.ReadLine());

        if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 + lado3 > lado1)
        {
            if (lado1 == lado2 && lado2 == lado3)
                Console.WriteLine("El triángulo es Equilátero.");
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
                Console.WriteLine("El triángulo es Isósceles.");
            else
                Console.WriteLine("El triángulo es Escaleno.");
        }
        else
        {
            Console.WriteLine("Los lados ingresados no forman un triángulo válido.");
        }
    }

}