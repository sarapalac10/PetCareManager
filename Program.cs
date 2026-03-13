using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema PetCare Manager ===");

        // Crear un animal
        Animal animal1 = new Animal(1, "Luna", "Perro");

        Console.WriteLine("\nAnimal registrado:");
        Console.WriteLine(animal1.Nombre + " - " + animal1.Especie);

        // Cambiar estado del animal
        animal1.ActualizarEstado("Disponible");

        Console.WriteLine("Estado actual: " + animal1.Estado);

        // Crear adoptante
        Adoptante adoptante1 = new Adoptante(1, "Carlos Pérez", "3001234567");

        Console.WriteLine("\nAdoptante registrado:");
        Console.WriteLine(adoptante1.Nombre);

        // Crear solicitud de adopción
        Adopcion adopcion1 = new Adopcion(1, animal1, adoptante1);

        Console.WriteLine("\nSolicitud de adopción creada.");
        Console.WriteLine("Estado de adopción: " + adopcion1.Estado);

        // Aprobar adopción
        adopcion1.Aprobar();

        Console.WriteLine("\nAdopción aprobada.");
        Console.WriteLine("Nuevo estado del animal: " + animal1.Estado);

        // Registrar historial médico
        RegistroMedico registro1 = new RegistroMedico(
            1,
            animal1,
            "Desparasitación",
            "Medicamento antiparasitario"
        );

        Console.WriteLine("\nRegistro médico creado:");
        Console.WriteLine("Diagnóstico: " + registro1.Diagnostico);

        Console.WriteLine("\n=== Fin de la prueba ===");
    }
}