using System;

namespace Fri2Ends.Identity.ViewModels
{
    /// <summary>
    /// Response For Apis
    /// </summary>
    /// <typeparam name="T">Object For Return Response</typeparam>
    public struct ApiResponse<T>
    {

        /// <summary>
        /// Error Id For Response if success This equal to zero
        /// </summary>
        public string errorId  { get; set; }

        /// <summary>
        /// Error Title a string To Response title
        /// </summary>
        public string errorTitle { get; set; }

        /// <summary>
        /// T Result Can Be Null Or Has Value
        /// </summary>
        public T result { get; set; }
    }
}
