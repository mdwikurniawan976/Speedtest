using System;
using System.Collections.Generic;

namespace Speedtest.Models;

public partial class FightHistory
{
    public int Id { get; set; }

    public int Hero1Id { get; set; }

    public int Hero2Id { get; set; }

    public double Hero1TotalPower { get; set; }

    public double Hero2TotalPower { get; set; }

    public DateTime FightDate { get; set; }

    public virtual Hero Hero1 { get; set; } = null!;

    public virtual Hero Hero2 { get; set; } = null!;
}
