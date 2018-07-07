using System;

namespace Exercise.MVVMLight.Data
{
    [Flags]
    public enum ViewModelState
    {
        None = 1,
        Updated = 2,
        New = 4,
        Delete = 8,
        Valid = 16
    }
}
