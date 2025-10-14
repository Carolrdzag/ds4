
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el radio del círculo: ");
        double radio = Convert.ToDouble(Console.ReadLine());

        double area = CalculosMatematicos.CalculoArea(radio);

        Console.WriteLine("El área del círculo con radio {0} es: {1:F2}", radio, area);  // {1:F2} se reemplaza por el valor de area con 2 decimales.

    }
}
