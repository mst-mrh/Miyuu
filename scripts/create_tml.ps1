# 主路径是miyuu

$ver = Get-Content .\LatestVersion.txt

Write-Output ("Start saving Chinese tModLoader " + $ver)

Copy-Item "Debug\Terraria.exe" -Destination "tmlcn\"
Copy-Item "Debug\tModLoaderServer.exe" -Destination "tmlcn\"
Copy-Item "scripts\tml-readme.txt" -Destination "tmlcn\README.txt"

$tmlcnpath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("tmlcn\")
$zippath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("tModLoaderCN.Windows." + $ver + ".zip")

Add-Type -Assembly System.IO.Compression.FileSystem
$compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
[System.IO.Compression.ZipFile]::CreateFromDirectory($tmlcnpath, $zippath, $compressionLevel, $false)