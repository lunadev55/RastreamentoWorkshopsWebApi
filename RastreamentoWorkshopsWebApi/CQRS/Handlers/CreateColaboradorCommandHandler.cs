using System;
using MediatR;
using RastreamentoWorkshopsWebApi.CQRS.Commands;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;
using RastreamentoWorkshopsWebApi.Models.Dtos;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateColaboradorCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
    {
        var colaborador = new Colaborador { Nome = request.Nome };
        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync(cancellationToken);
        return colaborador.Id;
    }
}
