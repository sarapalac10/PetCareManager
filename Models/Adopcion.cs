using System;

/// <summary>
/// Representa el proceso de adopción de un animal.
/// Relaciona un Animal con un Adoptante.
/// </summary>
public class Adopcion
{
    public int Id { get; private set; }
    public Animal Animal { get; private set; }
    public Adoptante Adoptante { get; private set; }
    public DateTime FechaSolicitud { get; private set; }
    public EstadoAdopcion Estado { get; private set; }

    /// <summary>
    /// Constructor de la adopción. El estado inicial es EN_REVISION.
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
    /// Aprueba la adopción y actualiza el estado del animal a Adoptado.
    /// </summary>
    public void Aprobar()
    {
        Estado = EstadoAdopcion.APROBADA;
        Animal.ActualizarEstado(EstadoAnimal.Adoptado);
        Console.WriteLine($"✔ Adopción aprobada: {Animal.Nombre} → {Adoptante.Nombre}");
    }

    /// <summary>
    /// Rechaza la solicitud de adopción.
    /// </summary>
    public void Rechazar()
    {
        Estado = EstadoAdopcion.RECHAZADA;
        Console.WriteLine($"✖ Adopción rechazada para: {Animal.Nombre}");
    }
}