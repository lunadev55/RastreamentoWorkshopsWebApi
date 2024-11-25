using MediatR;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Queries;

public record GetAtasByDateQuery(DateTime Data) : IRequest<List<Ata>>;
