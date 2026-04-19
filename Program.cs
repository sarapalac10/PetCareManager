using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Punto de entrada del sistema PetCare Manager.
/// Demuestra herencia, clase abstracta, interfaz y polimorfismo.
/// </summary>
class Program
{
    static List<Animal> animales = new List<Animal>();
    static List<Adoptante> adoptantes = new List<Adoptante>();
    static List<RegistroMedico> registros = new List<RegistroMedico>();
    static List<Adopcion> adopciones = new List<Adopcion>();

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

            string? opcion = Console.ReadLine();

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

    /// <summary>
    /// Lee una línea de consola y la devuelve como texto no vacío,
    /// o null si el usuario dejó la entrada vacía.
    /// </summary>
    static string? LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        string? valor = Console.ReadLine();
        return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
    }

    /// <summary>
    /// Lee un entero no negativo desde consola, validando el formato.
    /// Devuelve true si la lectura fue exitosa.
    /// </summary>
    static bool LeerEntero(string mensaje, out int valor)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();
        if (!int.TryParse(entrada, out valor) || valor < 0)
        {
            Console.WriteLine("✖ Valor numérico inválido.");
            valor = 0;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Solicita el sexo del animal y lo valida.
    /// </summary>
    static bool LeerSexo(out string sexo)
    {
        Console.WriteLine("Sexo: 1. Macho  2. Hembra");
        string? opcion = LeerTexto("Seleccione: ");
        switch (opcion)
        {
            case "1": sexo = "Macho"; return true;
            case "2": sexo = "Hembra"; return true;
            default:
                Console.WriteLine("✖ Opción de sexo inválida.");
                sexo = "";
                return false;
        }
    }

    static void RegistrarPerro()
    {
        string? nombre = LeerTexto("Nombre del perro: ");
        if (nombre == null) { Console.WriteLine("✖ El nombre no puede estar vacío."); return; }

        if (!LeerSexo(out string sexo)) return;
        if (!LeerEntero("Edad en años: ", out int edad)) return;

        animales.Add(new Perro(animales.Count + 1, nombre, sexo, edad));
        Console.WriteLine("✔ Perro registrado.");
    }

    static void RegistrarGato()
    {
        string? nombre = LeerTexto("Nombre del gato: ");
        if (nombre == null) { Console.WriteLine("✖ El nombre no puede estar vacío."); return; }

        if (!LeerSexo(out string sexo)) return;
        if (!LeerEntero("Edad en años: ", out int edad)) return;

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
        if (!LeerEntero("Ingrese el ID del animal: ", out int id)) return;

        Animal? animal = animales.Find(a => a.Id == id);
        if (animal == null) { Console.WriteLine("✖ ID inválido."); return; }

        Console.WriteLine("\nSeleccione el nuevo estado:");
        Console.WriteLine("1. En observación");
        Console.WriteLine("2. En tratamiento");
        Console.WriteLine("3. Disponible");
        Console.WriteLine("4. Adoptado");
        string? opcion = LeerTexto("Seleccione: ");

        EstadoAnimal? nuevoEstado = opcion switch
        {
            "1" => EstadoAnimal.EnObservacion,
            "2" => EstadoAnimal.EnTratamiento,
            "3" => EstadoAnimal.Disponible,
            "4" => EstadoAnimal.Adoptado,
            _ => null
        };

        if (nuevoEstado == null)
        {
            Console.WriteLine("✖ Opción inválida.");
            return;
        }

        animal.ActualizarEstado(nuevoEstado.Value);
        Console.WriteLine($"✔ Estado de {animal.Nombre} actualizado a: {nuevoEstado}");
    }

    /// <summary>
    /// Muestra los cuidados agrupados por especie, usando un representante
    /// de cada una para ilustrar el polimorfismo de DescribirCuidados.
    /// </summary>
    static void DescribirCuidados()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }

        Console.WriteLine("\n--- Cuidados por especie ---");
        var porEspecie = animales
            .GroupBy(a => a.Especie)
            .Select(g => g.First());

        foreach (var representante in porEspecie)
        {
            Console.WriteLine($"\nEspecie: {representante.Especie}");
            representante.DescribirCuidados();
        }
    }

    static void RegistrarAdoptante()
    {
        string? nombre = LeerTexto("Nombre: ");
        if (nombre == null) { Console.WriteLine("✖ El nombre no puede estar vacío."); return; }

        string? tel = LeerTexto("Teléfono: ");
        if (tel == null) { Console.WriteLine("✖ El teléfono no puede estar vacío."); return; }

        string? dir = LeerTexto("Dirección: ");
        if (dir == null) { Console.WriteLine("✖ La dirección no puede estar vacía."); return; }

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
        if (!LeerEntero("Ingrese el ID del animal: ", out int idAnimal)) return;

        VerAdoptantes();
        if (!LeerEntero("Ingrese el ID del adoptante: ", out int idAdoptante)) return;

        Animal? animal = animales.Find(a => a.Id == idAnimal);
        Adoptante? adoptante = adoptantes.Find(a => a.Id == idAdoptante);

        if (animal == null || adoptante == null)
        {
            Console.WriteLine("✖ ID inválido.");
            return;
        }

        Adopcion adopcion = new Adopcion(adopciones.Count + 1, animal, adoptante);
        adopciones.Add(adopcion);

        string? respuesta = LeerTexto("¿Aprobar adopción? (s/n): ");
        if (respuesta?.ToLower() == "s")
            adopcion.Aprobar();
        else
            adopcion.Rechazar();
    }

    static void RegistrarHistorialMedico()
    {
        if (animales.Count == 0) { Console.WriteLine("No hay animales registrados."); return; }

        VerAnimales();
        if (!LeerEntero("Ingrese el ID del animal: ", out int id)) return;

        Animal? animal = animales.Find(a => a.Id == id);
        if (animal == null) { Console.WriteLine("✖ ID inválido."); return; }

        string? dx = LeerTexto("Diagnóstico: ");
        if (dx == null) { Console.WriteLine("✖ El diagnóstico no puede estar vacío."); return; }

        string? tx = LeerTexto("Tratamiento: ");
        if (tx == null) { Console.WriteLine("✖ El tratamiento no puede estar vacío."); return; }

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
