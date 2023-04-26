using System;
using Cave.CodeGen;

namespace Test;

[GenerateDefaultFunctions]
partial class TestClass : IEquatable<TestClass>, IComparable<TestClass>
{
    public int Value { get; set; }
    public TestClass? Object { get; set; }
    public int? NullableValue { get; set; }
}
