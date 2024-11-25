using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Queries;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class GetWorkshopsQueryHandler : IRequestHandler<GetWorkshopsQuery, List<Workshop>>
{
    private readonly ApplicationDbContext _context;

    public GetWorkshopsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Workshop>> Handle(GetWorkshopsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Workshops.ToListAsync(cancellationToken);
    }
}
