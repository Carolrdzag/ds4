internal class Program  // Tipo de Acceso / Definimos la clase / Nombre de la clase
{
    private static void Main(string[] args)  // Función Principal, el codigo se comienza a ejecutar por aquí.
    {
        int primerNumero, segundoNumero, suma; // Declaramos las variables; tipo: Entero (int).

        Console.WriteLine("Ingrese el primer numero: ");      // Muestra texto y baja de línea
        primerNumero = Convert.ToInt32(Console.ReadLine());      // "Convert.ToInt32" convertir un valor string a un número entero

        Console.WriteLine("Ingrese el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());  // "Console.ReadLine() Es una función que lee lo que el usuario escribe en la consola y lo guarda como texto. Espera hasta que el usuario presione ENTER.

        suma = primerNumero + segundoNumero;  // Es una instrucción de asignación.

        Console.WriteLine("La suma de {0} y {1} es {2}", primerNumero, segundoNumero, suma);  // Lo que se encuentra entre {0} Son marcadores de posición, se reemplazan por los valores que vienen despues de la coma.

    }
}