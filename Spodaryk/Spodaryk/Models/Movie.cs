using System;
using System.Collections.Generic;

namespace Spodaryk.Models;

public partial class Movie
{
    public int IdMovie { get; set; }

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string? Comments { get; set; }

    public bool? Recomendation { get; set; }
}
