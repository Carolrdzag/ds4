class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Problema 2: Números pares o divisibles entre 3 del 1 al 100");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0 || i % 3 == 0)
            {
                Console.Write(i + " ");
            }
        }
    }

}