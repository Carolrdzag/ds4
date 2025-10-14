using Laboratorio94; // Esto es para heredar o referenciar otro proyecto

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Problema 5: Utilizar la clase anterior de Aleatorios");

        Aleatorios aleatorios = new Aleatorios();

        int[] sinRepetidos = aleatorios.ArregloSinRepetidos(1, 100, 16);
        Console.WriteLine("Arreglo sin números repetidos:");
        for (int i = 0; i < sinRepetidos.Length; i++)
        {
            Console.Write(sinRepetidos[i] + " ");
        }
        Console.WriteLine();
    }
}

