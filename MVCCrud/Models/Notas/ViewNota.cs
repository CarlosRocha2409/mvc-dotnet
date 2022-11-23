using System;
using System.Collections.Generic;

namespace MVCCrud.Models.Notas;

public partial class ViewNota
{
    public string Carnet { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int N1parcial { get; set; }

    public int N2parcial { get; set; }

    public int NSistematico { get; set; }

    public int? NFinal { get; set; }

    public int? EConvo1 { get; set; }

    public int? EFconvo1 { get; set; }

    public int? EConvo2 { get; set; }
}
