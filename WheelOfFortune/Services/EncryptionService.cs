using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace WheelOfFortune.Services
{
    public sealed class EncryptionService
    {
        private const string Hash = "stoiximan4!@#$";


        public static string EncryptString(string plainText)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(plainText);
                using (var md5 = new MD5CryptoServiceProvider())
                {

                    var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
                    using (var tripDes = new TripleDESCryptoServiceProvider()
                    {
                        Key = keys,
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    })
                    {
                        var transform = tripDes.CreateEncryptor();
                        var result = transform.TransformFinalBlock(data, 0, data.Length);
                        return Convert.ToBase64String(result, 0, result.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new InvalidOperationException("Something Whent wrong to encryption process");
            }

        }

        public static string DecryptString(string encryptedText)
        {
            try
            {
                var data = Convert.FromBase64String(encryptedText);
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
                    using (var tripDes = new TripleDESCryptoServiceProvider()
                    {
                        Key = keys,
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    })
                    {
                        var transform = tripDes.CreateDecryptor();
                        var result = transform.TransformFinalBlock(data, 0, data.Length);
                        return Encoding.UTF8.GetString(result);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new InvalidOperationException("Something went wrong with decryption");
            }
               
            }

        }
    }
