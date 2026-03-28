using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// Punto de entrada del sistema PetCare Manager.
/// Demuestra herencia, clase abstracta, interfaz y polimorfismo.
/// </summary>
class Program
{
    static List<Animal> animales = new List<Animal>();
    static List<Adoptante> adoptantes = new List<Adoptante>();
    static List<RegistroMedico> registros = new List<RegistroMedico>();

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n╔══════════════════════════════╗");
            Console.WriteLine("║      PETCARE MANAGER         ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.WriteLine("1. Registrar perro");
            Console.WriteLine("2. Registrar gato");
            Console.WriteLine("3. Ver animales");
            Console.WriteLine("4. Ver cuidados por especie");
            Console.WriteLine("5. Actualizar estado de un animal");
            Console.WriteLine("6. Registrar adoptante");
            Console.WriteLine("7. Ver adoptantes");
            Console.WriteLine("8. Crear adopción");
            Console.WriteLine("9. Registrar historial médico");
            Console.WriteLine("10. Ver registros médicos");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarPerro();
                    break;
                case "2":
                    RegistrarGato();
                    break;
                case "3":
                    VerAnimales();
                    break;
                case "4":
                    DescribirCuidados();
                    break;
                case "5":
                    ActualizarEstadoAnimal();
                    break;
                case "6":
                    RegistrarAdoptante();
                    break;
                case "7":
                    VerAdoptantes();
                    break;
                case "8":
                    CrearAdopcion();
                    break;
                case "9":
                    RegistrarHistorialMedico();
                    break;
                case "10":
                    VerRegistrosMedicos();
                    break;
                case "0":
                    continuar = false;
                    Console.WriteLine("\n¡Hasta luego! 🐾");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void RegistrarPerro()
    {
        Console.Write("Nombre del perro: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Sexo: 1. Macho  2. Hembra");
        Console.Write("Seleccione: ");
        string opcionSexo = Console.ReadLine();
        string sexo = opcionSexo == "1" ? "Macho" : "Hembra";

        Console.Write("Edad en años: ");
        int edad = int.Parse(Console.ReadLine());

        animales.Add(new Perro(animales.Count + 1, nombre, sexo, edad));
        Console.WriteLine("✔ Perro registrado.");
    }

    static void RegistrarGato()
    {
        Console.Write("Nombre del gato: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Sexo: 1. Macho  2. Hembra");
        Console.Write("Seleccione: ");
        string opcionSexo = Console.ReadLine();
        string sexo = opcionSexo == "1" ? "Macho" : "Hembra";

        Console.Write("Edad en años: ");
        int edad = int.Parse(Console.ReadLine());

        animales.Add(new Gato(animales.Count + 1, nombre, sexo, edad));
        Console.WriteLine("✔ Gato registrado.");
    }

    static void VerAnimales()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }
        Console.WriteLine("\n--- Animales en el refugio ---");
        foreach (var a in animales)
            Console.WriteLine($"[{a.Id}] {a.Nombre} | {a.Especie} | {a.Sexo} | {a.Edad} años | Estado: {a.Estado}");
    }

    static void ActualizarEstadoAnimal()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }

        VerAnimales();
        Console.Write("Ingrese el ID del animal: ");
        int id = int.Parse(Console.ReadLine());

        Animal animal = animales.Find(a => a.Id == id);
        if (animal == null) { Console.WriteLine("ID inválido."); return; }

        Console.WriteLine("\nSeleccione el nuevo estado:");
        Console.WriteLine("1. En observación");
        Console.WriteLine("2. En tratamiento");
        Console.WriteLine("3. Disponible");
        Console.WriteLine("4. Adoptado");
        Console.Write("Seleccione: ");
        string opcion = Console.ReadLine();

        string nuevoEstado = opcion switch
        {
            "1" => "En observación",
            "2" => "En tratamiento",
            "3" => "Disponible",
            "4" => "Adoptado",
            _ => null
        };

        if (nuevoEstado == null)
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        animal.ActualizarEstado(nuevoEstado);
        Console.WriteLine($"✔ Estado de {animal.Nombre} actualizado a: {nuevoEstado}");
    }

    static void DescribirCuidados()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }
        Console.WriteLine("\n--- Cuidados por especie ---");
        foreach (var a in animales)
            a.DescribirCuidados(); // ← MISMO MÉTODO, DIFERENTE COMPORTAMIENTO
    }

    static void RegistrarAdoptante()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string tel = Console.ReadLine();
        Console.Write("Dirección: ");
        string dir = Console.ReadLine();

        adoptantes.Add(new Adoptante(adoptantes.Count + 1, nombre, tel, dir));
        Console.WriteLine("✔ Adoptante registrado.");
    }

    static void VerAdoptantes()
    {
        if (adoptantes.Count == 0) { Console.WriteLine("No hay adoptantes registrados."); return; }
        Console.WriteLine("\n--- Adoptantes ---");
        foreach (var ad in adoptantes)
            ad.MostrarInfo(); // ← INTERFAZ IRegistrable
    }

    static void CrearAdopcion()
    {
        if (animales.Count == 0 || adoptantes.Count == 0)
        {
            Console.WriteLine("Debe haber al menos un animal y un adoptante registrados.");
            return;
        }

        VerAnimales();
        Console.Write("Ingrese el ID del animal: ");
        int idAnimal = int.Parse(Console.ReadLine());

        VerAdoptantes();
        Console.Write("Ingrese el ID del adoptante: ");
        int idAdoptante = int.Parse(Console.ReadLine());

        Animal animal = animales.Find(a => a.Id == idAnimal);
        Adoptante adoptante = adoptantes.Find(a => a.Id == idAdoptante);

        if (animal == null || adoptante == null)
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Adopcion adopcion = new Adopcion(1, animal, adoptante);
        Console.Write("¿Aprobar adopción? (s/n): ");
        string respuesta = Console.ReadLine();

        if (respuesta?.ToLower() == "s")
            adopcion.Aprobar();
        else
            adopcion.Rechazar();
    }

    static void RegistrarHistorialMedico()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }

        VerAnimales();
        Console.Write("Ingrese el ID del animal: ");
        int id = int.Parse(Console.ReadLine());

        Animal animal = animales.Find(a => a.Id == id);
        if (animal == null) { Console.WriteLine("ID inválido."); return; }

        Console.Write("Diagnóstico: ");
        string dx = Console.ReadLine();
        Console.Write("Tratamiento: ");
        string tx = Console.ReadLine();

        registros.Add(new RegistroMedico(registros.Count + 1, animal, dx, tx));
        Console.WriteLine("✔ Registro médico guardado.");
    }

    static void VerRegistrosMedicos()
    {
        if (registros.Count == 0) { Console.WriteLine("No hay registros médicos."); return; }
        Console.WriteLine("\n--- Historial Médico ---");
        foreach (var r in registros)
            r.MostrarRegistro();
    }
}