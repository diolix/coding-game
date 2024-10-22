using GraphModel.NewHandle;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.HandleBuilder;

public class PureOutputHandlesBuilder
{
    private readonly IList<PairStringValueType> _pairStringValueTypes;

    public PureOutputHandlesBuilder()
    {
        _pairStringValueTypes = new List<PairStringValueType>();
    }

    public void AddOutputValueHandle(string label, ValueType type)
    {
        _pairStringValueTypes.Add(new PairStringValueType(label, type));
    }

    public IEnumerable<INewHandle> Build(INewNode node) => _pairStringValueTypes.Select(pairStringValueType =>
        new PureOutputValueHandle(pairStringValueType.StringValue, pairStringValueType.ValueTypeValue, node)).ToArray();

    private class PairStringValueType
    {
        public string StringValue { get; }
        public ValueType ValueTypeValue { get; }

        public PairStringValueType(string stringValue, ValueType valueTypeValue)
        {
            StringValue = stringValue;
            ValueTypeValue = valueTypeValue;
        }
    }
}