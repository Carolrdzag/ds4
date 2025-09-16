using System;

namespace Laboratorio2
    {
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de Clase.
            client.Firstname = "Carolina";
            client.Lastname = "Rodríguez";
            client.Age = 15;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }


  public class  Client
  {
      //Declarando variables de instancia en clase.
      public int Id { get; set; }
      public string Firstname { get; set; }
      public string Lastname { get; set; }    
      public ushort Age { get; set; }

      public string GetFullName()
      {
         //Utilizando variables de instancia de metodos de la clase.
         return Firstname + " " + Lastname;
      }
  }

}
