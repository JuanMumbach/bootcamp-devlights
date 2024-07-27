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
            Ejercicio1();
        }

        #region funciones (ejercicios)
        static void Ejercicio1()
        {
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
        #endregion
    }
}
