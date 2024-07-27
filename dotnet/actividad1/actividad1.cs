#region variables globales
bool repetirBuclePrograma = true;
#endregion

#region Main
while (repetirBuclePrograma)
{
    ConsultarChaqueta();

    ConsultarPronosticoExtendido();

    ConsultarFinPrograma();
}
#endregion

#region Funciones
void ConsultarChaqueta()
{
    Console.WriteLine("Ingrese la temperatura (en grados celcius):");

    if (float.TryParse(Console.ReadLine(), out float temperatura))
    {
        switch (temperatura)
        {
            case < 0:
                Console.WriteLine("Hace mucho frío afuera, asegúrate de abrigarte bien.");
                break;
            case <= 20:
                Console.WriteLine("El clima está fresco, una chaqueta ligera sería perfecta.");
                break;
            case > 20:
                Console.WriteLine("Hace calor afuera, no necesitas una chaqueta.");
                break;
            default:
                Console.WriteLine("La temperatura ingresada no es un valor valido.");
                break;
        }
    }
    else
    {
        Console.WriteLine("La temperatura ingresada no es un valor valido.");
    }

}

void ConsultarPronosticoExtendido()
{
    Console.WriteLine("Desea saber el pronostico para los proximos 5 dias? responder 'y' (si)  o 'n' (no):");
    string? extenderPronostico = Console.ReadLine();

    if (extenderPronostico != null)
    {
        if (extenderPronostico == "y" || extenderPronostico == "Y")
        {
            Console.WriteLine("Pronostico extendido:" +
                "Lunes: soleado." +
                "Martes: algunas nubes." +
                "Miercoles: Soleado." +
                "Jueves: nublado." +
                "Viernes: Lluvia.");
        }
        else
        {
            if (extenderPronostico != "n" && extenderPronostico != "N")
            {
                Console.WriteLine("La respuesta ingresada no es válida. Debe responder 'y' o 'n' sin las comillas.");
            }
        }
    }
    else
    {
        Console.WriteLine("Hubo un error al leer el input del usuario");
    }

}

void ConsultarFinPrograma()
{
    Console.WriteLine("Desea consultar otra pronostico? y/n:");
    string? otraConsulta = Console.ReadLine();
    repetirBuclePrograma = false;

    if (otraConsulta != null)
    {
        if (otraConsulta == "y" || otraConsulta == "Y")
        {
            repetirBuclePrograma = true;
        }
        else
        {
            if (otraConsulta == "n" || otraConsulta == "N")
            {
                Console.WriteLine("Cerrando programa pronostico.");
            }
            else
            {
                Console.WriteLine("Respuesta invalida.");
            }

        }
    }
    else
    {
        Console.WriteLine("Hubo un error al leer el input del usuario");
    }
}
#endregion