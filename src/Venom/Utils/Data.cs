namespace Venom
{
    using System;

    internal struct Data
    {
        internal Action Action { get; }

        internal string ClassName { get; }

        internal string MethodName { get; }

        private Data(Action action)
        {
            Action = action;
            ClassName = action.Method.DeclaringType.Name;
            MethodName = action.Method.Name;
        }

        internal static Data For(Action action) => new Data(action);
    }
}
