using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeNew.Services.Admin
{
    public class MdCalculator : IHashCalculator
    {
        public string GetHash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            var hash = md5.ComputeHash(inputBytes).ToList();

            // step 2, convert byte array to hex string

            var sb = new StringBuilder();

            hash.ForEach(elem => sb.Append(elem));

            return sb.ToString();

        }
    }
}
