using System.Diagnostics;

namespace ActividadModulo2
{
    internal class Program
    {
        #region Variables globales
        static int[,] temperaturasDias = new int[5,7];

        static float[] promedioSemanas = new float[5];

        static List<float> sobreUmbral = new List<float>();

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
        
        }

        static void MostrarTemperaturasPromedioSemanales()
        {
            CalcularTemperaturasPromedio();
        }

        static void ConsultarTemperaturaPromedioMes()
        {

        }

        static void MostrarTemperaturasSobreUmbral()
        {
            BuscarTemperaturasSobreUmbral();
        }

        static void ConsultarTemperaturaMasAlta()
        {
        }

        static void ConsultarTemperaturaMasBaja()
        {
        }

        static void Consultar5diasSiguienteMes()
        {
        }
        #endregion

        #region Funciones Auxiliares
        static void CalcularTemperaturasPromedio() { }

        static void BuscarTemperaturasSobreUmbral() { }

        #endregion
    }
}
