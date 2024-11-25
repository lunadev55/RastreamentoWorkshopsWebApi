using MediatR;
namespace RastreamentoWorkshopsWebApi.CQRS.Commands;
public record RemoveColaboradorFromAtaCommand(int AtaId, int ColaboradorId) : IRequest<bool>;
