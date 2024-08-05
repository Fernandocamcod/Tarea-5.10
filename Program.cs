using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        const int longitudMinima = 12;
        string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=<>?";

        // Crear una instancia de Random
        Random random = new Random();
        string contrasena;

        do
        {
            contrasena = GenerarContrasena(longitudMinima, caracteres, random);
        } while (!EsContrasenaSegura(contrasena));

        Console.WriteLine($"Contraseña generada: {contrasena}");

        // Mantiene la consola abierta hasta que el usuario presione una tecla
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static string GenerarContrasena(int longitud, string caracteres, Random random)
    {
        StringBuilder contrasena = new StringBuilder();
        for (int i = 0; i < longitud; i++)
        {
            char caracter = caracteres[random.Next(caracteres.Length)];
            contrasena.Append(caracter);
        }
        return contrasena.ToString();
    }

    static bool EsContrasenaSegura(string contrasena)
    {
        return contrasena.Any(char.IsUpper) &&
               contrasena.Any(char.IsLower) &&
               contrasena.Any(char.IsDigit) &&
               contrasena.Any(c => "!@#$%^&*()-_+=<>?.".Contains(c));
    }
}
