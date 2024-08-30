using WeatherForecast.Operadores;

namespace WeatherForecast
{
    public class RegistroTemperatura
    {
        public float Temperatura { get ; private set; }
        public Operador CargadoPor { get; private set; }
        public DateOnly Fecha {  get;private set; }
        public TimeOnly Hora {  get;private set; }
        
        public RegistroTemperatura(float pTemperatura,Operador pCargadoPor,DateOnly pFecha,TimeOnly pHora)
        {
            this.Temperatura = pTemperatura;
            this.CargadoPor = pCargadoPor;
            this.Fecha = pFecha;
            this.Hora = pHora;
        }
    }
}
