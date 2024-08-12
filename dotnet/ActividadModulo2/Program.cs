using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ActividadModulo2
{
    internal class Program
    {
        #region Variables globales
        static int[,] temperaturasDias = new int[5,7];

        static float[] promedioSemanas = new float[5];

        static List<float> temperaturaSobreUmbral = new List<float>();
        static List<int> fechaSobreUmbral = new List<int>();

        static float umbral = 20;

        static bool salir = false;

        #endregion
        #region Programa principal
        static void Main(string[] args)
        {
            Console.WriteLine("Weather Forecast");
            CargaDeDatos();
            Console.WriteLine("Datos cargados. Presione enter/entrar para continuar...");
            Console.ReadLine();
            CalcularTemperaturasPromedio();
            while(!salir)
            {
                MenuOpciones();
            }
        }
        #endregion

        #region funciones
        /* Funciones principales*/
        static void CargaDeDatos()
        {
            Random random = new Random();
            for(int i = 0;i < temperaturasDias.GetLength(0);i++)
            {
                for (int j = 0;j < temperaturasDias.GetLength(1);j++)
                {
                    temperaturasDias[i, j] = random.Next(-10, 51);
                }
            }
        }

        static void MenuOpciones()
        {
            Console.Clear();
            Console.WriteLine("Puede realizar las siguientes consultas:\n" +
                "1 - Temperatura de un dia especifico.\n" +
                "2 - Promedio de las temperaturas de cada semana.\n" +
                "3 - Dias en los que la temperatura supera los 20 grados.\n" +
                "4 - Temperatura promedio del mes.\n" +
                "5 - Dia con la temperatura mas alta.\n" +
                "6 - Dia con la temperatura mas baja.\n" +
                "7 - Pronostico primeros 5 dias del siguiente mes.\n" +
                "8 - Salir del programa.\n" +
                "Elija una opcion:");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch(opcion)
                {
                    case 1:
                        ConsultarTemperaturaDia();
                        break;
                    case 2:
                        MostrarTemperaturasPromedioSemanales();
                        break;
                    case 3:
                        MostrarTemperaturasSobreUmbral();
                        break;
                    case 4:
                        ConsultarTemperaturaPromedioMes();
                        break;
                    case 5:
                        ConsultarTemperaturaMasAlta();
                        break;
                    case 6:
                        ConsultarTemperaturaMasBaja();
                        break;
                    case 7:
                        Consultar5diasSiguienteMes();
                        break;
                    case 8:
                        salir = true;
                        Console.Clear();
                        Console.WriteLine("Cerrando Weather Forecast");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Debe elegir una opción con un número entero entre 1 y 8 inclusive.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Se ingresó una opción no válida.");
            }

            Console.WriteLine("Presione enter/entrar para continuar...");
            Console.ReadLine();
        }


        /*Funciones Opciones*/
        static void ConsultarTemperaturaDia() 
        {
            Console.WriteLine("Elige la fecha de la que quieres consultar la temperatura (un numero entero del 1 al 31):");
            if (int.TryParse(Console.ReadLine(),out int diaConsulta))
            {
                int semana = (diaConsulta-1) / 7;
                int dia = (diaConsulta - 1) - ((diaConsulta - 1) / 7) * 7;
                int temperatura = temperaturasDias[semana,dia];
                Console.WriteLine($"Semana {semana+1} dia {dia+1}");
                Console.WriteLine($"La temperatura del dia {diaConsulta} es de {temperatura} grados.");
            }
        }

        static void MostrarTemperaturasPromedioSemanales()
        {
            CalcularTemperaturasPromedio();

            Console.WriteLine("La temperatura promedio de las semanas es:");
            for (int i = 0; i < promedioSemanas.Length; i++)
            {
                Console.WriteLine($"Semana {(i + 1)}: {promedioSemanas[i]} grados.");
            }
        }

        static void ConsultarTemperaturaPromedioMes()
        {
            int sumatoria = 0;
            for (int i = 0; i < temperaturasDias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDias.GetLength(1); j++)
                {
                    if (((i + 1) * 7 + (j + 1)) > 31) break;
                    sumatoria += temperaturasDias[i, j];
                }

            }

            float promedio = sumatoria / 31;

            Console.WriteLine($"La temperatura promedio del mes es de {promedio} grados.");
        }

        static void MostrarTemperaturasSobreUmbral()
        {
            BuscarTemperaturasSobreUmbral();

            Console.WriteLine($"Los dias en los que la temperatura supero los {umbral} grados son:");
            
            if (fechaSobreUmbral.Count == 0)
            {
                Console.WriteLine($"No hay dias que superen el umbral de {umbral} grados.");
                return;
            }

            for (int i = 0; i < fechaSobreUmbral.Count; i++)
            {
                Console.WriteLine($"Dia {fechaSobreUmbral[i]}: {temperaturaSobreUmbral[i]} grados.");
            }
        }

        static void ConsultarTemperaturaMasAlta()
        {
            float temperaturaAlta = temperaturasDias[0,0];
            int fechaTempAlta = 1;

            for (int i = 0; i < temperaturasDias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDias.GetLength(1); j++)
                {
                    if (((i + 1) * 7 + (j + 1)) > 31) break;
                    
                    if (temperaturasDias[i, j] > temperaturaAlta)
                    {
                        temperaturaAlta = temperaturasDias[i, j];
                        fechaTempAlta = ((i + 1) * 7 + (j + 1));
                    }
                }
            }

            Console.WriteLine($"El dia con la temperatura mas alta es el dia {fechaTempAlta} con una temperatura de {temperaturaAlta} grados.");
        }

        static void ConsultarTemperaturaMasBaja()
        {
            float temperaturaBaja = temperaturasDias[0, 0];
            int fechaTempBaja = 1;
            for (int i = 0; i < temperaturasDias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDias.GetLength(1); j++)
                {
                    if (((i + 1) * 7 + (j + 1)) > 31) break;

                    if (temperaturasDias[i, j] < temperaturaBaja)
                    {
                        temperaturaBaja = temperaturasDias[i, j];
                        fechaTempBaja = ((i + 1) * 7 + (j + 1));
                    }
                }
            }

            Console.WriteLine($"El dia con la temperatura mas alta es el dia {fechaTempBaja} con una temperatura de {temperaturaBaja} grados.");

        }

        static void Consultar5diasSiguienteMes()
        {
            Console.WriteLine("Las temperaturas de los primeros 5 dias del mes siguiente son:");
            for(int i = 2;i < 7;i++)
            {
                Console.WriteLine($"Dia {i-1}: {temperaturasDias[4,i]} grados.");
            }
        }
        #endregion

        #region Funciones Auxiliares
        static void CalcularTemperaturasPromedio()
        {
            for (int i = 0; i < temperaturasDias.GetLength(0); i++)
            {
                float sumatoria = 0;
                for(int j = 0; j < temperaturasDias.GetLength(1);j++)
                {
                    sumatoria += temperaturasDias[i, j];
                }
                promedioSemanas[i] = sumatoria / temperaturasDias.GetLength(1);
            }
        }

        static void BuscarTemperaturasSobreUmbral()
        {
            fechaSobreUmbral.Clear();
            temperaturaSobreUmbral.Clear();
            
            for (int i = 0; i < temperaturasDias.GetLength(0);i++)
            {
                for (int j = 0; j < temperaturasDias.GetLength(1); j++)
                {
                    if (((i + 1) * 7 + (j + 1)) > 31) break;


                    if (temperaturasDias[i,j] > umbral)
                    {
                        fechaSobreUmbral.Add((i + 1) * 7 + (j + 1));
                        temperaturaSobreUmbral.Add(temperaturasDias[i, j]);
                    }
                }

            }

        }

        #endregion
    }
}
