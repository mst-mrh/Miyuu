# 主路径是miyuu

Write-Output ("Start saving Chinese tModLoader..." + $link)

Copy-Item "Debug\Terraria.exe" -Destination "tmlcn\"
Copy-Item "Debug\tModLoaderServer.exe" -Destination "tmlcn\"
Copy-Item "scripts\tml-readme.txt" -Destination "tmlcn\README.txt"

$tmlcnpath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("tmlcn\")
$zippath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("tmlcn.zip")

Add-Type -Assembly System.IO.Compression.FileSystem
$compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
[System.IO.Compression.ZipFile]::CreateFromDirectory($tmlcnpath, $zippath, $compressionLevel, $false)