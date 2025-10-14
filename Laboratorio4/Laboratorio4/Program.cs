
class Program
{
    static void Main(string[] args)
    {
        int n, x;
        string linea;
        Console.Write("Ingrese el valor de n: ");
        linea = Console.ReadLine();
        n = int.Parse(linea); // Convierte texto a número.
        x = 1;  // Se inicializa en 1.
        while (x <= n)   // Mientras n sea mayor a X, la aplicación continuará ejecutandose.
        {
            Console.Write(x);         // Muestra el valor que se ingreso en consola.
            Console.Write(" , ");        //  Deja un espacio y una coma despues del número.
            x = x + 1;                       // Incrementa el valor de x de uno en uno.
        }
     Console.ReadKey();     // Espera que el usuario presione una tecla antes de cerrar la consola, pausa el programa antes que se cierre.
    }
}