$vers = ((Invoke-WebRequest https://github.com/bluemagic123/tModLoader/releases).Links | Where-Object -Property outerText -like "*tModLoader.Windows.*")

$link = "https://github.com" + $vers[0].href

Write-Output ("Downloading latest tModLoader from " + $link)

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