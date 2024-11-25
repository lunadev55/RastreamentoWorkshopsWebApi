using MediatR;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Queries;
public class GetWorkshopsByDateQuery : IRequest<List<WorkshopWithAtaDto>>
{
    public DateTime Data { get; set; }

    public GetWorkshopsByDateQuery(DateTime data)
    {
        Data = data;
    }
}
