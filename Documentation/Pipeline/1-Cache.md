# Configgy

[README](../../README.md)

1. [Overview](../1-Overview.md)
    1. [Cache](1-Cache.md)
    2. [Source](2-Source.md)
    3. [Transform](3-Transform.md)
    4. [Validate](4-Validate.md)
    5. [Coerce](5-Coerce.md)

## Pipeline - Cache

The first stage in the pipeline is a cache. Arguably this is also the last stage in the pipeline.

The first step is to simply check the cache for the desired configuration property. If it exists in the cache it is simply returned. If it is not in the cache the it is generated by invoking the rest of the pipeline. After the pipeline is complete (but before the value is returned, obviously) the generated value is added to the cache.

All cache classes must implement `Configgy.Cache.IValueCache`.

The default cache implementation is `Configgy.Cache.DictionaryCache`. This implementation simply wraps a standard .NET concurrent dictionary.