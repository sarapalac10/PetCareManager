using System;

/// <summary>
/// Representa una persona interesada en adoptar un animal.
/// </summary>
public class Adoptante
{
    private int id;
    private string nombre;
    private string telefono;

    /// <summary>
    /// Identificador único del adoptante.
    /// </summary>
    public int Id { get { return id; } }

    /// <summary>
    /// Nombre completo del adoptante.
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
    /// Teléfono de contacto del adoptante.
    /// </summary>
    public string Telefono { get; set; }

    /// <summary>
    /// Constructor de la clase Adoptante.
    /// </summary>
    public Adoptante(int id, string nombre, string telefono)
    {
        this.id = id;
        Nombre = nombre;
        Telefono = telefono;
    }
}