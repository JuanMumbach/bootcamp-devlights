namespace WeatherForecast
{
    public class EstacionMeteorologica
    {
        public float[] VerTemperaturas(RegistroTemperatura[] pRegistros)
        {
            float[] temperaturas = new float[pRegistros.Length];

            for (int i = 0; i < pRegistros.Length; i++)
            {
                temperaturas[i] = pRegistros[i].Temperatura;
            }

            return temperaturas;
        }

        public float VerTemperaturas(RegistroTemperatura[] pRegistro, int index)
        {
            return pRegistro[index].Temperatura;
        }

        public float[] VerTemperaturas(RegistroTemperatura[] pRegistros, int desde, int hasta)
        {
            float[] temperaturas = new float[pRegistros.Length];

            for (int i = desde; i < hasta; i++)
            {
                temperaturas[i] = pRegistros[i].Temperatura;
            }

            return temperaturas;
        }

        public float[] VerTemperaturas(List<RegistroTemperatura> pRegistros, int desde, int hasta)
        {
            float[] temperaturas = new float[pRegistros.Count];

            for (int i = desde; i < hasta; i++)
            {
                temperaturas[i] = pRegistros[i].Temperatura;
            }

            return temperaturas;
        }


        public float VerTemperaturaPromedio(RegistroTemperatura[] pRegistros)
        {
            return CalculoTemperaturas.CalcularTemperaturaPromedio(pRegistros);
        }

        public float VerTemperaturaPromedio(RegistroTemperatura[] pRegistros, int desde, int hasta)
        {
            return CalculoTemperaturas.CalcularTemperaturaPromedio(VerTemperaturas(pRegistros,desde,hasta));
        }

        public float VerTemperaturaPromedio(List<RegistroTemperatura> pRegistros, int desde, int hasta)
        {
            return CalculoTemperaturas.CalcularTemperaturaPromedio(VerTemperaturas(pRegistros, desde, hasta));
        }


        public List<RegistroTemperatura> RegistrosSombreUmbral(RegistroTemperatura[] pRegistros, float pUmbral)
        {
            List<RegistroTemperatura> registrosSobreUmbral = new List<RegistroTemperatura>();

            foreach (var registro in pRegistros)
            {
                if (registro.Temperatura > pUmbral) registrosSobreUmbral.Add(registro);
            }

            return registrosSobreUmbral;
        }

        public RegistroTemperatura TemperaturaMasBaja(RegistroTemperatura[] pRegistros)
        {
            RegistroTemperatura registroTempBaja = pRegistros[0];

            for (int i = 0; i < pRegistros.Length; i++)
            {
                if (pRegistros[i].Temperatura < registroTempBaja.Temperatura) registroTempBaja = pRegistros[i];
            }

            return registroTempBaja;
        }

        public RegistroTemperatura TemperaturaMasBaja(List<RegistroTemperatura> pRegistros)
        {
            RegistroTemperatura registroTempBaja = pRegistros[0];

            for (int i = 0; i < pRegistros.Count; i++)
            {
                if (pRegistros[i].Temperatura < registroTempBaja.Temperatura) registroTempBaja = pRegistros[i];
            }

            return registroTempBaja;
        }

        public RegistroTemperatura TemperaturaMasAlta(RegistroTemperatura[] pRegistros)
        {
            RegistroTemperatura registroTempAlta = pRegistros[0];

            for (int i = 0; i < pRegistros.Length; i++)
            {
                if (pRegistros[i].Temperatura > registroTempAlta.Temperatura) registroTempAlta = pRegistros[i];
            }
 
            return registroTempAlta;
        }

        public RegistroTemperatura TemperaturaMasAlta(List<RegistroTemperatura> pRegistros)
        {
            RegistroTemperatura registroTempAlta = pRegistros[0];

            for (int i = 0; i < pRegistros.Count; i++)
            {
                if (pRegistros[i].Temperatura > registroTempAlta.Temperatura) registroTempAlta = pRegistros[i];
            }

            return registroTempAlta;
        }
    }
}
