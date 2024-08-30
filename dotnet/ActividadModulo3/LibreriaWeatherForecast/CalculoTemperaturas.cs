
using Microsoft.Win32;

namespace WeatherForecast
{
    public static class CalculoTemperaturas
    {
        public static float CalcularTemperaturaPromedio(RegistroTemperatura[] pRegistro)
        {
            float sumatoria = 0;
            foreach (var registro in pRegistro)
            {
                sumatoria += registro.Temperatura;
            }

            return sumatoria/pRegistro.Length;
        }

        public static float CalcularTemperaturaPromedio(float[] pTemperaturas)
        {
            float sumatoria = 0;
            foreach (var temperatura in pTemperaturas)
            {
                sumatoria += temperatura;
            }

            return sumatoria / pTemperaturas.Length;
        }
    }
}
