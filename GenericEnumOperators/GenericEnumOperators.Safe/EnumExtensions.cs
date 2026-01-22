using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericEnumOperators;

public static unsafe class EnumExtensions
{
    extension<T>(T) where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator |(T x, T y)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<byte, T>((byte)(Unsafe.BitCast<T, byte>(x) | Unsafe.BitCast<T, byte>(y)));
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<short, T>((short)(Unsafe.BitCast<T, short>(x) | Unsafe.BitCast<T, short>(y)));
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<int, T>(Unsafe.BitCast<T, int>(x) | Unsafe.BitCast<T, int>(y));
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<long, T>(Unsafe.BitCast<T, long>(x) | Unsafe.BitCast<T, long>(y));
            }

            ThrowNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator &(T x, T y)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<byte, T>((byte)(Unsafe.BitCast<T, byte>(x) & Unsafe.BitCast<T, byte>(y)));
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<short, T>((short)(Unsafe.BitCast<T, short>(x) & Unsafe.BitCast<T, short>(y)));
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<int, T>(Unsafe.BitCast<T, int>(x) & Unsafe.BitCast<T, int>(y));
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<long, T>(Unsafe.BitCast<T, long>(x) & Unsafe.BitCast<T, long>(y));
            }

            ThrowNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator ^(T x, T y)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<byte, T>((byte)(Unsafe.BitCast<T, byte>(x) ^ Unsafe.BitCast<T, byte>(y)));
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<short, T>((short)(Unsafe.BitCast<T, short>(x) ^ Unsafe.BitCast<T, short>(y)));
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<int, T>(Unsafe.BitCast<T, int>(x) ^ Unsafe.BitCast<T, int>(y));
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<long, T>(Unsafe.BitCast<T, long>(x) ^ Unsafe.BitCast<T, long>(y));
            }

            ThrowNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator ~(T x)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<byte, T>((byte)~Unsafe.BitCast<T, byte>(x));
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<short, T>((short)~Unsafe.BitCast<T, short>(x));
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<int, T>(~Unsafe.BitCast<T, int>(x));
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<long, T>(~Unsafe.BitCast<T, long>(x));
            }

            ThrowNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool operator ==(T x, T y)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<T, byte>(x) == Unsafe.BitCast<T, byte>(y);
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<T, short>(x) == Unsafe.BitCast<T, short>(y);
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<T, int>(x) == Unsafe.BitCast<T, int>(y);
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<T, long>(x) == Unsafe.BitCast<T, long>(y);
            }

            ThrowNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool operator !=(T x, T y)
        {
            if (sizeof(T) == 1)
            {
                return Unsafe.BitCast<T, byte>(x) != Unsafe.BitCast<T, byte>(y);
            }

            if (sizeof(T) == 2)
            {
                return Unsafe.BitCast<T, short>(x) != Unsafe.BitCast<T, short>(y);
            }

            if (sizeof(T) == 4)
            {
                return Unsafe.BitCast<T, int>(x) != Unsafe.BitCast<T, int>(y);
            }

            if (sizeof(T) == 8)
            {
                return Unsafe.BitCast<T, long>(x) != Unsafe.BitCast<T, long>(y);
            }

            ThrowNotSupported();
            return default;
        }
    }

    extension<T>(T x) where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T BitwiseOr(T y) => x | y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T BitwiseAnd(T y) => x & y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T BitwiseXor(T y) => x ^ y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T BitwiseNot() => ~x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool HasAnyFlag(T flags) => (x & flags) != default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool HasAllFlags(T flags) => (x & flags) == flags;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T WithFlags(T flags) => x | flags;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public T WithoutFlags(T flags) => x & ~flags;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool IsEqualTo(T y) => x == y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowNotSupported() => throw new NotSupportedException("Unsupported type.");
}