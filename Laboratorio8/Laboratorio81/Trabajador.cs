class Trabajador : Persona
    {
        // Campo de cada objeto Trabajador que almacena cuanto gana
        public int Sueldo;

        public Trabajador(string nombre, int edad, string nif, int sueldo)
            : base(nombre, edad, nif)

        {   // Iniciaizamos cada trabajador en base al constructor de Persona
            Sueldo = sueldo;
        }
    }

