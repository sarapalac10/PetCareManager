using System;

/// <summary>
/// Clase abstracta que representa un animal en el refugio.
/// No se puede instanciar directamente — es la base para Perro, Gato, etc.
/// </summary>
public abstract class Animal
{
    private int id;
    private string nombre;
    private string estado;

    /// <summary>
    /// Identificador único del animal.
    /// </summary>
    public int Id { get { return id; } }

    /// <summary>
    /// Nombre del animal.
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
    /// Especie del animal (definida por cada clase hija).
    /// </summary>
    public string Especie { get; protected set; }

    /// <summary>
    /// Estado actual del animal dentro del refugio.
    /// </summary>
    public string Estado
    {
        get { return estado; }
        private set { estado = value; }
    }

    /// <summary>
    /// Fecha de ingreso del animal al refugio.
    /// </summary>
    public DateTime FechaIngreso { get; private set; }

    /// <summary>
    /// Constructor de la clase abstracta Animal.
    /// </summary>
    public Animal(int id, string nombre, string especie)
    {
        this.id = id;
        Nombre = nombre;
        Especie = especie;
        Estado = "En observación";
        FechaIngreso = DateTime.Now;
    }

    /// <summary>
    /// Actualiza el estado del animal en el refugio.
    /// </summary>
    public void ActualizarEstado(string nuevoEstado)
    {
        if (string.IsNullOrWhiteSpace(nuevoEstado))
            throw new ArgumentException("El estado no puede estar vacío.");
        Estado = nuevoEstado;
    }

    /// <summary>
    /// Indica si el animal está disponible para adopción.
    /// </summary>
    public bool EsAdoptable()
    {
        return Estado == "Disponible";
    }

    /// <summary>
    /// Método abstracto: cada especie describe sus cuidados específicos.
    /// ESTO ES POLIMORFISMO — mismo método, comportamiento diferente según la especie.
    /// </summary>
    public abstract void DescribirCuidados();
}