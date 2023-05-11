using NUnit.Framework;

namespace Test;

[TestFixture]
public class TestGeneratedCode
{
    readonly int[] primes1 = new int[]
    {
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997
    };

    [Test]
    public void TestEquals()
    {
        for (var i = 0; i < primes1.Length - 1; i++)
        {
            var prime1 = primes1[i];
            var prime2 = primes1[i + 1];
            var struct1 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var struct2 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var object1 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var object2 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            Assert.AreEqual(struct1, struct2);
            Assert.IsTrue(object.Equals(struct1, struct2));
            Assert.IsTrue(struct1.Equals(struct2));
            Assert.IsTrue(struct2.Equals(struct1));

            Assert.AreNotEqual(struct1, object1);
            Assert.AreNotEqual(struct2, object2);

            Assert.AreEqual(object1, object2);
            Assert.IsTrue(object.Equals(object1, object2));
            Assert.IsTrue(object1.Equals(object2));
            Assert.IsTrue(object1.Equals(object2));
        }
    }

    [Test]
    public void TestHashCode()
    {
        for (var i = 0; i < primes1.Length - 1; i++)
        {
            var prime1 = primes1[i];
            var prime2 = primes1[i + 1];
            var struct1 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var struct2 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var object1 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            var object2 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2 }
            };
            Assert.AreEqual(struct1.GetHashCode(), struct2.GetHashCode());
            Assert.AreEqual(struct1.GetHashCode(), object1.GetHashCode());
            Assert.AreEqual(object1.GetHashCode(), object2.GetHashCode());
            Assert.AreEqual(struct2.GetHashCode(), object2.GetHashCode());
        }
    }

    [Test]
    public void TestEqualsNullable()
    {
        for (var i = 0; i < primes1.Length - 1; i++)
        {
            var prime1 = primes1[i];
            var prime2 = primes1[i + 1];
            var struct1 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var struct2 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var object1 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var object2 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            Assert.AreEqual(struct1, struct2);
            Assert.IsTrue(object.Equals(struct1, struct2));
            Assert.IsTrue(struct1.Equals(struct2));
            Assert.IsTrue(struct2.Equals(struct1));

            Assert.AreNotEqual(struct1, object1);
            Assert.AreNotEqual(struct2, object2);

            Assert.AreEqual(object1, object2);
            Assert.IsTrue(object.Equals(object1, object2));
            Assert.IsTrue(object1.Equals(object2));
            Assert.IsTrue(object1.Equals(object2));
        }
    }

    [Test]
    public void TestHashCodeNullable()
    {
        for (var i = 0; i < primes1.Length - 1; i++)
        {
            var prime1 = primes1[i];
            var prime2 = primes1[i + 1];
            var struct1 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var struct2 = new TestStruct()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var object1 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            var object2 = new TestClass()
            {
                Value = prime1, Object = new() { Value = prime2, NullableValue = prime1 + prime2 }
            };
            Assert.AreEqual(struct1.GetHashCode(), struct2.GetHashCode());
            Assert.AreEqual(struct1.GetHashCode(), object1.GetHashCode());
            Assert.AreEqual(object1.GetHashCode(), object2.GetHashCode());
            Assert.AreEqual(struct2.GetHashCode(), object2.GetHashCode());
            
            Assert.AreEqual(0, struct1.CompareTo(struct2));
            Assert.AreEqual(0, object1.CompareTo(object2));
        }
    }
}
