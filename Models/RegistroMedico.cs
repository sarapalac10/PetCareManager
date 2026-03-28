using System;

/// <summary>
/// Representa un registro médico asociado a un animal del refugio.
/// </summary>
public class RegistroMedico
{
    public int Id { get; private set; }
    public DateTime Fecha { get; private set; }
    public Animal Animal { get; private set; }

    private string diagnostico;
    /// <summary>
    /// Diagnóstico registrado en la consulta.
    /// </summary>
    public string Diagnostico
    {
        get { return diagnostico; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El diagnóstico no puede estar vacío.");
            diagnostico = value;
        }
    }

    private string tratamiento;
    /// <summary>
    /// Tratamiento indicado para el animal.
    /// </summary>
    public string Tratamiento
    {
        get { return tratamiento; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El tratamiento no puede estar vacío.");
            tratamiento = value;
        }
    }

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
    /// Muestra el resumen del registro médico.
    /// </summary>
    public void MostrarRegistro()
    {
        Console.WriteLine($"[{Fecha:dd/MM/yyyy}] {Animal.Nombre} — Dx: {Diagnostico} | Tx: {Tratamiento}");
    }
}