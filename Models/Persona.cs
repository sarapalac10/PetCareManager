using System;

/// <summary>
/// Clase base que representa a una persona en el sistema.
/// Contiene los atributos comunes a cualquier persona registrada.
/// </summary>
public class Persona
{
    private int id;
    private string nombre = null!;
    private string telefono = null!;

    /// <summary>
    /// Identificador único de la persona.
    /// </summary>
    public int Id { get { return id; } }

    /// <summary>
    /// Nombre completo de la persona.
    /// </summary>
    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");
            nombre = value;
        }
    }

    /// <summary>
    /// Teléfono de contacto de la persona.
    /// </summary>
    public string Telefono
    {
        get { return telefono; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El teléfono no puede estar vacío.");
            telefono = value;
        }
    }

    /// <summary>
    /// Constructor de la clase Persona.
    /// </summary>
    public Persona(int id, string nombre, string telefono)
    {
        this.id = id;
        Nombre = nombre;
        Telefono = telefono;
    }
}
