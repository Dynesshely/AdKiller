using Microsoft.Win32;

namespace Killer.WindowsAd;

public class RegistryEditor
{
    public RegistryKey? RegistryKey { get; set; }

    public string? Location { get; set; } = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\";

#pragma warning disable CA1416

    public RegistryEditor()
    {
        RegistryKey ??= Registry.CurrentUser;
    }

    public RegistryEditor SetLocation(string location)
    {
        Location = location;
        return this;
    }

    public bool ExistsKey(string key)
    {
        var rkey = RegistryKey?.OpenSubKey(Location + key);

        rkey?.Close();

        return rkey is not null;
    }

    public bool WriteKey(string key, string name, object value)
    {
        var rkey = (RegistryKey?.CreateSubKey(Location + key, true)) ?? throw new Exception("Failed to open/create registry key.");

        rkey?.SetValue(name, value);

        rkey?.Close();

        return true;
    }

    public object? ReadKey(string key, string name)
    {
        var rkey = RegistryKey?.OpenSubKey(Location + key);

        if (rkey is null) return null;

        return rkey.GetValue(name);
    }

    public void DeleteKey(string key, string name)
    {
        var rkey = RegistryKey?.OpenSubKey(Location + key, true);

        if (rkey is not null)
        {
            rkey.DeleteValue(name, false);

            rkey.Close();
        }
    }

    public static RegistryEditor HKeyCurrentUser => new()
    {
        RegistryKey = Registry.CurrentUser,
    };

    public static RegistryEditor HKeyLocalMachine => new()
    {
        RegistryKey = Registry.LocalMachine,
    };

    public static RegistryEditor HKeyClassesRoot => new()
    {
        RegistryKey = Registry.ClassesRoot,
    };

    public static RegistryEditor HKeyUsers => new()
    {
        RegistryKey = Registry.Users,
    };

    public static RegistryEditor HKeyCurrentConfig => new()
    {
        RegistryKey = Registry.CurrentConfig,
    };

#pragma warning restore CA1416

}
