namespace TradingApi.Client.Framework.DTOs
{
    /// <summary>
    /// This is a description of the ErrorCode enum
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// This is a description of Forbidden
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// This is a description of InternalServerError
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// This is a description of InvalidParameterType
        /// </summary>
        InvalidParameterType = 4000,
        /// <summary>
        /// This is a description of ParameterMissing
        /// </summary>
        ParameterMissing = 4001,
        /// <summary>
        /// This is a description of InvalidParameterValue
        /// </summary>
        InvalidParameterValue = 4002,
        /// <summary>
        /// This is a description of InvalidJsonRequest
        /// </summary>
        InvalidJsonRequest = 4003,
        /// <summary>
        /// This is a description of InvalidJsonRequestCaseFormat
        /// </summary>
        InvalidJsonRequestCaseFormat = 4004,
        /// <summary>
        /// The credentials used to authenticate are invalid.  Either the username, password or both are incorrect.
        /// </summary>
        InvalidCredentials = 4010,
    }
}