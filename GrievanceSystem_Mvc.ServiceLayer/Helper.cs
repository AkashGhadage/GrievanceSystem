using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    internal class Helper
    {
        //may be not static
        public static string GenerateHash(string InputData)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(InputData));

                StringBuilder sb = new StringBuilder(hash.Length * 2);

                for (int i = 0; i < hash.Length; i++)
                {
                    //can be "X2" if you want UPPERCASE
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();

            }

        }

    }
}
