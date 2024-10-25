using GraphModel.NewValueTypes;
using GraphModel.Node;
using GraphModel.Node.NodeBuilder.Pure;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModelTest.Mocks
{
    public class MockNodeFactory
    {
        public static INode CreateFlowInput(ImpureNodeBuildable.Execution? callback = null)
        {
            return new ImpureNodeBuildable.Builder()
                .SetName("MockFlowInput")
                .AddInputFlow("")
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    
        public static INode CreateFlowOutput(ImpureNodeBuildable.Execution? callback = null)
        {
            return new ImpureNodeBuildable.Builder()
                .SetName("MockFlowInput")
                .AddOutputFlow("")
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    
        public static INode CreateFlowInputOutput(ImpureNodeBuildable.Execution? callback = null)
        {
            return new ImpureNodeBuildable.Builder()
                .SetName("MockFlowInputOutput")
                .AddInputFlow("")
                .AddOutputFlow("")
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }

        public static INode CreateStringInput(PureNodeBuildable.Execution? callback = null)
        {
            return new PureNodeBuildable.Builder()
                .SetName("MockStringInput")
                .AddInputValue("", ValueTypeEnum.String)
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    
        public static INode CreatePureStringOutput(PureNodeBuildable.Execution? callback = null)
        {
            return new PureNodeBuildable.Builder()
                .SetName("MockStringOutput")
                .AddOutputValue("", ValueTypeEnum.String)
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    
        public static INode CreatePureBoolOutput(PureNodeBuildable.Execution? callback = null)
        {
            return new PureNodeBuildable.Builder()
                .SetName("MockBoolOutput")
                .AddOutputValue("", ValueTypeEnum.Bool)
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    
        public static INode CreateBoolInput(PureNodeBuildable.Execution? callback = null)
        {
            return new PureNodeBuildable.Builder()
                .SetName("MockBoolInput")
                .AddInputValue("", ValueTypeEnum.Bool)
                .SetExecution(callback ?? ((_, _) => {}))
                .Build();
        }
    }
}