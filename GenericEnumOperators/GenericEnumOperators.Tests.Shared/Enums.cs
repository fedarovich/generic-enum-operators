namespace GenericEnumOperators.Tests;

[Flags]
public enum ByteEnum : byte
{
    None = 0,
    Low = 1,
    Mid = 0x10,
    High = 0x80,
    All = byte.MaxValue
}

[Flags]
public enum SByteEnum : sbyte
{
    None = 0,
    Low = 1,
    Mid = 0x10,
    High = sbyte.MinValue,
    Max = sbyte.MaxValue,
    All = -1
}

[Flags]
public enum Int16Enum : short
{
    None = 0,
    Low = 1,
    Mid = 0x1000,
    High = short.MinValue,
    Max = short.MaxValue,
    All = -1
}

[Flags]
public enum UInt16Enum : ushort
{
    None = 0,
    Low = 1,
    Mid = 0x1000,
    High = 0x8000,
    All = ushort.MaxValue
}

[Flags]
public enum Int32Enum : int
{
    None = 0,
    Low = 1,
    Mid = 0x1000_0000,
    High = int.MinValue,
    Max = int.MaxValue,
    All = -1
}

[Flags]
public enum UInt32Enum : uint
{
    None = 0,
    Low = 1,
    Mid = 0x1000_0000,
    High = 0x8000_0000,
    All = uint.MaxValue
}

[Flags]
public enum Int64Enum : long
{
    None = 0,
    Low = 1,
    Mid = 0x1000_0000_0000_0000,
    High = long.MinValue,
    Max = long.MaxValue,
    All = -1
}

[Flags]
public enum UInt64Enum : ulong
{
    None = 0,
    Low = 1,
    Mid = 0x1000_0000_0000_0000,
    High = 0x8000_0000_0000_0000,
    All = uint.MaxValue
}
