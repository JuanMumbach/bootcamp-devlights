/*
    Para la solucion que genere para este proyecto, quise probar la opcion de no generar instrucciones de nivel superior,
    para trabajar con una funcion main en el proyecto ya que trabajaba de esta manera cuando aprendiamos el lenguaje C en la facultad,
    y para probar mas que nada.

    Seguramente en las actividades que siguen lo haga de la otra forma nomas ya que me parece que el codigo es mas legible (al menos que las 
    actividades requieran lo contrario).
*/
using System.Timers;

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
            Ejercicio5();
            Ejercicio6();
            Ejercicio7();
            Ejercicio8();
            Ejercicio9();
            Ejercicio10();
            */
            Ejercicio11();
            Ejercicio12();
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

        static void Ejercicio6()
        {
            Console.WriteLine("\n\n\t\tEjercicio 6\n\n");
            Console.WriteLine("Ingrese la medida de los 3 lados de un triangulo:\nlado a:");
            if (!float.TryParse(Console.ReadLine(), out float ladoA))
            {
                Console.WriteLine("El valor ingresada no es valido.");
                return;
            }

            Console.WriteLine("lado b:");
            if (!float.TryParse(Console.ReadLine(), out float ladoB))
            {
                Console.WriteLine("El valor ingresada no es valido.");
                return;
            }

            Console.WriteLine("lado c:");
            if (!float.TryParse(Console.ReadLine(), out float ladoC))
            {
                Console.WriteLine("El valor ingresada no es valido.");
                return;
            }

            if (ladoA == ladoB && ladoB == ladoC)
            {
                Console.WriteLine("El triangulo ingresado es un triangulo equilatero.");
            }
            else
            {
                if (ladoA == ladoB || ladoA == ladoC || ladoB == ladoC)
                {
                    Console.WriteLine("El triangulo ingresado es un triangulo isósceles.");
                }
                else
                {
                    Console.WriteLine("El triangulo ingresado es un triangulo escaleno");
                }
            }

            float perimetro = ladoA + ladoB + ladoC;

            float s = (ladoA + ladoB + ladoC) / 2.0f;//variable auxiliar para calcular el area
            float area = MathF.Sqrt(s * (s - ladoA) * (s - ladoB) * (s - ladoC));

            Console.WriteLine($"El perimetro del triangulo es de {perimetro} y su a area es de {area}");
        }

        static void Ejercicio7()
        {
            Console.WriteLine("\n\n\t\tEjercicio 7\n\n");
            float[] denominaciones = [ 1000, 500, 100, 50, 20, 10, 5, 2, 1];//billetes o monedas
            int[] cantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0];//contador
            int sonMonedasDesde = 5;//denominaciones menores o iguales a este valor seran consideradas monedas

            Console.WriteLine("Ingrese el monto a desglosar:");
            if (!float.TryParse(Console.ReadLine(), out float monto))
            {
                Console.WriteLine("El valor ingresada no es valido.");
                return;
            }

            //calculo de billetes y monedas necesarias
            
            int posPunto = 0;//auxiliar para saber cual es denominacion mas chica (sirve para imprimir correctamente en pantalla la respuesta para el usuario)
            int posY = 0;//auxiliar para saber cual es la segunda denominacion mas chica
            
            while (monto > 0)
            {
                for (int i = 0; i < denominaciones.Length; i++)
                {
                    if (monto >= denominaciones[i])
                    {
                        cantidades[i]++;
                        monto -= denominaciones[i];
                        if (i > posPunto)
                        {
                            posY = posPunto;
                            posPunto = i;
                        }
                        break;
                    }
                }
            }

            
            //Imprimir en pantalla las denominaciones necesarias para expresar el monto
            Console.Write("El monto puede ser desglosado en:\n");
                     
            for (int i = 0;i < denominaciones.Length;i++)
            {
                if (cantidades[i] > 0)
                {
                    string formatoMonetario;
                    if (denominaciones[i] > sonMonedasDesde)
                    {
                        formatoMonetario = cantidades[i] > 1 ? "billetes" : "billete";
                    }
                    else
                    {
                        formatoMonetario = cantidades[i] > 1 ? "monedas" : "moneda";
                    }

                    Console.Write($"{cantidades[i]} {formatoMonetario} de ${denominaciones[i]}");

                    if (i == posPunto) { Console.Write("."); break; }
                    if (i < posY) Console.Write(",\n");
                    if (i == posY) Console.Write(" y\n");
                }
            }
        }

        static void Ejercicio8()
        {
            Console.WriteLine("\n\n\t\tEjercicio 8\n\n");
            Console.WriteLine("Ingrese un numero:");
            if (!float.TryParse(Console.ReadLine(), out float numero))
            {
                Console.WriteLine("El valor ingresada no es valido.");
                return;
            }

            for (int i = 1;i <= numero;i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Ejercicio9()
        {
            Console.WriteLine("\n\n\t\tEjercicio 9\n\n");
            int cantidad = 15;
            float sumatoria = 0;

            Console.WriteLine($"Ingrese {cantidad} numeros:");
            for (int i = 0; i < cantidad; i++)
            {           
                if (float.TryParse(Console.ReadLine(), out float numero))
                {
                    sumatoria += numero;
                }
                else
                {
                    Console.WriteLine("El valor ingresada no es valido.");
                    return;
                }
            }

            Console.WriteLine($"La suma de todos los valores ingresados es:{sumatoria}.");
        }

        static void Ejercicio10()
        {
            Console.WriteLine("\n\n\t\tEjercicio 10\n\n");
            int cantidad = 5;

            List<float> numeros = new List<float>();

            Console.WriteLine($"Ingrese {cantidad} numeros:");
            for(int i = 0;i < cantidad;i++)
            {
                if (float.TryParse(Console.ReadLine(), out float numero))
                {
                    numeros.Add(numero);
                }
                else
                {
                    Console.WriteLine("El valor ingresada no es valido.");
                    return;
                }
            }

            bool algunMultiplo = false;
            for(int i = 0;i < numeros.Count; i++)
            {
                if (numeros[i] % 3 == 0)
                {
                    algunMultiplo = true;
                    Console.WriteLine($"El {i+1}º numero ingresado es {numeros[i]} y es multiplo de 3");
                }
            }
            if (!algunMultiplo) Console.WriteLine("Ningun numero se multiplo de 3");
        }
        
        static void Ejercicio11()
        {
            Console.WriteLine("\n\n\t\tEjercicio 11\n\n");
            Console.WriteLine("Ingrese contraseña:");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("La contraseña ingresada no es valida.");
                return;
            }

            Console.WriteLine("Vuelva a ingresar la contraseña:");
            string passwordValidation = Console.ReadLine();
            if (string.IsNullOrEmpty(passwordValidation))
            {
                Console.WriteLine("La contraseña ingresada no es valida.");
                return;
            }

            while(passwordValidation != password)
            {
                Console.WriteLine("La contraseña ingresada no coincide con la primer contraseña, vuelva a intentarlo:");
                passwordValidation = Console.ReadLine();
                if (string.IsNullOrEmpty(passwordValidation))
                {
                    Console.WriteLine("La contraseña ingresada no es valida.");
                    return;
                }
            }

            Console.WriteLine("Nueva contraseña confirmada.");
        }

        static void Ejercicio12()
        {
            Console.WriteLine("\n\n\t\tEjercicio 12\n\n");
            Console.WriteLine("Ingrese contraseña:");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("La contraseña ingresada no es valida.");
                return;
            }

            Console.WriteLine("Vuelva a ingresar la contraseña:");
            string passwordValidation = Console.ReadLine();
            if (string.IsNullOrEmpty(passwordValidation))
            {
                Console.WriteLine("La contraseña ingresada no es valida.");
                return;
            }

            int reintentos = 2;
            while (passwordValidation != password && reintentos > 0)
            {               
                Console.WriteLine("La contraseña ingresada no coincide con la primer contraseña, vuelva a intentarlo:");
                passwordValidation = Console.ReadLine();
                if (string.IsNullOrEmpty(passwordValidation))
                {
                    Console.WriteLine("La contraseña ingresada no es valida.");
                    return;
                }
                reintentos--;
            }
            if (reintentos == 0)
            {
                Console.WriteLine("Se supero el límite de intentos. No se pudo establecer la nueva contraseña.");
            }
            else
            {
                Console.WriteLine("Nueva contraseña confirmada.");
            }
        }
        #endregion
    }
}
