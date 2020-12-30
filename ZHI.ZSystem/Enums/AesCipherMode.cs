namespace ZHI.ZSystem
{
    /// <summary>
    /// AES密码模式（AES Cipher Mode）
    /// </summary>
    public enum AesCipherMode
    {
        /// <summary>
        /// System.Security.Cryptography.CBC
        /// </summary>
        CBC = 1,
        /// <summary>
        /// System.Security.Cryptography.ECB
        /// </summary>
        ECB = 2,
        /// <summary>
        /// System.Security.Cryptography.OFB
        /// </summary>
        OFB = 3,
        /// <summary>
        /// System.Security.Cryptography.CFB
        /// </summary>
        CFB = 4,
        /// <summary>
        /// System.Security.Cryptography.CTS
        /// </summary>
        CTS = 5,
        /// <summary>
        /// 
        /// </summary>
        CTR = 6
    }
}
