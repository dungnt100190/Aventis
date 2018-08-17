using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace KiSSSvc.DAL
{
	/// <summary>
	/// Hashing and symmetric encryption and decryption.
	/// </summary>
	public class Scrambler
	{
		/// <summary>
		/// Decrypt a string
		/// </summary>
		/// <param name="connectionString">Connectionstring with encrypted pwd</param>
		/// <returns>Connectionstring with decrypted pwd</returns>
		internal static string DecryptPasswordInConnectionString(string connectionString)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
			if (string.IsNullOrEmpty(builder.Password))
				return connectionString;
			Scrambler sc = new Scrambler("KiSS4");
			builder.Password = sc.DecryptString(builder.Password);
			return builder.ConnectionString;
		}


		/// <summary>
		/// Hashes a password to an array of <see cref="byte"/>s.
		/// </summary>
		public static byte[] ComputeHash(string password)
		{
			if (password == null) throw new ArgumentNullException("password");

			// string to byte[]
			byte[] buf = Encoding.UTF8.GetBytes(password);

			// hash key and iv from buf
			HashAlgorithm ha = new MD5CryptoServiceProvider();
			byte[] hash = ha.ComputeHash(buf);
			return hash;
		}

		private SymmetricAlgorithm algo;
		private byte[] key;
		private byte[] iv;

		/// <summary>
		/// Initialize with random key.
		/// </summary>
		/// <remarks>When using this constructor, decryption is only possible on data encrypted with the same instance of this object.</remarks>
		public Scrambler()
		{
			this.algo = new DESCryptoServiceProvider();
			this.key = algo.Key;
			this.iv = algo.IV;
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
			Array.Copy(hash, 0, this.key, 0, this.key.Length);
			Array.Copy(hash, this.key.Length, this.iv, 0, this.iv.Length);
		}

		///// <summary>
		///// Encrypt an array of bytes.
		///// </summary>
		///// <returns>Encrypted bytes.</returns>
		//public byte[] Encrypt(byte[] plain)
		//{
		//   if (plain == null) throw new ArgumentNullException("plain");

		//   MemoryStream msEncrypted = new MemoryStream();

		//   CryptoStream cs = new CryptoStream(msEncrypted, algo.CreateEncryptor(this.key, this.iv), CryptoStreamMode.Write);
		//   using (cs)
		//   {
		//      cs.Write(plain, 0, plain.Length);
		//      cs.FlushFinalBlock();
		//   }

		//   return msEncrypted.ToArray();
		//}

		/// <summary>
		/// Decrypt an array of bytes.
		/// </summary>
		/// <returns>Decrypted bytes.</returns>
		public byte[] Decrypt(byte[] encrypted)
		{
			if (encrypted == null) throw new ArgumentNullException("encrypted");

			MemoryStream msEncrypted = new MemoryStream(encrypted, false);

			CryptoStream cs = new CryptoStream(msEncrypted, algo.CreateDecryptor(this.key, this.iv), CryptoStreamMode.Read);

			MemoryStream msPlain = new MemoryStream();
			using (cs)
			{
				int i;
				while ((i = cs.ReadByte()) > 0)
					msPlain.WriteByte((byte)i);
			}

			return msPlain.ToArray();
		}


		///// <summary>
		///// Gets a Base64 encryption of a string encoded with UTF8.
		///// </summary>
		//public string EncryptString(string plain)
		//{
		//   if (plain == null) throw new ArgumentNullException("plain");

		//   byte[] plainBytes = Encoding.UTF8.GetBytes(plain);
		//   byte[] encBytes = this.Encrypt(plainBytes);
		//   string ret = Convert.ToBase64String(encBytes);
		//   return ret;
		//}

		/// <summary>
		/// Gets a decryption of a string encrypted with <see cref="EncryptString"/>.
		/// </summary>
		public string DecryptString(string encrypted)
		{
			if (encrypted == null) throw new ArgumentNullException("encrypted");

			byte[] encBytes = Convert.FromBase64String(encrypted);
			byte[] plainBytes = this.Decrypt(encBytes);
			string ret = Encoding.UTF8.GetString(plainBytes);
			return ret;
		}

	}
}
