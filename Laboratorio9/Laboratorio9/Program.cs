class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Problema 1: Precio y forma de pago");
        Console.Write("Ingrese el precio del producto (valor positivo): ");
        double precio = double.Parse(Console.ReadLine());

        Console.Write("Ingrese forma de pago (efectivo o tarjeta): ");
        string formaPago = Console.ReadLine().ToLower();

        if (formaPago == "tarjeta")
        {
            Console.Write("Ingrese número de cuenta (16 dígitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16)
                Console.WriteLine("Pago registrado con tarjeta.");
            else
                Console.WriteLine("Número de cuenta inválido.");
        }
        else
        {
            Console.WriteLine("Pago registrado en efectivo.");
        }

    }
}