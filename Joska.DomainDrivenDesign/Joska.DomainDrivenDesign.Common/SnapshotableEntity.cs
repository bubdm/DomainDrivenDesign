using System;

namespace Joska.DomainDrivenDesign.Common
{
    public abstract class SnapshotableEntity<TKey, TIdentity, TSnapshot> : Entity<TKey, TIdentity>
        , ISnapshotable<TSnapshot>
        where TIdentity : Identity<TKey>, new()
        where TKey : IComparable, new()
        where TSnapshot : new()

    {
        public abstract TSnapshot CreateSnapshot();
        public abstract void UpdateFromSnapshot(TSnapshot snapshot);
    }
}