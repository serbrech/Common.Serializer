# Common.Serializer

Provides a simple serializer abstraction to switch between different serialization implementations.

## Installation

nuget package to come

## Usage

Setup the default adapter, usually early in your application :   
```C#
Serialization.Initialize(config =>
{
    config.DefaultAdapter = new DatacontractSerializerAdapter();
});
```
Using the default adapter (configured as above) :
```C#
string serialized = Serialization.Serialize(new AClass { SomeText = "SomeText" });
AClass deserialized = Serialization.Deserialize<AClass>(serialized);
```
Extension methods to by pass the default and use an adapter explicitely :
```C#
string overrideResult = Serialization.With.Json().Serialize(new { SomeText = "SomeText" });
```

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## License

[MIT](License.txt)
