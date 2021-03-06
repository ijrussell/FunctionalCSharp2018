﻿using System;

namespace ConsoleApp13
{
    public class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }

    public class Some<T> : Option<T>
    {
        private T Content { get; }

        public Some(T content)
        {
            this.Content = content;
        }

        public static implicit operator T(Some<T> value) => value.Content;
    }

    public class None<T> : Option<T> { }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }

    public static class OptionAdaptors
    {
        public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> map) =>
            option is Some<T> some ? (Option<TResult>)map(some) : None.Value;

        public static Option<T> When<T>(this T value, Func<T, bool> predicate) =>
            predicate(value) ? (Option<T>)value : None.Value;

        public static T Reduce<T>(this Option<T> option, T whenNone) =>
            option is Some<T> some ? (T)some : whenNone;

        public static T Reduce<T>(this Option<T> option, Func<T> whenNone) =>
            option is Some<T> some ? (T)some : whenNone();
    }

    // Func<string, string, string> join = (x, y) => x + y;
    // var greeting = join.Curry()("Hello: ");
    // var result = greeting("Ian");

    public static class CurryExtension
    {
        public static Func<A, Func<B, C>> Curry<A, B, C>(this Func<A, B, C> func) =>
            a => b => func(a, b);

        public static Func<A, Func<B, Func<C, D>>> Curry<A, B, C, D>(this Func<A, B, C, D> func) =>
            a => b => c => func(a, b, c);
    }

}