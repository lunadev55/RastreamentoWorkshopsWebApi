using System;

namespace RastreamentoWorkshopsWebApi.Models;

public class Colaborador
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Ata> Atas { get; set; } = new();
}