using System.ComponentModel.Composition;
using AdKiller.Shared;

namespace AdKiller.Contract;

[InheritedExport]
public interface IIdentifier
{
    public KillerInfo GetInfo();
}
