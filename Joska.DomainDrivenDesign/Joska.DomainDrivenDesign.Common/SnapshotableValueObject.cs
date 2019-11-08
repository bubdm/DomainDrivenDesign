namespace Joska.DomainDrivenDesign.Common
{
    public abstract class SnapshotableValueObject<T> : ISnapshotable<T> where T : new()
    {
        public abstract T CreateSnapshot();
        public abstract void UpdateFromSnapshot(T snapshot);
    }
}