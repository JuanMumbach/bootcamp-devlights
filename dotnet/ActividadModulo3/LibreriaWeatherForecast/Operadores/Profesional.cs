namespace WeatherForecast.Operadores
{
    public class Profesional : Operador
    {
        public int NroMatricula { get;private set; }

        public Profesional(string pNombre, int pNroMatricula) : base(pNombre)
        {
            NroMatricula = pNroMatricula;
        }
    }
}
