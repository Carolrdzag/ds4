class ClaseBase
{
    public void test()
    {

    }

    public virtual void masTests()  //cambiando la palabra "sealed" por "virtual" nos  permite sobrescribir
    {

    }
}

class ClaseHijo : ClaseBase
{
    public override void masTests()
    {

    }
}

internal class Program 
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicación");
    }
}