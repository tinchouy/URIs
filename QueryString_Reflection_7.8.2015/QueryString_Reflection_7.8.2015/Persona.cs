using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryString_Reflection_7._8._2015
{
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        /// <summary>
        /// Muestra todas las propiedades
        /// </summary>
        public void Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Nombre: " + Nombre.ToString() + "\n");
            str.Append("Apellido: " + Apellido.ToString() + "\n");
            str.Append("Edad: " + Edad.ToString() + "\n");
            Console.WriteLine(str.ToString());
        }
    }
}
