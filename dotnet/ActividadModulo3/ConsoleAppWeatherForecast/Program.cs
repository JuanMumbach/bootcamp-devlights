using WeatherForecast;
using WeatherForecast.Operadores;

#region variables globales
List<Operador> operadores = new List<Operador>();
List<List<RegistroTemperatura>> registrosDias = new List<List<RegistroTemperatura>>();
List<List<Operador>> turnosOperadores = new List<List<Operador>>();

EstacionMeteorologica meteorologica = new EstacionMeteorologica();

int dias = 30;
int turnosPorDia = 8;
int horaInicioDia = 8;

//parametros simulador de registros
float temperaturaMinima = -10;
float temperaturaMaxima = 45;
float maximaDiferenciaDiaAnterior = 5;
#endregion

#region Programa Principal
InicializarOperadores();
InicializarTurnos();
SimularRegistros();
Console.WriteLine("\nPresione enter/entrar para continuar...");
Console.ReadLine();
MenuOpciones();

#endregion

#region Funciones
void InicializarOperadores()
{
    Console.Write("\nRegistrando Operadores...");
    operadores.Add(new Profesional("Andres Fernando Leal", 004862));
    operadores.Add(new Profesional("Miguel Hernandez", 112698));
    operadores.Add(new Pasante("Jorge Gonzales", 147));
    operadores.Add(new Profesional("Daiana Fretes", 156231));
    operadores.Add(new Pasante("Maria Villagra", 508));
    operadores.Add(new Pasante("Alicia Martinez", 920));
    Console.WriteLine("\tfinalizado.");
}

void InicializarTurnos()
{
    Console.Write("\nGenerando turnos para los operadores...");
    Random rnd = new Random();
    bool ultimoFuePasante = false;
    for (int i = 0; i < dias; i++)
    {
        turnosOperadores.Add(new List<Operador>());
        for (int j = 0; j < turnosPorDia; j++)
        {
            int operadorSeleccionado = 0;
            bool operadorCorrecto = false;
            while (!operadorCorrecto)
            {

                operadorSeleccionado = rnd.Next(operadores.Count);
                if (ultimoFuePasante && (operadores[operadorSeleccionado] is Profesional) || !ultimoFuePasante && (operadores[operadorSeleccionado] is Pasante))
                {
                    operadorCorrecto = true;
                    if (operadores[operadorSeleccionado] is Profesional)
                    {
                        ultimoFuePasante = false;
                    }
                    else
                    {
                        ultimoFuePasante = true;
                    }
                }
            }

            turnosOperadores[i].Add(operadores[operadorSeleccionado]);
        }
    }
    Console.WriteLine("\tfinalizado.");
}

void SimularRegistros()
{
    Console.Write($"\nSimulando registros meteorologicos de los ultimos {dias} dias...");
    Random rnd = new Random();

    float temperatura = temperaturaMinima + ((float)rnd.NextDouble() * (temperaturaMaxima - temperaturaMinima));

    DateOnly fechaInicial = DateOnly.FromDateTime(DateTime.Now);
    fechaInicial = fechaInicial.AddDays(-dias);

    for (int i = 0; i < dias; i++)
    {
        registrosDias.Add(new List<RegistroTemperatura>());
        for (int j = 0; j < turnosPorDia; j++)
        {
            temperatura = Math.Clamp(temperaturaMinima + ((float)rnd.NextDouble() * (temperaturaMaxima - temperaturaMinima)), temperatura - maximaDiferenciaDiaAnterior, temperatura + maximaDiferenciaDiaAnterior);

            DateOnly fecha = fechaInicial;
            fecha = fecha.AddDays(i);
            TimeOnly Hora = new TimeOnly(horaInicioDia + j, rnd.Next(60));

            RegistroTemperatura nuevoRegistro = new RegistroTemperatura(
                float.Parse(string.Format("{0:0.#}", temperatura)),
                turnosOperadores[i][j],
                fecha,
                Hora);

            registrosDias[i].Add(nuevoRegistro);
        }
    }
    Console.WriteLine("\tfinalizado.");
}

void MenuOpciones()
{
    bool salir = false;
    while(!salir)
    {
        Console.Clear();
        Console.WriteLine("\t\t Weather Forecast");
        Console.WriteLine("Ingrese una opcion para continuar:");
        Console.WriteLine("0 - consultar registro especifico");
        Console.WriteLine("1 - consultar temperatura promedio de varios dias");
        Console.WriteLine("2 - consultar temperatura más alta de varios dias");
        Console.WriteLine("3 - consultar temperatura más baja de varios dias");
        Console.WriteLine("4 - Salir de Weather Forecast");

        if (!int.TryParse(Console.ReadLine(), out int respuesta))
        {
            Console.WriteLine("Valor ingresado incorrecto. Presione entrar/enter para continuar...");
            Console.ReadLine();
            return;
        }

        switch (respuesta)
        {
            case 0:
                ConsultarRegistro();
                break;
            case 1:
                ConsultarTemperaturaPromedio();
                break;
            case 2:
                ConsultarTemperaturaMasAlta();
                break;
            case 3:
                ConsultarTemperaturaMasBaja();
                break;
            case 4:
                salir = true;
                Console.WriteLine("Saliendo de Weather Forecast...");
                break;
            default:
                Console.WriteLine("Respuesta no válida, presione entrar/enter para reintentar...");
                Console.ReadLine();
                break;
        }
        
    }
}

