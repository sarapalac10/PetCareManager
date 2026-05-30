using System;

/// <summary>
/// Representa el proceso de adopción de un animal.
/// </summary>
public class Adopcion
{
    public int Id { get; private set; }

    public Animal Animal { get; private set; }

    public Adoptante Adoptante { get; private set; }

    public DateTime FechaSolicitud { get; private set; }

    public EstadoAdopcion Estado { get; private set; }

    /// <summary>
    /// Constructor de la adopción.
    /// </summary>
    public Adopcion(int id, Animal animal, Adoptante adoptante)
    {
        Id = id;
        Animal = animal;
        Adoptante = adoptante;
        FechaSolicitud = DateTime.Now;
        Estado = EstadoAdopcion.EN_REVISION;
    }

    /// <summary>
    /// Constructor usado para reconstruir una adopción a partir de los datos
    /// almacenados en la base de datos (conserva su fecha y estado originales).
    /// </summary>
    public Adopcion(int id, Animal animal, Adoptante adoptante, DateTime fechaSolicitud, EstadoAdopcion estado)
    {
        Id = id;
        Animal = animal;
        Adoptante = adoptante;
        FechaSolicitud = fechaSolicitud;
        Estado = estado;
    }

    /// <summary>
    /// Aprueba la adopción y actualiza el estado del animal.
    /// </summary>
    public void Aprobar()
    {
        Estado = EstadoAdopcion.APROBADA;
        Animal.ActualizarEstado("Adoptado");
    }

    /// <summary>
    /// Rechaza la solicitud de adopción.
    /// </summary>
    public void Rechazar()
    {
        Estado = EstadoAdopcion.RECHAZADA;
    }
}