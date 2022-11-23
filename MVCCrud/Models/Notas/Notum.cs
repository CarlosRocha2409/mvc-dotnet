using System;
using System.Collections.Generic;

namespace MVCCrud.Models.Notas;

public partial class Notum
{
    public int Id { get; set; }

    public string Carnet { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int NSistematico { get; set; }

    public int N1parcial { get; set; }

    public int N2parcial { get; set; }

    public int? EConvo1 { get; set; }

    public int? EConvo2 { get; set; }
}
