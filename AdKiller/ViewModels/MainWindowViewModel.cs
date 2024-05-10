using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using AdKiller.Contract;
using AdKiller.Shared;
using ReactiveUI;

namespace AdKiller.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Killers";

        var catalog = new DirectoryCatalog(path, "*.dll");

        var container = new CompositionContainer(catalog);

        var sub = container.GetExportedValues<IIdentifier>();

        if (sub is not null)
            foreach (var item in sub)
            {
                var info = item.GetInfo();

                Debug.WriteLine($"Got info: {info.Name}");

                KillersProviders.Add(info);
            }

        SelectedKiller = KillersProviders.FirstOrDefault();
    }

    private int _selectedIndex;

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedIndex, value);

            SelectedKiller = KillersProviders[value];
        }
    }

    public KillerInfo? _selectedKillerInfo;

    public KillerInfo? SelectedKiller
    {
        get => _selectedKillerInfo;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedKillerInfo, value);

            this.RaisePropertyChanged(nameof(Authors));
        }
    }

    public ObservableCollection<KillerInfo> KillersProviders { get; set; } = [];

    public IEnumerable<string> Authors => SelectedKiller?.Authors?.Split(',')?.Prepend("Authors: ") ?? [];
}
