using System;

/// <summary>
/// Representa un animal registrado en el refugio.
/// Contiene información básica y permite actualizar su estado dentro del sistema.
/// </summary>
public class Animal 
{
    // Campos privados
    private int id;
    private string nombre = string.Empty;
    private string especie = string.Empty;
    private string estado = string.Empty;
    private DateTime fechaIngreso;

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
    /// Especie del animal (perro, gato, etc.).
    /// </summary>
    public string Especie { get; set; }

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
    public DateTime FechaIngreso { get { return fechaIngreso; } }

    /// <summary>
    /// Constructor para inicializar un animal.
    /// </summary>
    public Animal(int id, string nombre, string especie)
    {
        this.id = id;
        Nombre = nombre;
        Especie = especie;
        Estado = "En observación";
        fechaIngreso = DateTime.Now;
    }

    /// <summary>
    /// Constructor usado para reconstruir un animal a partir de los datos
    /// almacenados en la base de datos (conserva su estado y fecha originales).
    /// </summary>
    public Animal(int id, string nombre, string especie, string estado, DateTime fechaIngreso)
    {
        this.id = id;
        Nombre = nombre;
        Especie = especie;
        Estado = estado;
        this.fechaIngreso = fechaIngreso;
    }

    /// <summary>
    /// Permite actualizar el estado del animal.
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
}