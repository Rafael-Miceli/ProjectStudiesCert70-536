using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C12Suggested4ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DSAParameters privatekeyinfo;
                DSAParameters publickeyinfo;

                //Create a new instance of DSACryptoServiceProvider to generate a new key pair.
                using(DSACryptoServiceProvider DSA = new DSACryptoServiceProvider())
                {
                    privatekeyinfo = DSA.ExportParameters(true);
                    publickeyinfo = DSA.ExportParameters(false);
                    byte[] HashValue;

                    using(FileStream fs = new FileStream(@"C:\Listener.txt", FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader reader = new BinaryReader(fs);

                        HashValue = reader.ReadBytes((int)fs.Length);

                        //HashValue = new byte[fs.Length];
                        //fs.Read(HashValue, 0, (int)fs.Length);

                        //The hash value to sign
                        //HashValue = new byte[20]{
                        //                            59, 4, 248, 102, 77, 97, 142, 201,
                        //                            210, 12, 224, 93, 25, 41, 100, 197,
                        //                            213, 134, 130, 135
                        //                        };
                    }

                    string OId = CryptoConfig.MapNameToOID("SHA1");

                    //The value to hold the signed value.
                    byte[] SignedHashValue = DSASignHash(HashValue, privatekeyinfo, OId);

                    //Verify the hash and display the results.
                    bool verified = DSAVerifyHash(HashValue, SignedHashValue, publickeyinfo, "SHA1");

                    if(verified)
                    {
                        Console.WriteLine("The hash value was verified.");
                    }
                    else
                    {
                        Console.WriteLine("The hash value was not verified.");
                    }
                }

                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool DSAVerifyHash(byte[] HashValue, byte[] SignedHashValue, DSAParameters publickeyinfo, string HashAlg)
        {
            bool verified = false;

            try
            {
                //Create a new instance of DSACryptoServiceProvider
                using(DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
                {
                    //Import the key information
                    dsa.ImportParameters(publickeyinfo);

                    // Create an DSASignatureDeformatter object and pass it the DSACryptoServiceProvider to transfer the private key.
                    //DSASignatureDeformatter dsaDeformatter = new DSASignatureDeformatter(dsa);

                    //Set the hash algorithm to the passed value.
                    //dsaDeformatter.SetHashAlgorithm(HashAlg);

                    //Verify signature and return the result
                               //Verify hashed files                        //Verify hashed data 
                    verified = dsa.VerifyData(HashValue, SignedHashValue); //dsaDeformatter.VerifySignature(HashValue, SignedHashValue);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return verified;
        }

        private static byte[] DSASignHash(byte[] HashValue, DSAParameters privatekeyinfo, string HashAlg)
        {
            byte[] sig = null;

            try
            {
                //Create a new instance of DSACryptoServiceProvider
                using(DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
                {
                    //Import the key information
                    dsa.ImportParameters(privatekeyinfo);

                    // Create an DSASignatureFormatter object and pass it the DSACryptoServiceProvider to transfer the private key.
                    //DSASignatureFormatter dsaFormatter = new DSASignatureFormatter(dsa);

                    //Set the Hash algorithm to the passed value.
                    //dsaFormatter.SetHashAlgorithm(HashAlg);

                    //Create a signature to the hash value and return it
                          //To format files                              // To format hash data                            
                    sig = dsa.SignData(HashValue, 0, HashValue.Length); //dsa.SignHash(HashValue, "SHA1"); //dsaFormatter.CreateSignature(HashValue);
                                        
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return sig;
        }
    }
}
