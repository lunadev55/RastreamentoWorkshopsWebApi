using MediatR;
namespace RastreamentoWorkshopsWebApi.CQRS.Commands;
public record CreateColaboradorCommand(string Nome) : IRequest<int>;
