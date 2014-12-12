
if((Test-Path .\publish) -eq $false){
    New-Item publish -ItemType Directory
}

Remove-Item .\publish\*

write-host "cleared existing publish folder"
write-host ""

$packages = @("Common.Serializer",
"Common.Serializer.NewtonsoftJson",
"Common.Serializer.YamlDotNet"
);

$packages | % { nuget pack ".\src\$_\$($_).csproj" -OutputDirectory publish -Properties Configuration=Release -Build ; write-host "" }