/*
    Para la solucion que genere para este proyecto, quise probar la opcion de no generar instrucciones de nivel superior,
    para trabajar con una funcion main en el proyecto ya que trabajaba de esta manera cuando aprendiamos el lenguaje C en la facultad,
    y para probar mas que nada.

    Seguramente en las actividades que siguen lo haga de la otra forma nomas ya que me parece que el codigo es mas legible (al menos que las 
    actividades requieran lo contrario).
*/
namespace actividad_opcional1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Ejercicio1();
            Ejercicio2();
            Ejercicio3();
            Ejercicio4();
            */
            Ejercicio5();

        }

        #region funciones (ejercicios)
        static void Ejercicio1()
        {
            Console.WriteLine("\n\n\t\tEjercicio 1\n\n");
            Console.WriteLine("Ingrese un valor numerico:");
            if (float.TryParse(Console.ReadLine(), out float valor))
            {
                if (valor > 100)
                {
                    Console.WriteLine("El valor es mayor que 100");
                }
                else
                {
                    Console.WriteLine("El valor no es mayor que 100");
                }
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un numero válido");
            }
        }

        static void Ejercicio2()
        {
            Console.WriteLine("\n\n\t\tEjercicio 2\n\n");
            Console.WriteLine("Ingrese un numero entero:");
            if (float.TryParse(Console.ReadLine(), out float valor))
            {
                if (valor % 2 == 0)
                {
                    Console.WriteLine("Es un numero par");
                }
                else
                {
                    Console.WriteLine("Es un numero impar");
                }
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un numero válido");
            }
        }

        static void Ejercicio3()
        {
            Console.WriteLine("\n\n\t\tEjercicio 3\n\n");
            Console.WriteLine("Ingrese un numero entero:");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                if ((valor/2) % 2 == 1)
                {
                    Console.WriteLine("Si, " + valor + " es el doble de un impar.");
                }
                else
                {
                    Console.WriteLine("No, " + valor + " no es el doble de un impar.");
                }
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un numero válido");
            }
        }

        static void Ejercicio4()
        {
            Console.WriteLine("\n\n\t\tEjercicio 4\n\n");
            Console.WriteLine("Ingrese un numero entero del 1 al 10:");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                if (valor >= 1 && valor <= 10)
                {
                    string[] numerosRomanos = {"I","II","III","IV","V","VI","VII","VIII","IX","X"};
                    Console.WriteLine("El numero " + valor + " se escribe '" + numerosRomanos[valor-1] + "' en numeros romanos.");                    
                }
                else
                {
                    Console.WriteLine("El numero debe ser un numero entre 1 y 10.");
                }
            }
            else
            {
                Console.WriteLine("El valor ingresado no es un numero válido");
            }
        }

        static void Ejercicio5()
        {
            Console.WriteLine("\n\n\t\tEjercicio 5\n\n");
            
            Console.WriteLine("Ingrese el nombre de la persona 1:");           
            string nombrePersona1 = Console.ReadLine();
            if (string.IsNullOrEmpty(nombrePersona1))
            {
                Console.WriteLine("El nombre ingresado no es valido.");
                return;
            }

            Console.WriteLine("Ingrese el nombre de la persona 2:");
            string nombrePersona2 = Console.ReadLine();
            if (string.IsNullOrEmpty(nombrePersona1))
            {
                Console.WriteLine("El nombre ingresado no es valido.");
                return;
            }


            Console.WriteLine("Ingrese la edad de la persona 1:");
            if (!int.TryParse(Console.ReadLine(),out int edadPersona1))
            {
                Console.WriteLine("La edad ingresada no es valida.");
                return;
            }

            Console.WriteLine("Ingrese la edad de la persona 2:");
            if (!int.TryParse(Console.ReadLine(), out int edadPersona2))
            {
                Console.WriteLine("La edad ingresada no es valida.");
                return;
            }

            if (edadPersona1 == edadPersona2)
            {
                Console.WriteLine(nombrePersona1 + " y " + nombrePersona2 + " tienen la misma edad.");
            }

            if (edadPersona1 > edadPersona2)
            {
                Console.WriteLine(nombrePersona1 + " es mayor que " + nombrePersona2 + ".");
            }

            if (edadPersona1 < edadPersona2)
            {
                Console.WriteLine(nombrePersona2 + " es mayor que " + nombrePersona1 + ".");
            }
            
        }
        #endregion
    }
}
