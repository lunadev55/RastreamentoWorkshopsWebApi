using MediatR;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Queries;

public record GetAtasByWorkshopNameQuery(string Nome) : IRequest<List<Ata>>;
