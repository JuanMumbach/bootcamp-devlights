namespace ActividadModulo3.Operadores
{
    class Profesional : Operador
    {
        int NroMatricula { get; set; }

        public Profesional(string pNombre, int pNroMatricula) : base(pNombre)
        {
            NroMatricula = pNroMatricula;
        }
    }
}
