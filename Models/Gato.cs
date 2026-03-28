using System;

/// <summary>
/// Representa un gato registrado en el refugio.
/// Hereda de Animal e implementa EmitirSonido.
/// </summary>
public class Gato : Animal
{
    /// <summary>
    /// Constructor del Gato. La especie se asigna automáticamente.
    /// </summary>
    public Gato(int id, string nombre)
        : base(id, nombre, "Gato")
    {
    }

    /// <summary>
    /// Describe los cuidados específicos que necesita un gato. (Polimorfismo)
    /// </summary>
    public override void DescribirCuidados()
    {
        Console.WriteLine($"🐱 {Nombre} necesita:");
        Console.WriteLine("   - Arenero limpio y espacio para explorar");
        Console.WriteLine("   - Enriquecimiento ambiental (juguetes, rascadores)");
        Console.WriteLine("   - Revisión veterinaria periódica");
    }
}