using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Joska.DomainDrivenDesign.Common
{
    public static class DomainEvents
    {
        private static AsyncLocal<List<Delegate>> _actions = new AsyncLocal<List<Delegate>>();

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            if (_actions.Value == null)
            {
                _actions.Value = new List<Delegate>();
            }
            _actions.Value.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (_actions == null)
            {
                return;
            }
            foreach (var action in _actions.Value)
            {
                (action as Action<T>)?.Invoke(args);
            }
        }

    }
}