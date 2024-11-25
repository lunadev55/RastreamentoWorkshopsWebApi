namespace RastreamentoWorkshopsWebApi.Models.Dtos;

public class ColaboradorWorkshopsDto
{
    public int ColaboradorId { get; set; }
    public string? Nome { get; set; }
    public List<WorkshopDto>? Workshops { get; set; }
}