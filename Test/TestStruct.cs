using Cave.CodeGen;

namespace Test;

[GenerateDefaultFunctions]
partial struct TestStruct
{
    public int Value { get; set; }
    public TestClass Object { get; set; }
}
