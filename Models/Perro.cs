using System;

/// <summary>
/// Representa un perro registrado en el refugio.
/// Hereda de Animal e implementa EmitirSonido.
/// </summary>
public class Perro : Animal
{
    /// <summary>
    /// Constructor del Perro. La especie se asigna automáticamente.
    /// </summary>
    public Perro(int id, string nombre)
        : base(id, nombre, "Perro")
    {
    }

    /// <summary>
    /// Describe los cuidados específicos que necesita un perro. (Polimorfismo)
    /// </summary>
    public override void DescribirCuidados()
    {
        Console.WriteLine($"🐶 {Nombre} necesita:");
        Console.WriteLine("   - Paseos diarios (mínimo 2 veces al día)");
        Console.WriteLine("   - Socialización con personas y otros perros");
        Console.WriteLine("   - Vacunación anual y desparasitación");
    }
}