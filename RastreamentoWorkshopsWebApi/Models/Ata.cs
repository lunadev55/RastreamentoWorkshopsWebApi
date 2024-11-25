namespace RastreamentoWorkshopsWebApi.Models;

public class Ata
{
    public int Id { get; set; }
    public int WorkshopId { get; set; }
    public Workshop Workshop { get; set; } = null!;
    public List<Colaborador> Colaboradores { get; set; } = new();
}
