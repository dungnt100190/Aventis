using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Kiss.Infrastructure
{
    /// <summary>
    /// Hashing and symmetric encryption and decryption.
    /// </summary>
    public class Scrambler
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly SymmetricAlgorithm _algo;
        private readonly byte[] _iv;
        private readonly byte[] _key;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize with random key.
        /// </summary>
        /// <remarks>When using this constructor, decryption is only possible on data encrypted with the same instance of this object.</remarks>
        public Scrambler()
        {
            _algo = new DESCryptoServiceProvider();
            _key = _algo.Key;
            _iv = _algo.IV;
        }

        /// <summary>
        /// Initialize with a password.
        /// </summary>
        /// <param name="password">Used to generate a key.</param>
        /// <remarks>Data encrypted with one instance of this object can be decrypted with another instance as long as the password is the same.</remarks>
        public Scrambler(string password)
            : this()
        {
            byte[] hash = ComputeHash(password);
            Array.Copy(hash, 0, _key, 0, _key.Length);
            Array.Copy(hash, _key.Length, _iv, 0, _iv.Length);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Hashes a password to an array of <see cref="byte"/>s.
        /// </summary>
        public static byte[] ComputeHash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            // string to byte[]
            byte[] buf = Encoding.UTF8.GetBytes(password);

            // hash key and iv from buf
            HashAlgorithm ha = new MD5CryptoServiceProvider();
            byte[] hash = ha.ComputeHash(buf);
            return hash;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Decrypt an array of bytes.
        /// </summary>
        /// <returns>Decrypted bytes.</returns>
        public byte[] Decrypt(byte[] encrypted)
        {
            if (encrypted == null)
            {
                throw new ArgumentNullException("encrypted");
            }

            MemoryStream msEncrypted = new MemoryStream(encrypted, false);

            CryptoStream cs = new CryptoStream(msEncrypted, _algo.CreateDecryptor(_key, _iv), CryptoStreamMode.Read);

            MemoryStream msPlain = new MemoryStream();
            using (cs)
            {
                int i;
                while ((i = cs.ReadByte()) > 0)
                {
                    msPlain.WriteByte((byte)i);
                }
            }

            return msPlain.ToArray();
        }

        /// <summary>
        /// Gets a decryption of a string encrypted with <see cref="EncryptString"/>.
        /// </summary>
        public string DecryptString(string encrypted)
        {
            if (encrypted == null)
            {
                throw new ArgumentNullException("encrypted");
            }

            byte[] encBytes = Convert.FromBase64String(encrypted);
            byte[] plainBytes = Decrypt(encBytes);
            string ret = Encoding.UTF8.GetString(plainBytes);
            return ret;
        }

        /// <summary>
        /// Encrypt an array of bytes.
        /// </summary>
        /// <returns>Encrypted bytes.</returns>
        public byte[] Encrypt(byte[] plain)
        {
            if (plain == null)
            {
                throw new ArgumentNullException("plain");
            }

            MemoryStream msEncrypted = new MemoryStream();

            CryptoStream cs = new CryptoStream(msEncrypted, _algo.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
            using (cs)
            {
                cs.Write(plain, 0, plain.Length);
                cs.FlushFinalBlock();
            }

            return msEncrypted.ToArray();
        }

        /// <summary>
        /// Gets a Base64 encryption of a string encoded with UTF8.
        /// </summary>
        public string EncryptString(string plain)
        {
            if (plain == null)
            {
                throw new ArgumentNullException("plain");
            }

            byte[] plainBytes = Encoding.UTF8.GetBytes(plain);
            byte[] encBytes = Encrypt(plainBytes);
            string ret = Convert.ToBase64String(encBytes);
            return ret;
        }

        #endregion

        #endregion
    }
}