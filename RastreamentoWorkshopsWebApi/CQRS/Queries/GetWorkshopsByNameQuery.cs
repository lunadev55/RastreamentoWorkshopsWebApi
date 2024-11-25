using MediatR;
using RastreamentoWorkshopsWebApi.Models.Dtos;

public class GetWorkshopsByNameQuery : IRequest<List<WorkshopWithAtaDto>>
{
    public string WorkshopNome { get; set; }

    public GetWorkshopsByNameQuery(string workshopNome)
    {
        WorkshopNome = workshopNome;
    }
}
