using GraphModel.Node.Factories.NewNode;

namespace GraphModelTest.Test.NewNode;

public class BasicFlow
{
   [Test]
   public void BasicFlowTest()
   {
       var printFactory = new PrintFactory();
       var printHelloWorld1 = printFactory.PrintHelloWorld();
       var printHelloWorld2 = printFactory.PrintHelloWorld();
   }
}