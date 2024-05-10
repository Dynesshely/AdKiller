using Microsoft.Win32;

namespace Killer.WindowsAd;

public class RegistryEditor
{
    public RegistryKey? RegistryKey { get; set; }

    public string Location { get; set; } = "";

    public string Key { get; set; } = "";

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

    public RegistryEditor SetKey(string key)
    {
        Key = key;
        return this;
    }

    public bool ExistsKey()
    {
        var key = RegistryKey?.OpenSubKey(Location + Key);

        key?.Close();

        return key is not null;
    }

    public bool WriteKey(string name, object value)
    {
        var key = (RegistryKey?.CreateSubKey(Location + Key, true)) ?? throw new Exception("Failed to open/create registry key.");

        key?.SetValue(name, value);

        key?.Close();

        return true;
    }

    public void ToggleKey(string name, bool ability) => WriteKey(name, ability ? 1 : 0);

    public void EnableKey(string name) => ToggleKey(name, true);

    public void DisableKey(string name) => ToggleKey(name, false);

    public void EnableKeys(IEnumerable<string> names) => names.ToList().ForEach(EnableKey);

    public void DisableKeys(IEnumerable<string> names) => names.ToList().ForEach(DisableKey);

    public bool KeyToggled(string name)
    {
        if (!ExistsKey()) return false;

        var value = ReadKey(name);

        if (value is null) return false;

        return (int)value == 1;
    }

    public bool AnyKeyToggled(IEnumerable<string> names) => names.Any(KeyToggled);

    public object? ReadKey(string name)
    {
        var key = RegistryKey?.OpenSubKey(Location + Key);

        if (key is null)
            return null;

        return key.GetValue(name);
    }

    public void DeleteKey(string name)
    {
        var key = RegistryKey?.OpenSubKey(Location + Key, true);

        if (key is not null)
        {
            key.DeleteValue(name, false);

            key.Close();
        }
    }

    public static RegistryEditor HKeyCurrentUser => new() { RegistryKey = Registry.CurrentUser, };

    public static RegistryEditor HKeyLocalMachine => new() { RegistryKey = Registry.LocalMachine, };

    public static RegistryEditor HKeyClassesRoot => new() { RegistryKey = Registry.ClassesRoot, };

    public static RegistryEditor HKeyUsers => new() { RegistryKey = Registry.Users, };

    public static RegistryEditor HKeyCurrentConfig => new() { RegistryKey = Registry.CurrentConfig, };

#pragma warning restore CA1416
}
