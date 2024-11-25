using MediatR;
namespace RastreamentoWorkshopsWebApi.CQRS.Commands;
public record CreateWorkshopCommand(string Nome, DateTime DataRealizacao, string Descricao) : IRequest<int>;
