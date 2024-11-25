using MediatR;
namespace RastreamentoWorkshopsWebApi.CQRS.Commands;
public record CreateAtaCommand(int WorkshopId) : IRequest<int>;
