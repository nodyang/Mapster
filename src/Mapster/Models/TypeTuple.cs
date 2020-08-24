﻿using System;

namespace Mapster.Models
{
    public readonly struct TypeTuple : IEquatable<TypeTuple>
    {
        public bool Equals(TypeTuple other)
        {
            return Source == other.Source && Destination == other.Destination;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TypeTuple))
                return false;
            return Equals((TypeTuple)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Source?.GetHashCode() ?? 0) << 16) ^ ((Destination?.GetHashCode() ?? 0) & 65535);
            }
        }

        public static bool operator ==(TypeTuple left, TypeTuple right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TypeTuple left, TypeTuple right)
        {
            return !left.Equals(right);
        }

        public Type Source { get; }
        public Type Destination { get; }

        public TypeTuple(Type source, Type destination)
        {
            this.Source = source;
            this.Destination = destination;
        }
    }
}
