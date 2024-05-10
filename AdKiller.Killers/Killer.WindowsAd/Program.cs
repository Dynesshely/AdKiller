using AdKiller.Contract;
using AdKiller.Shared;

namespace Killer.WindowsAd;

public class Program : IIdentifier
{
    private static readonly RegistryEditor registryEditor = RegistryEditor.HKeyCurrentUser.SetLocation(
        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\"
    );

    public static KillerAction GetOneKeyKiller(string name, string des, string key, string keyName)
    {
        return new KillerAction()
        {
            Name = name,
            Description = des,
            CanExecute = true,
            IsNeedToRestart = true,
            Killer = () => registryEditor.SetKey(key).DisableKey(keyName),
            Reopener = () => registryEditor.SetKey(key).EnableKey(keyName),
            EnabledChecker = () => registryEditor.SetKey(key).KeyToggled(keyName),
        };
    }

    public static KillerAction GetKeysKiller(string name, string des, string key, IEnumerable<string> keyNames)
    {
        return new KillerAction()
        {
            Name = name,
            Description = des,
            CanExecute = true,
            IsNeedToRestart = true,
            Killer = () => registryEditor.SetKey(key).DisableKeys(keyNames),
            Reopener = () => registryEditor.SetKey(key).EnableKeys(keyNames),
            EnabledChecker = () => registryEditor.SetKey(key).AnyKeyToggled(keyNames),
        };
    }

    public KillerInfo GetInfo() =>
        new()
        {
            Name = "Windows Ad Killer",
            Description = "Kills Windows ADs.",
            Version = "0.0.1",
            Authors = "Dynesshely",
            Killers =
            [
                GetOneKeyKiller(
                    "Disable File Explorer ADs",
                    "Disable ADs in Windows File Explorer",
                    "Explorer\\Advanced\\",
                    "ShowSyncProviderNotifications"
                ),
                GetOneKeyKiller(
                    "Disable Start Menu ADs",
                    "Disable ADs in Start Menu",
                    "Explorer\\Advanced\\",
                    "Start_IrisRecommendations"
                ),
                GetKeysKiller(
                    "Disable Lock Screen Tips And ADs",
                    "Disable ADs and tips in lock screen",
                    "ContentDeliveryManager",
                    ["RotatingLockScreenOverlayEnabled", "SubscribedContent-338387Enabled"]
                ),
                GetKeysKiller(
                    "Disable Settings ADs",
                    "Disable ADs in Windows Settings",
                    "ContentDeliveryManager",
                    ["SubscribedContent-338393Enabled", "SubscribedContent-353694Enabled", "SubscribedContent-353696Enabled"]
                ),
                GetOneKeyKiller(
                    "Disable General Tips And ADs",
                    "Disable general tips and ADs",
                    "ContentDeliveryManager",
                    "SubscribedContent-338389Enabled"
                ),
                GetOneKeyKiller(
                    "Disable \"Finish Setup\" ADs",
                    "Disable ADs in \"Finish Setup\"",
                    "UserProfileEngagement",
                    "ScoobeSystemSettingEnabled"
                ),
                GetOneKeyKiller(
                    "Disable \"Welcome Experience\" ADs",
                    "Disable ADs in \"Welcome Experience\"",
                    "ContentDeliveryManager",
                    "SubscribedContent-310093Enabled"
                ),
                GetOneKeyKiller("Disable Personalized ADs", "Disable personalized ADs", "AdvertisingInfo", "Enabled"),
                GetOneKeyKiller(
                    "Disable \"Tailored Experiences\"",
                    "Disable ADs in \"Tailored Experiences\"",
                    "Privacy",
                    "TailoredExperiencesWithDiagnosticDataEnabled"
                ),
            ],
        };
}
