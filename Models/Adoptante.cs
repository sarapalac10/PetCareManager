using System;

/// <summary>
/// Representa una persona interesada en adoptar un animal.
/// Hereda los atributos comunes de Persona e implementa IRegistrable.
/// </summary>
public class Adoptante : Persona, IRegistrable
{
    /// <summary>
    /// Dirección de residencia del adoptante.
    /// </summary>
    public string Direccion { get; set; }

    /// <summary>
    /// Constructor de la clase Adoptante.
    /// Llama al constructor de Persona con "base".
    /// </summary>
    public Adoptante(int id, string nombre, string telefono, string direccion)
        : base(id, nombre, telefono)
    {
        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("La dirección no puede estar vacía.");
        Direccion = direccion;
    }

    /// <summary>
    /// Muestra la información del adoptante en consola.
    /// Implementación de la interfaz IRegistrable.
    /// </summary>
    public void MostrarInfo()
    {
        Console.WriteLine($"Adoptante #{Id}: {Nombre} | Tel: {Telefono} | Dir: {Direccion}");
    }
}