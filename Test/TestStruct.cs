using System;
using Cave.CodeGen;

namespace Test;

[GenerateDefaultFunctions]
partial struct TestStruct : IEquatable<TestStruct>, IComparable<TestStruct>
{
    public const int ConstantValue = 1;
    public int Value { get; set; }
    public TestClass Object { get; set; }
    public int? NullableValue { get; set; }
}
