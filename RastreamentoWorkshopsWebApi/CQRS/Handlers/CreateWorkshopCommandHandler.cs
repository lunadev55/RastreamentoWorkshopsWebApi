using System;
using MediatR;
using RastreamentoWorkshopsWebApi.Data.Context;
using RastreamentoWorkshopsWebApi.Models;
using RastreamentoWorkshopsWebApi.CQRS.Commands;

namespace RastreamentoWorkshopsWebApi.CQRS.Handlers;

public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateWorkshopCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = new Workshop
        {
            Nome = request.Nome,
            DataRealizacao = request.DataRealizacao,
            Descricao = request.Descricao
        };

        _context.Workshops.Add(workshop);
        await _context.SaveChangesAsync(cancellationToken);

        return workshop.Id;
    }
}
