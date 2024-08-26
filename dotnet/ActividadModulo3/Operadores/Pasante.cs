namespace ActividadModulo3.Operadores
{
    class Pasante : Operador
    {
        int NroLegajo { get; set; }

        public Pasante(string pNombre, int pNroLegajo) : base(pNombre)
        {
            NroLegajo = pNroLegajo;
        }
    }
}
