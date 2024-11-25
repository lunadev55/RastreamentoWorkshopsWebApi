using MediatR;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Queries;
public record GetColaboradoresQuery() : IRequest<List<ColaboradorWorkshopsDto>>;
