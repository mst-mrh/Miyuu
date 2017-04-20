$gameFolder = [System.IO.Path]::Combine(${env:ProgramFiles(x86)}, "Steam", "steamapps", "common", "Terraria")

$game = [System.IO.Path]::Combine($gameFolder, "Terraria.exe")

$server = [System.IO.Path]::Combine($gameFolder, "TerrariaServer.exe")

foreach ($file in $game, $server)
{
    Write-Host "Copying $file"
    Copy-Item -Path $file -Destination .\libs
}