using AdKiller.Contract;
using AdKiller.Shared;

namespace Killer.WindowsAd;

public class Program : IIdentifier
{
    private static readonly RegistryEditor registryEditor = RegistryEditor.HKeyCurrentUser.SetLocation(
        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\"
    );

    public KillerInfo GetInfo() =>
        new()
        {
            Name = "Windows Ad Killer",
            Description = "Kills Windows ADs.",
            Version = "0.0.1",
            Authors = "Dynesshely",
            Killers =
            [
                new()
                {
                    Name = "Disable File Explorer ADs",
                    Description = "Disable ADs in Windows File Explorer",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("Explorer\\Advanced\\").DisableKey("ShowSyncProviderNotifications"),
                    Reopener = () => registryEditor.SetKey("Explorer\\Advanced\\").EnableKey("ShowSyncProviderNotifications"),
                },
                new()
                {
                    Name = "Disable Start Menu ADs",
                    Description = "Disable ADs in Start Menu",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("Explorer\\Advanced\\").DisableKey("Start_IrisRecommendations"),
                    Reopener = () => registryEditor.SetKey("Explorer\\Advanced\\").EnableKey("Start_IrisRecommendations"),
                },
                new()
                {
                    Name = "Disable Lock Screen Tips And ADs",
                    Description = "Disable ADs and tips in lock screen",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () =>
                        registryEditor
                            .SetKey("ContentDeliveryManager")
                            .DisableKeys(["RotatingLockScreenOverlayEnabled", "SubscribedContent-338387Enabled"]),
                    Reopener = () =>
                        registryEditor
                            .SetKey("ContentDeliveryManager")
                            .EnableKeys(["RotatingLockScreenOverlayEnabled", "SubscribedContent-338387Enabled"]),
                },
                new()
                {
                    Name = "Disable Settings ADs",
                    Description = "Disable ADs in Windows Settings",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () =>
                        registryEditor
                            .SetKey("ContentDeliveryManager")
                            .DisableKeys(
                                [
                                    "SubscribedContent-338393Enabled",
                                    "SubscribedContent-353694Enabled",
                                    "SubscribedContent-353696Enabled"
                                ]
                            ),
                    Reopener = () =>
                        registryEditor
                            .SetKey("ContentDeliveryManager")
                            .EnableKeys(
                                [
                                    "SubscribedContent-338393Enabled",
                                    "SubscribedContent-353694Enabled",
                                    "SubscribedContent-353696Enabled"
                                ]
                            ),
                },
                new()
                {
                    Name = "Disable General Tips And ADs",
                    Description = "Disable general tips and ADs",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("ContentDeliveryManager").DisableKey("SubscribedContent-338389Enabled"),
                    Reopener = () => registryEditor.SetKey("ContentDeliveryManager").EnableKey("SubscribedContent-338389Enabled"),
                },
                new()
                {
                    Name = "Disable \"Finish Setup\" ADs",
                    Description = "Disable ADs in \"Finish Setup\"",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("UserProfileEngagement").DisableKey("ScoobeSystemSettingEnabled"),
                    Reopener = () => registryEditor.SetKey("UserProfileEngagement").EnableKey("ScoobeSystemSettingEnabled"),
                },
                new()
                {
                    Name = "Disable \"Welcome Experience\" ADs",
                    Description = "Disable ADs in \"Welcome Experience\"",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("ContentDeliveryManager").DisableKey("SubscribedContent-310093Enabled"),
                    Reopener = () => registryEditor.SetKey("ContentDeliveryManager").EnableKey("SubscribedContent-310093Enabled"),
                },
                new()
                {
                    Name = "Disable Personalized ADs",
                    Description = "Disable personalized ADs",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("AdvertisingInfo").DisableKey("Enabled"),
                    Reopener = () => registryEditor.SetKey("AdvertisingInfo").EnableKey("Enabled"),
                },
                new()
                {
                    Name = "Disable \"Tailored Experiences\"",
                    Description = "Disable ADs in \"Tailored Experiences\"",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Killer = () => registryEditor.SetKey("Privacy").DisableKey("TailoredExperiencesWithDiagnosticDataEnabled"),
                    Reopener = () => registryEditor.SetKey("Privacy").EnableKey("TailoredExperiencesWithDiagnosticDataEnabled"),
                },
            ],
        };
}
