class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudiante");
        float score = float.Parse(Console.ReadLine());

        if (score >= 70)
        {
            Console.WriteLine();        // Salto de linea
            Console.WriteLine($"Su nota es {score} ha aprobado");  // La interpolación permite incluir variables dentro de una cadena sin necesidad de concatenar con + Se usa el símbolo  antes de la cadena y se colocan las variables entre llaves {}.
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha reprobado, debe repetir");
        }
    }
}