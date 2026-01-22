using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using static InlineIL.IL;

namespace GenericEnumOperators;

public static class EnumExtensions
{
    extension<T>(T) where T : unmanaged, Enum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator |(T x, T y)
        {
            Emit.Ldarg_0();
            Emit.Ldarg_1();
            Emit.Or();
            return Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator &(T x, T y)
        {
            Emit.Ldarg_0();
            Emit.Ldarg_1();
            Emit.And();
            return Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator ^(T x, T y)
        {
            Emit.Ldarg_0();
            Emit.Ldarg_1();
            Emit.Xor();
            return Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static T operator ~(T x)
        {
            Emit.Ldarg_0();
            Emit.Not();
            return Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool operator ==(T x, T y)
        {
            Emit.Ldarg_0();
            Emit.Ldarg_1();
            Emit.Ceq();
            return Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public static bool operator !=(T x, T y)
        {
            Emit.Ldarg_0();
            Emit.Ldarg_1();
            Emit.Ceq();
            Emit.Ldc_I4_0();
            Emit.Ceq();
            return Return<bool>();
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
}