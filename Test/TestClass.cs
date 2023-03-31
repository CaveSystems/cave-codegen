using Cave.CodeGen;

namespace Test;

[GenerateDefaultFunctions]
partial class TestClass
{
    public int Value { get; set; }
    public TestClass? Object { get; set; }
}
