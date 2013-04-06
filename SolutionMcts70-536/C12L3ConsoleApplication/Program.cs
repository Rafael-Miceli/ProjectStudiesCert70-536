using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C12L3ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            //Encrypting file
            /*

            //string inFileName = args[0];
            //string outFileName = args[1];
            //string password = args[2];

            string inFileName = Console.ReadLine();
            string outFileName = Console.ReadLine();
            string password = Console.ReadLine();

            //Create the password key
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("This is my salt");
            Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

            //Create the algorithm and specify the key and IV
            RijndaelManaged alg = new RijndaelManaged();
            alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
            alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);

            //Read the encrypted file into fileData
            FileStream inFile = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
            byte[] fileData = new byte[inFile.Length];
            inFile.Read(fileData, 0, (int)inFile.Length);

            //Create the ICryptoTransform and the CryptoStream
            ICryptoTransform encryptor = alg.CreateEncryptor();
            FileStream outFile = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write);
            CryptoStream encryptStream = new CryptoStream(outFile, encryptor, CryptoStreamMode.Write);

            //Writes the contents to the cryptStream
            encryptStream.Write(fileData, 0, fileData.Length);

            //Close the file handles
            encryptStream.Close();
            inFile.Close();
            outFile.Close();            
             
            */

            ////Decrypting file

            string inFileName = Console.ReadLine();
            string outFileName = Console.ReadLine();
            string password = Console.ReadLine();

            //Create the password key
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("This is my salt");
            Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, saltValueBytes);

            //Create the algorithm and specify the key and IV
            RijndaelManaged alg = new RijndaelManaged();
            alg.Key = passwordKey.GetBytes(alg.KeySize / 8);
            alg.IV = passwordKey.GetBytes(alg.BlockSize / 8);           
            
            //Read the encrypted file into fileData
            ICryptoTransform decryptor = alg.CreateDecryptor();
            FileStream inFile = new FileStream(inFileName, FileMode.Open, FileAccess.Read);
            CryptoStream decryptStream = new CryptoStream(inFile, decryptor, CryptoStreamMode.Read);
            byte[] fileData = new byte[inFile.Length];
            decryptStream.Read(fileData, 0, (int)inFile.Length);

            //Writes the contents to the unencrypted file
            FileStream outFile = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write);
            outFile.Write(fileData, 0, fileData.Length);
                        
            

            //Close the file handles
            decryptStream.Close();
            inFile.Close();
            outFile.Close();            
             
        }
    }
}
