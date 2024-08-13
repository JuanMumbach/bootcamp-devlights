#region Variables globales
#endregion

#region Programa Principal
//Ejercicio1();
//Ejercicio2();
Ejercicio3();
Ejercicio5();
#endregion

#region Funciones / ejericicios
void Ejercicio1()
{
    List<float> notas = new List<float>([ 7, 8, 4, 9, 5, 4, 6, 8, 7, 9 ]);

    Console.WriteLine("Notas del alumno:");

    float sumatoria = 0;
    for (int i = 0; i < notas.Count; i++)
    {
        Console.WriteLine(notas[i]);
        sumatoria += notas[i];
    }
    float promedio = sumatoria / notas.Count;

    Console.WriteLine($"\nPromedio: {promedio}");
}

void Ejercicio2()
{
    List<int> edades = new List<int>([7, 28, 34, 19, 5, 14, 36, 48, 67, 19,24,78,10,33,3,57,48,21,82,40]);

    int menores = 0;
    int mayores = 0;
    for (int i = 0; i < edades.Count; i++)
    {
        if (edades[i] < 18) menores++; else mayores++;
    }

    Console.WriteLine($"Hay {menores} menores de edad y {mayores} mayores.");
}

void Ejercicio3()
{
    List<string> nombres = new List<string>(["Jorge","Pedro","Facundo","Emilio","Joan","Homero","Geronimo","Evaristo","Abelardo"]);

    int nombreCortoIndex = 0;
    int nombreCortoLong = nombres[0].Length;
    int nombreLargoIndex = 0;
    int nombreLargoLong = nombres[0].Length;
    for (int i = 0; i < nombres.Count; i++)
    {
        if (nombres[i].Length > nombreLargoLong)
        {
            nombreLargoLong = nombres[i].Length;
            nombreLargoIndex = i;
        }

        if (nombres[i].Length < nombreCortoLong)
        {
            nombreCortoLong = nombres[i].Length;
            nombreCortoIndex = i;
        }
    }

    Console.WriteLine($"El nombre más corto es '{nombres[nombreCortoIndex]}' y el nombre más largo es '{nombres[nombreLargoIndex]}'.");
}

void Ejercicio4()
{

}

void Ejercicio5()
{
    char[,] matriz = new char[5, 5];

    for (int i = 0;i < matriz.GetLength(0);i++)
    {
        for (int j = 0;j < matriz.GetLength(1);j++)
        {
            if ((i + j) % 2 == 0) matriz[i, j] = 'P'; else matriz[i, j] = 'I';
            Console.Write($" {matriz[i, j]} ");
        }
        Console.Write("\n");
    }
}
#endregion
