using System.Security.Cryptography;
using System.Text;

namespace sha512
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello, World!";
            string hash = hashing(input);
            string verfiy = veryfing(input,hash);
            var g = "";
        }


        public static string hashing(string input)
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Create an instance of SHA-512 hasher
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // Compute the hash value of the input bytes
                byte[] hashBytes = sha512Hash.ComputeHash(inputBytes);

                // Convert the hash bytes to a hexadecimal string representation
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                // Print the hashed value
                //Console.WriteLine("Hashed Value: " + sb.ToString());
                return sb.ToString();
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length / 2;
            byte[] bytes = new byte[numberChars];
            for (int i = 0; i < numberChars; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        public static string veryfing(string orginal, string hashedValue)
        {
            // The original string
            //string original = "Hello, World!";

            // The hashed value (obtained from hashing step)
            //string hashedValue = "50e72aeea7ce014b020ebb0f9590ad9d8b6157cf455c2d1c86921447b9f9024e731dbfb431b89db3ccf745afda1e3b6c6a53329370c730b026690833911c74a";

            // Convert the original string to bytes
            byte[] originalBytes = Encoding.UTF8.GetBytes(orginal);

            // Convert the hashed value string to bytes
            byte[] hashedBytes = StringToByteArray(hashedValue);

            // Create an instance of SHA-512 hasher
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // Compute the hash value of the original bytes
                byte[] computedHashBytes = sha512Hash.ComputeHash(originalBytes);

                // Compare the computed hash bytes with the hashed bytes
                bool hashesMatch = hashedBytes.SequenceEqual(computedHashBytes);

                // Print the verification result
                //Console.WriteLine("Matched: " + hashesMatch);
                return "Matched: " + hashesMatch;
            }
        }
    }
}