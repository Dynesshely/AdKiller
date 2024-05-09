using System.Collections.Generic;

namespace AdKiller.Shared;

public class KillerInfo
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Version { get; set; }

    public string? Authors { get; set; }

    public List<KillerAction> Killers { get; set; } = [];
}