namespace API.Common.Constants

{
    /// <summary>
    /// a class that defines the list of history
    /// MsgCode less than 100 : common
    /// MsgCode >= 100  : Produit
    /// MsgCode >= 200  : payement
    /// MsgCode >= 300  : facture
    /// MsgCode >= 400  : Mail
    /// MsgCode >= 500  : Commercial exchange
    /// MsgCode >= 700  : Dossier
    /// MsgCode >= 800  : Accounting
    /// MsgCode >= 900  : gestion stock
    /// </summary>
    public static class MsgCode
    {
        #region common

        /// <summary>
        /// reference not unique
        /// </summary>
        public const string ReferenceNotUnique = "1";

        /// <summary>
        /// operation failed
        /// </summary>
        public const string OperationFailedException = "2";

        /// <summary>
        /// status incorrect
        /// </summary>
        public const string StatusIncorrect = "3";

        /// <summary>
        /// operation failed not found
        /// </summary>
        public const string OperationFailedNotFound = "4";

        /// <summary>
        /// operation unauthorized
        /// </summary>
        public const string Unauthorized = "5";

        #endregion
    }
}
