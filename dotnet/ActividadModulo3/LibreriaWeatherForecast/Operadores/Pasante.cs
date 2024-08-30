namespace WeatherForecast.Operadores
{
    public class Pasante : Operador
    {
        public int NroLegajo { get;private set; }

        public Pasante(string pNombre, int pNroLegajo) : base(pNombre)
        {
            NroLegajo = pNroLegajo;
        }
    }
}
