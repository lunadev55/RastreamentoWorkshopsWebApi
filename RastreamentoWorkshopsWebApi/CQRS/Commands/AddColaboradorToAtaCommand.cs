using MediatR;
namespace RastreamentoWorkshopsWebApi.CQRS.Commands;
public record AddColaboradorToAtaCommand(int AtaId, int ColaboradorId) : IRequest;
