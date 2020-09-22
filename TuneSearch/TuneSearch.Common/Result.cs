using System;
using FunctionalSharp.DiscriminatedUnions;

namespace TuneSearch.Common
{
    public delegate TDestination MapDelegate<TSource, TDestination>(
        TSource source);

    /// <summary>
    /// Class associated with a result or an error.
    /// </summary>
    public class Result<T> : DiscriminatedUnion<T, Exception>
    {
        public Result(T value) : base(value)
        {
        }

        public Result(Exception error) : base(error)
        {
        }

        public Result<TDestination> Map<TDestination>(
            MapDelegate<T, TDestination> mapping)
        {
            return tag switch
            {
                0 => new Result<TDestination>(mapping(Item1)),
                1 => new Result<TDestination>(Item2),
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
