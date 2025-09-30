class Aleatorios
{
    private Random random;

    public Aleatorios()
    {
        random = new Random();
    }

    // i. Generar un número entre 2 números
    public int GenerarNumero(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    // ii. Generar un arreglo de números aleatorios
    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarNumero(min, max);
        }
        return arreglo;
    }

    // v. Generar un arreglo de números NO repetidos
    public int[] GenerarArregloNoRepetidos(int cantidad, int min, int max)
    {
        HashSet<int> numeros = new HashSet<int>();
        while (numeros.Count < cantidad)
        {
            numeros.Add(GenerarNumero(min, max));
        }
        int[] arreglo = new int[cantidad];
        numeros.CopyTo(arreglo);
        return arreglo;
    }
}