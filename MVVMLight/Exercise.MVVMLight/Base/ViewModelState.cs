using System;

namespace Exercise.MVVMLight.Data
{
    [Flags]
    public enum ViewModelState
    {
        /// <summary>
        /// There was no chnage
        /// </summary>
        Original = 1,
        /// <summary>
        /// view model was changed, after saving the stahe should be set to original
        /// </summary>
        Updated = 2,
        /// <summary>
        /// view model was created by user. saving will commit new data to the DAL
        /// </summary>
        New = 4,
        /// <summary>
        /// data will be deleted after next commit to the DAL
        /// </summary>
        Delete = 8,
        /// <summary>
        /// marks data sa valid/invalid, save button IsEnabled property can be bound to this property
        /// </summary>
        Valid = 16
    }
}
