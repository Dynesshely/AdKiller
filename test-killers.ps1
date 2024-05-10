$KillersPath = (Resolve-Path -Path "./AdKiller/bin/Debug/net8.0/Killers").Path

if (!(Test-Path -Path $KillersPath)) {
    New-Item -ItemType Directory -Path $KillersPath
}

Push-Location ./AdKiller.Killers

Get-ChildItem -Directory | ForEach-Object {
    Write-Host "Entering: $_"

    $dirName = $_.Name
    Write-Host "Directory Name: $dirName"

    Push-Location $_.FullName

    Write-Host "Executing: dotnet build"
    dotnet build

    Push-Location ./bin/Debug/net8.0

    # Get-ChildItem -Filter "*.dll" | ForEach-Object {
    #     Copy-Item -Path $_.FullName -Destination $KillersPath
    #     Write-Host "已拷贝文件: $_ to ./CopiedFiles"
    # }

    Copy-Item -Path "$dirName.dll" -Destination $KillersPath
    Write-Host "Copied file: $dirName.dll to $KillersPath"

    Pop-Location

    Pop-Location
}

Pop-Location

Write-Host "All done."
