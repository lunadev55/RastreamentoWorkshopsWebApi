using MediatR;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class CreateAtaCommandHandler : IRequestHandler<CreateAtaCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateAtaCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAtaCommand request, CancellationToken cancellationToken)
    {
        var workshop = await _context.Workshops.FindAsync(request.WorkshopId);
        if (workshop == null)        
            throw new KeyNotFoundException("Workshop not found.");
        

        var ata = new Ata { Workshop = workshop };
        _context.Atas.Add(ata);
        await _context.SaveChangesAsync(cancellationToken);

        return ata.Id;
    }
}
