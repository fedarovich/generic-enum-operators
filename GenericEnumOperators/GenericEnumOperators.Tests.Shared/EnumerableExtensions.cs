namespace GenericEnumOperators.Tests;

internal static class EnumerableExtensions
{
    extension<T>(IEnumerable<T>)
    {
        public static IEnumerable<T> operator +(IEnumerable<T> first, IEnumerable<T> second) => first.Concat(second);
    }
}
