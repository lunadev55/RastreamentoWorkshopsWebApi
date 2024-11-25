using MediatR;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Queries;

public record GetWorkshopsQuery : IRequest<List<Workshop>>;
