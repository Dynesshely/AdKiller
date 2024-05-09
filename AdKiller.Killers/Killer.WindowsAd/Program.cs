using AdKiller.Contract;
using AdKiller.Shared;

namespace Killer.WindowsAd;

public class Program : IIdentifier
{
    private static readonly RegistryEditor registryEditor = RegistryEditor.HKeyCurrentUser;

    public KillerInfo GetInfo() => new()
    {
        Name = "Windows Ad Killer",
        Description = "Kills Windows ADs.",
        Version = "0.0.1",
        Authors = "Dynesshely",
        Killers = [
            new(){
                Name = "Disable File Explorer ADs",
                Description = "Disable ADs in Windows File Explorer",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable Lock Screen Tips And ADs",
                Description = "Disable ADs and tips in lock screen",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable Settings ADs",
                Description = "Disable ADs in Windows Settings",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable General Tips And ADs",
                Description = "Disable general tips and ADs",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable \"Finish Setup\" ADs",
                Description = "Disable ADs in \"Finish Setup\"",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable \"Welcome Experience\" ADs",
                Description = "Disable ADs in \"Welcome Experience\"",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable Personalized ADs",
                Description = "Disable personalized ADs",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable \"Tailored Experiences\"",
                Description = "Disable ADs in \"Tailored Experiences\"",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
            new(){
                Name = "Disable Start Menu ADs",
                Description = "Disable ADs in Start Menu",
                CanExecute = true,
                IsNeedToRestart = true,
                Killer = () => {

                },
                Reopener = () => {

                },
            },
        ],
    };
}