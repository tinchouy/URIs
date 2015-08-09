using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Helpers;

namespace QueryString_Reflection_7._8._2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona() { Nombre = "Martin", Apellido = "Fernandez", Edad = 25 };
            Persona persona2 = new Persona() { Nombre = "Juan", Apellido = "Perez", Edad = 50 };
            Persona persona3 = new Persona() { Nombre = "Eduardo", Apellido = "Valdes", Edad = 52 };
            List<Persona> personas = new List<Persona>();
            personas.Add(persona1);
            personas.Add(persona2);
            personas.Add(persona3);
            

            foreach (Persona p in personas)
            {
                Console.WriteLine(p.ToQueryString().ToURL("www.maramal.es"));
            }

            Console.ReadKey();
        }
    }
}
