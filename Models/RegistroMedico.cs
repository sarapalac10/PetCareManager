using System;

/// <summary>
/// Representa un registro médico asociado a un animal.
/// </summary>
public class RegistroMedico
{
    public int Id { get; private set; }

    public DateTime Fecha { get; private set; }

    public string Diagnostico { get; set; }

    public string Tratamiento { get; set; }

    public Animal Animal { get; set; }

    /// <summary>
    /// Constructor del registro médico.
    /// </summary>
    public RegistroMedico(int id, Animal animal, string diagnostico, string tratamiento)
    {
        Id = id;
        Animal = animal;
        Diagnostico = diagnostico;
        Tratamiento = tratamiento;
        Fecha = DateTime.Now;
    }

    /// <summary>
    /// Constructor usado para reconstruir un registro médico a partir de los
    /// datos almacenados en la base de datos (conserva su fecha original).
    /// </summary>
    public RegistroMedico(int id, Animal animal, string diagnostico, string tratamiento, DateTime fecha)
    {
        Id = id;
        Animal = animal;
        Diagnostico = diagnostico;
        Tratamiento = tratamiento;
        Fecha = fecha;
    }
}