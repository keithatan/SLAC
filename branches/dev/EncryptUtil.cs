using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;

namespace Instructor_Interface
{
	
	/// <summary>
	/// Summary description for EncryptUtil.
	/// </summary>
	public class EncryptUtil
	{
		const string KEY = "eNxjwd?";

		public EncryptUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		//  Call this function to remove the key from memory after use for security.
		[System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint="RtlZeroMemory")]
		public static extern bool ZeroMemory(ref string Destination, int Length);

		// Function to Generate a 64-bit Key.
		public static string GenerateKey()
		{
			// Create an instance of Symetric Algorithm. Key and IV is generated automatically.
			DESCryptoServiceProvider desCrypto =(DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

			// Use the Automatically generated key for Encryption.
			return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
		}

		public static void EncryptFile(string strInFile, string strOutFile)
		{
            // Create a file pointer to the text file to encrypt.
            FileStream fileInText = new FileStream(strInFile,FileMode.Open, FileAccess.Read);

            // Create a file pointer for the encrypted output file.
            FileStream fileOutEncrypted = new FileStream(strOutFile, FileMode.Create, FileAccess.Write);

            // Start encryption service and provided string parameter as key.
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(KEY);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(KEY);
            ICryptoTransform desencrypt = DES.CreateEncryptor();

            // Links the key and the data in a stream.
            CryptoStream cryptostream = new CryptoStream(fileOutEncrypted,desencrypt,CryptoStreamMode.Write);

            byte[] bytearrayInput = new byte[fileInText.Length];

            fileInText.Read(bytearrayInput, 0, bytearrayInput.Length);
            cryptostream.Write(bytearrayInput, 0, bytearrayInput.Length);
            cryptostream.Flush();
            cryptostream.Close();
            fileInText.Close();
		}

		public static string DecryptFile(string strInFile)
		{
			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

			//A 64 bit key and IV is required for this provider.
			//Set secret key For DES algorithm.
			DES.Key = ASCIIEncoding.ASCII.GetBytes(KEY);

			//Set initialization vector.
			DES.IV = ASCIIEncoding.ASCII.GetBytes(KEY);

			//Create a file stream to read the encrypted file back.
			FileStream fileInEncrypted = new FileStream(strInFile, FileMode.Open,FileAccess.Read);
		
			//Create a DES decryptor from the DES instance.
			ICryptoTransform desdecrypt = DES.CreateDecryptor();
		
			//Create crypto stream set to read and do a DES decryption transform on incoming bytes.
			CryptoStream cryptostreamDecr = new CryptoStream(fileInEncrypted, desdecrypt, CryptoStreamMode.Read);

			string strContent = new StreamReader(cryptostreamDecr).ReadToEnd();
			return strContent.Trim();
		}
	}
}
