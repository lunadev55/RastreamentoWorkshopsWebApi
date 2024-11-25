namespace RastreamentoWorkshopsWebApi.Models.Dtos;
public class WorkshopWithAtaDto
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataRealizacao { get; set; }
    public List<string> Colaboradores { get; set; } = new List<string>();
}