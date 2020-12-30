using System.ComponentModel;

namespace ZHI.ZSystem
{
    /// <summary>
    /// AES 填充模式
    /// </summary>
    public enum AesPaddingMode
    {
        /// <summary>
        /// System.Security.Cryptography.PaddingMode.None
        /// </summary>
        [Description("NOPADDING")]
        NoPadding = 1,
        /// <summary>
        /// System.Security.Cryptography.PaddingMode.PKCS7
        /// </summary>
        [Description("PKCS7PADDING")]
        PKCS7Padding = 2,
        /// <summary>
        /// System.Security.Cryptography.PaddingMode.Zeros
        /// </summary>
        [Description("ZEROBYTEPADDING")]
        ZeroPadding = 3,
        /// <summary>
        /// System.Security.Cryptography.PaddingMode.ANSIX923
        /// </summary>
        [Description("X923PADDING")]
        ANSIX923Padding = 4,
        /// <summary>
        /// System.Security.Cryptography.PaddingMode.ISO10126
        /// </summary>
        [Description("ISO10126PADDING")]
        ISO10126Padding = 5,
    }
}
