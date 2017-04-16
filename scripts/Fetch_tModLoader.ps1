$downloadLinks = ((Invoke-WebRequest https://github.com/bluemagic123/tModLoader/releases).Links | Where-Object -Property outerText -like "*tModLoader.Windows.*")

$latest = $downloadLinks[0]

$latest.outerText -match "v\d+(\.\d+){0,3}"

$matches[0] | Out-File -FilePath "LatestVersion.txt"

$link = "https://github.com" + $latest.href

Write-Output ("Detected latest tModLoader version: " + $matches[0])

Write-Output ("Downloading from " + $link)

Try
{
    Invoke-WebRequest $link -OutFile "tml.zip"
}
Catch
{
    (New-Object System.Net.WebClient).DownloadFile($link, "tml.zip")
}

mkdir temp

$tmlpath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("tml.zip")
$tmppath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("temp")

Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory($tmlpath, $tmppath)

Move-Item temp\Terraria.exe libs\tModLoader.exe
Move-Item temp\tModLoaderServer.exe libs\
Remove-Item temp\README.txt

Move-Item prebuilts\font.ttf temp\font.ttf