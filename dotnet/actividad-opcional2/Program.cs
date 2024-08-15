#region Variables globales
#endregion

#region Programa Principal
/*
Ejercicio1();
Ejercicio2();
Ejercicio3();
Ejercicio5();
Ejercicio7();
*/
Ejercicio8();
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

void Ejercicio7()
{
    int[,] tablaMultiplicar = new int[10, 10];

    for (int i = 0; i < tablaMultiplicar.GetLength(0); i++)
    {
        for(int j = 0; j < tablaMultiplicar.GetLength(1); j++)
        {
            tablaMultiplicar[i, j] = (i+1) * (j+1);
        }
    }

    for (int i = 0; i < tablaMultiplicar.GetLength(0); i++)
    {
        for (int j = 0; j < tablaMultiplicar.GetLength(1); j++)
        {
            Console.Write(tablaMultiplicar[i, j] + "\t");
        }
        Console.Write("\n");
    }
}

void Ejercicio8()
{
    //crea matriz 10x10
    bool[,] matrizX = new bool[10, 10];

    //esconde las X
    int cantidadX = 5;

    Random random = new Random();
    for (int i = 0; i < cantidadX;i++)
    {
        bool lugarLibre = false;

        while(!lugarLibre)
        {
            int posX = random.Next(0, 9);
            int posY = random.Next(0, 9);

            if (!matrizX[posX, posY])
            {
                lugarLibre = true;
                matrizX[posX, posY] = true;
            }
        }
        
    }
    
    //bucle del juego
    int vidas = 3;
    int intentos = cantidadX;

    List<int> encontradaFila = new List<int>();
    List<int> encontradaColumna = new List<int>();

    while(intentos > 0 && vidas > 0)
    {
        Console.Clear();
        Console.WriteLine($"Encuentra las {cantidadX} 'X' escondidas en la matriz:");
        for(int i = 0; i < matrizX.GetLength(0);i++)
        {
            for (int j = 0; j < matrizX.GetLength(0); j++)
            {
                Console.Write("?\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Has encontrado {encontradaFila.Count} de {cantidadX}:");
        for(int i = 0;i < encontradaFila.Count;i++)
        {
            Console.WriteLine($"En la fila {encontradaFila[i]} columna {encontradaColumna[i]}.");
        }

        Console.WriteLine("Encuentra la siguiente X");
        Console.WriteLine("Ingrese una fila del 1 al 10:");

        if (int.TryParse(Console.ReadLine(),out int nuevaFila) && nuevaFila > 0 && nuevaFila <= 10)
        {
            Console.WriteLine("Ingrese una columna del 1 al 10:");
            if (int.TryParse(Console.ReadLine(), out int nuevaColumna) && nuevaColumna > 0 && nuevaColumna <= 10)
            {
                if (matrizX[nuevaFila,nuevaColumna])
                {
                    Console.WriteLine("Haz encontrado una X!");
                    intentos--;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("No hay una X ahí...");
                    Console.ReadLine();
                    intentos--;
                    vidas--;
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("La columna ingresada no es válida.");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("La fila ingresada no es válida.");
            Console.ReadLine();
        }

    }

    //mostrar matriz final

    Console.WriteLine("Juego terminado.\n\n");
    if (vidas > 0) Console.WriteLine("Haz encontrado todas las X!!!");
    Console.WriteLine("Matriz final:");

    for (int i = 0; i < matrizX.GetLength(0); i++)
    {
        for (int j = 0; j < matrizX.GetLength(0); j++)
        {
            if (matrizX[i,j]) Console.Write("X\t"); else Console.Write("*\t");
        }
        Console.WriteLine();
    }
}
#endregion
