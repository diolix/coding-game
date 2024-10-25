﻿using GraphModel.Handle.Value.Output;
using GraphModel.NewValueTypes;
using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Node.Output;

public class OutputValueManager(IEnumerable<BaseOutputValueHandle> outputs)
{
    private BaseOutputValueHandle GetHandle(string label) =>
        outputs.First(handle => handle.Label == label);

    public void Cache(string label, Value value) =>
        GetHandle(label).SetCachedValue(value);
    
    public void Cache(string label, object value, ValueTypeEnum type) =>
        GetHandle(label).SetCachedValue(ValueFactory.CreateValue(value, type));
    
    public void CacheString(string label, string value) =>
        GetHandle(label).SetCachedValue(new StringValue(value));

    public void CacheBool(string label, bool value) =>
        GetHandle(label).SetCachedValue(new BoolValue(value));

    public void CacheObject(string label, int value) =>
        GetHandle(label).SetCachedValue(new ObjectValue(value));
}