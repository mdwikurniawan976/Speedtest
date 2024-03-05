using System;
using System.Collections.Generic;

namespace Speedtest.Models;

public partial class Clan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}