void ConsultarRegistro()
{
    Console.Clear();
    Console.WriteLine($"¿De que dia desea consultar el registro?\nIngrese un numero del 1 al {dias}:");

    if (!int.TryParse(Console.ReadLine(), out int diaIngresado))
    {
        Console.WriteLine("Dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine($"¿De que turno desea consultar el registro?\nIngrese un numero del 1 al {turnosPorDia}:");
    if (!int.TryParse(Console.ReadLine(), out int turnoIngresado))
    {
        Console.WriteLine("Turno ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    RegistroTemperatura registroObtenido = registrosDias[diaIngresado-1][turnoIngresado-1];
    if (registroObtenido != null)
    {
        Console.Clear();
        Console.WriteLine($"Registro del dia {diaIngresado}, turno {turnoIngresado}:");
        Console.WriteLine($"Temperatura: {registroObtenido.Temperatura}");
        Console.WriteLine($"Fecha: {registroObtenido.Fecha.ToString()}");
        Console.WriteLine($"Hora: {registroObtenido.Hora.ToString()}");
        Console.WriteLine($"Ingresado por: {registroObtenido.CargadoPor.Nombre} ({((registroObtenido.CargadoPor is Pasante) ? "pasante"  : "profesional")})");

        Console.WriteLine("Presione entrar/enter para continuar...");
        Console.ReadLine();
    }
    
}

void ConsultarTemperaturaPromedio()
{
    Console.Clear();
    
    Console.WriteLine($"Desde que dia desea conocer la temperatura promedio? Ingrese un numero del 1 al {dias}");
    
    if (!int.TryParse(Console.ReadLine(), out int desde) || desde < 1 || desde > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine($"Hasta que dia desea conocer la temperatura promedio? Ingrese un numero del 1 al {dias}");

    if (!int.TryParse(Console.ReadLine(), out int hasta) || hasta < 1 || hasta > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    List<RegistroTemperatura> registrosApromediar = new List<RegistroTemperatura>();

    for (int i = desde-1; i < hasta; i++)
    {
        for (int j = 0;   j < registrosDias[i].Count; j++)
        {
            registrosApromediar.Add(registrosDias[i][j]);
        }
    }

    float temperaturaPromedio = meteorologica.VerTemperaturaPromedio(registrosApromediar,desde,hasta);

    Console.WriteLine($"La temperatura promedio desde el dia {desde} hasta el dia {hasta} es de {temperaturaPromedio} grados.");
    Console.WriteLine("Presion entrar/enter para continuar...");
    Console.ReadLine();
}

void ConsultarTemperaturaMasAlta()
{
    Console.Clear();

    Console.WriteLine($"Desde que dia desea conocer la temperatura mas alta? Ingrese un numero del 1 al {dias}");

    if (!int.TryParse(Console.ReadLine(), out int desde) || desde < 1 || desde > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine($"Hasta que dia desea conocer la temperatura mas alta? Ingrese un numero del 1 al {dias}");

    if (!int.TryParse(Console.ReadLine(), out int hasta) || hasta < 1 || hasta > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    List<RegistroTemperatura> registrosApromediar = new List<RegistroTemperatura>();

    for (int i = desde - 1; i < hasta; i++)
    {
        for (int j = 0; j < registrosDias[i].Count; j++)
        {
            registrosApromediar.Add(registrosDias[i][j]);
        }
    }

    float temperaturaAlta = meteorologica.TemperaturaMasAlta(registrosApromediar).Temperatura;

    Console.WriteLine($"La temperatura mas alta desde el dia {desde} hasta el dia {hasta} es de {temperaturaAlta} grados.");
    Console.WriteLine("Presion entrar/enter para continuar...");
    Console.ReadLine();
}

void ConsultarTemperaturaMasBaja()
{
    Console.Clear();

    Console.WriteLine($"Desde que dia desea conocer la temperatura mas baja? Ingrese un numero del 1 al {dias}");

    if (!int.TryParse(Console.ReadLine(), out int desde) || desde < 1 || desde > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    Console.WriteLine($"Hasta que dia desea conocer la temperatura mas baja? Ingrese un numero del 1 al {dias}");

    if (!int.TryParse(Console.ReadLine(), out int hasta) || hasta < 1 || hasta > dias)
    {
        Console.WriteLine("dia ingresado incorrecto. Presione entrar/enter para continuar...");
        Console.ReadLine();
        return;
    }

    List<RegistroTemperatura> registrosApromediar = new List<RegistroTemperatura>();

    for (int i = desde - 1; i < hasta; i++)
    {
        for (int j = 0; j < registrosDias[i].Count; j++)
        {
            registrosApromediar.Add(registrosDias[i][j]);
        }
    }

    float temperaturaBaja = meteorologica.TemperaturaMasBaja(registrosApromediar).Temperatura;

    Console.WriteLine($"La temperatura mas baja desde el dia {desde} hasta el dia {hasta} es de {temperaturaBaja} grados.");
    Console.WriteLine("Presion entrar/enter para continuar...");
    Console.ReadLine();
}
#endregion