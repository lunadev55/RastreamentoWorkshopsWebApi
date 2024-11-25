namespace RastreamentoWorkshopsWebApi.Models.Dtos;

public class WorkshopDto
{
    public int WorkshopId { get; set; }
    public string? Nome { get; set; }
    public DateTime DataRealizacao { get; set; }
    public string? Descricao { get; set; }
}