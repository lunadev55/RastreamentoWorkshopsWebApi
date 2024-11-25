using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.Data.Context;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class AddColaboradorToAtaCommandHandler : IRequestHandler<AddColaboradorToAtaCommand>
{
    private readonly ApplicationDbContext _context;

    public AddColaboradorToAtaCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddColaboradorToAtaCommand request, CancellationToken cancellationToken)
    {
        var ata = await _context.Atas
            .Include(a => a.Colaboradores)
            .FirstOrDefaultAsync(a => a.Id == request.AtaId, cancellationToken);
        if (ata == null) throw new KeyNotFoundException("Ata não encontrada.");

        var colaborador = await _context.Colaboradores.FindAsync(request.ColaboradorId);
        if (colaborador == null) throw new KeyNotFoundException("Colaborador não encontrado.");

        if (!ata.Colaboradores.Contains(colaborador))
        {
            ata.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}
