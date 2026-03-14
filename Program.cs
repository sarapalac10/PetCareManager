using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Animal> animales = new List<Animal>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n=== SISTEMA DE REFUGIO ===");
            Console.WriteLine("1. Registrar animal");
            Console.WriteLine("2. Mostrar animales");
            Console.WriteLine("3. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":

                    Console.Write("Nombre del animal: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Especie: ");
                    string especie = Console.ReadLine();

                    Animal nuevoAnimal = new Animal(animales.Count + 1, nombre, especie);
                    animales.Add(nuevoAnimal);

                    Console.WriteLine("Animal registrado correctamente.");
                    break;

                case "2":

                    Console.WriteLine("\nAnimales registrados:");

                    foreach (Animal animal in animales)
                    {
                        Console.WriteLine($"ID: {animal.Id} - Nombre: {animal.Nombre} - Especie: {animal.Especie}");
                    }

                    break;

                case "3":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}

