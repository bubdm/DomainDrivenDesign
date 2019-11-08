namespace Joska.DomainDrivenDesign.Common
{
    /// <summary>
    /// Manages a snapshot representation of the object`s state suitable for storing.
    /// A snapshot contains all necessary pieces of data to rehydrate objects internal state which
    /// may not be accessible from outside.
    /// A snapsot object should be simple DTO-like object.
    /// </summary>
    /// <returns>Returns an object suitable to transfer and persist internal state of an object.</returns>
    public interface ISnapshotable<T> where T : new()
    {
        /// <summary>
        /// Creates a snapshot representation of this object internal state.
        /// </summary>
        /// <returns></returns>
        T CreateSnapshot();


        /// <summary>
        /// Updates internal state of the object from snapshot. All contracts and invariants must be met and this is
        /// a responsibility of the object being rehydrated from snapsot.
        /// </summary>
        /// <param name="snapshot">A snapshot to rehyrate from</param>
        void UpdateFromSnapshot(T snapshot);

    }
}