
New-Item publish -ItemType Directory -ErrorAction SilentlyContinue
nuget pack .\src\Common.Serializer\Common.Serializer.csproj -OutputDirectory publish -Properties Configuration=Release
nuget pack .\src\Common.Serializer.NewtonsoftJson\Common.Serializer.NewtonsoftJson.csproj -OutputDirectory publish -Properties Configuration=Release
nuget pack .\src\Common.Serializer.YamlDotNet\Common.Serializer.YamlDotNet.csproj -OutputDirectory publish -Properties Configuration=Release