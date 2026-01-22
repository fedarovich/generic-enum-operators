namespace GenericEnumOperators.Tests;

public class EnumExtensionsTests
{
    [Test]
    [TestCaseSource(nameof(OrTestCases), methodParams: new object?[] {"{0} | {1}"})]
    public void OrOperator<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x | y, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(OrTestCases), methodParams: new object?[] { "{0}.BitwiseOr({1})" })]
    public void BitwiseOrMethod<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x.BitwiseOr(y), Is.EqualTo(result));
    }

    public static TestCaseData[] OrTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<SByteEnum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<Int16Enum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<UInt16Enum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<Int32Enum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<UInt32Enum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<Int64Enum>(opFormat, (x, y) => x | y) +
        GenerateTestCases<UInt64Enum>(opFormat, (x, y) => x | y)).ToArray();

    [Test]
    [TestCaseSource(nameof(AndTestCases), methodParams: new object?[] { "{0} & {1}" })]
    public void AndOperator<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x & y, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(AndTestCases), methodParams: new object?[] { "{0}.BitwiseAnd({1})" })]
    public void BitwiseAndMethod<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x.BitwiseAnd(y), Is.EqualTo(result));
    }

    public static TestCaseData[] AndTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<SByteEnum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<Int16Enum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<UInt16Enum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<Int32Enum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<UInt32Enum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<Int64Enum>(opFormat, (x, y) => x & y) +
        GenerateTestCases<UInt64Enum>(opFormat, (x, y) => x & y)).ToArray();

    [Test]
    [TestCaseSource(nameof(XorTestCases), methodParams: new object?[] { "{0} ^ {1}" })]
    public void XorOperator<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x ^ y, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(XorTestCases), methodParams: new object?[] { "{0}.BitwiseXor({1})" })]
    public void BitwiseXorMethod<TEnum>(TEnum x, TEnum y, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x.BitwiseXor(y), Is.EqualTo(result));
    }

    public static TestCaseData[] XorTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<SByteEnum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<Int16Enum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<UInt16Enum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<Int32Enum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<UInt32Enum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<Int64Enum>(opFormat, (x, y) => x ^ y) +
        GenerateTestCases<UInt64Enum>(opFormat, (x, y) => x ^ y)).ToArray();

    [Test]
    [TestCaseSource(nameof(NotTestCases), methodParams: new object?[] { "~{0}" })]
    public void NotOperator<TEnum>(TEnum x, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(~x, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(NotTestCases), methodParams: new object?[] { "{0}.BitwiseNot()" })]
    public void BitwiseNotMethod<TEnum>(TEnum x, TEnum result) where TEnum : unmanaged, Enum
    {
        Assert.That(x.BitwiseNot(), Is.EqualTo(result));
    }
    public static TestCaseData[] NotTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, x => ~x) +
        GenerateTestCases<SByteEnum>(opFormat, x => ~x) +
        GenerateTestCases<Int16Enum>(opFormat, x => ~x) +
        GenerateTestCases<UInt16Enum>(opFormat, x => ~x) +
        GenerateTestCases<Int32Enum>(opFormat, x => ~x) +
        GenerateTestCases<UInt32Enum>(opFormat, x => ~x) +
        GenerateTestCases<Int64Enum>(opFormat, x => ~x) +
        GenerateTestCases<UInt64Enum>(opFormat, x => ~x)).ToArray();

    [Test]
    [TestCaseSource(nameof(EqualsTestCases), methodParams: new object?[] { "{0} == {1}" })]
    public void EqualsOperator<TEnum>(TEnum x, TEnum y, bool result) where TEnum : unmanaged, Enum
    {
        Assert.That(x == y, Is.EqualTo(result));
    }

    [Test]
    [TestCaseSource(nameof(EqualsTestCases), methodParams: new object?[] { "{0}.IsEqualTo({1})" })]
    public void IsEqualToMethod<TEnum>(TEnum x, TEnum y, bool result) where TEnum : unmanaged, Enum
    {
        Assert.That(x.IsEqualTo(y), Is.EqualTo(result));
    }

    public static TestCaseData[] EqualsTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<SByteEnum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<Int16Enum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<UInt16Enum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<Int32Enum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<UInt32Enum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<Int64Enum>(opFormat, (x, y) => x == y) +
        GenerateTestCases<UInt64Enum>(opFormat, (x, y) => x == y)).ToArray();

    [Test]
    [TestCaseSource(nameof(NotEqualsTestCases), methodParams: new object?[] { "{0} != {1}" })]
    public void NotEqualsOperator<TEnum>(TEnum x, TEnum y, bool result) where TEnum : unmanaged, Enum
    {
        Assert.That(x != y, Is.EqualTo(result));
    }

    public static TestCaseData[] NotEqualsTestCases(string opFormat) => (
        GenerateTestCases<ByteEnum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<SByteEnum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<Int16Enum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<UInt16Enum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<Int32Enum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<UInt32Enum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<Int64Enum>(opFormat, (x, y) => x != y) +
        GenerateTestCases<UInt64Enum>(opFormat, (x, y) => x != y)).ToArray();

    private static IEnumerable<TestCaseData> GenerateTestCases<TEnum>(string opFormat, Func<TEnum, TEnum, TEnum> op)
    {
        var values = (TEnum[])Enum.GetValues(typeof(TEnum));
        foreach (var value1 in values)
        {
            foreach (var value2 in values)
            {
                var result = op(value1, value2);
                yield return new TestCaseData(value1, value2, result)
                {
                    TypeArgs = [typeof(TEnum)],
                    TestName = $"<{typeof(TEnum).Name}> {string.Format(opFormat, value1, value2)} == {result}"
                };
            }
        }
    }

    private static IEnumerable<TestCaseData> GenerateTestCases<TEnum>(string opFormat, Func<TEnum, TEnum, bool> op)
    {
        var values = (TEnum[])Enum.GetValues(typeof(TEnum));
        foreach (var value1 in values)
        {
            foreach (var value2 in values)
            {
                var result = op(value1, value2);
                yield return new TestCaseData(value1, value2, result)
                {
                    TypeArgs = [typeof(TEnum)],
                    TestName = $"<{typeof(TEnum).Name}> {string.Format(opFormat, value1, value2)} is {result}"
                };
            }
        }
    }

    private static IEnumerable<TestCaseData> GenerateTestCases<TEnum>(string opFormat, Func<TEnum, TEnum> op)
    {
        var values = (TEnum[])Enum.GetValues(typeof(TEnum));
        foreach (var value in values)
        {
            var result = op(value);
            yield return new TestCaseData(value, result)
            {
                TypeArgs = [typeof(TEnum)],
                TestName = $"<{typeof(TEnum).Name}> {string.Format(opFormat, value)} == {result}"
            };
        }
    }
}
