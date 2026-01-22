using System.Runtime.CompilerServices;

namespace GenericEnumOperators;

#if !NET8_0_OR_GREATER
internal static class UnsafeExtensions
{
    extension(Unsafe)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTo BitCast<TFrom, TTo>(TFrom source)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            return Unsafe.ReadUnaligned<TTo>(ref Unsafe.As<TFrom, byte>(ref source));
        }
    }
}
#endif