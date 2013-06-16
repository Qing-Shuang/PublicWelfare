using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RedCross.Models
{
    public class MD5Factory
    {
        private static MD5Factory md5;
        private MD5CryptoServiceProvider md5Hasher;

        private MD5Factory()
        {
            md5Hasher = new MD5CryptoServiceProvider();
        }

        public static MD5Factory Instance()
        {
            if (md5 == null)
            {
                md5 = new MD5Factory();
            }
            return md5;
        }

        public string GetMd5Hash(string input)
        {
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; ++i)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyMd5Hash(string input,string hash)
        {
            string hashofInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashofInput,hash) == 0?true:false;
        }
    }
}