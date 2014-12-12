param(
    [Parameter(Mandatory=$True,Position=1)]
    [Alias('v')]
    $version
)

gci -Recurse src/*.nuspec | 
% { 
    $content = Get-Content $_
    $content -replace "<version>(.*)</version>", "<version>$version</version>" | Set-Content $_.FullName
    $content
}