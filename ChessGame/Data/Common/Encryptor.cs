﻿using System.Security.Cryptography;
using System.Text;

namespace Data.Common
{
    public class Encryptor
    {
        public static string MD5Hash(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
            byte[] result = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
