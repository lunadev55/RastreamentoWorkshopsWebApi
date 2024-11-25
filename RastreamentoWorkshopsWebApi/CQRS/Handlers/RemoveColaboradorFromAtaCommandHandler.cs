using MediatR;
using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.Data.Context;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class RemoveColaboradorFromAtaCommandHandler : IRequestHandler<RemoveColaboradorFromAtaCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public RemoveColaboradorFromAtaCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveColaboradorFromAtaCommand request, CancellationToken cancellationToken)
    {     
        var ata = await _context.Atas
            .Include(a => a.Colaboradores)
            .FirstOrDefaultAsync(a => a.Id == request.AtaId, cancellationToken);

        if (ata == null)        
            throw new KeyNotFoundException("Ata não encontrada.");        

        var colaborador = ata.Colaboradores.FirstOrDefault(c => c.Id == request.ColaboradorId);

        if (colaborador == null)        
            throw new KeyNotFoundException("Colaborador não encontrado na ata.");  

        ata.Colaboradores.Remove(colaborador);

        _context.Atas.Update(ata);
        await _context.SaveChangesAsync(cancellationToken);

        return true; 
    }
}
