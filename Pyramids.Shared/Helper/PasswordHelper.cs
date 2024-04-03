using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Shared.Helper
{
    public class PasswordHelper
    {
        // Generate a 5-digit reset password key and store it in a GUID
        public int GenerateResetPasswordKey()
        {
            Random rng = new Random();
            int resetKey = rng.Next(10000, 100000); // Generate a number between 10000 and 99999
            return resetKey;
        }

        public string GeneratedPasswordKey()
        {
            Random rng = new Random();
            int resetKey = rng.Next(100000, 1000000); // Generate a number between 100000 and 999999
            return resetKey.ToString();
        }
        public Guid GenerateResetKeyGuid(int resetKey)
        {
            byte[] guidBytes = new byte[16];
            BitConverter.GetBytes(resetKey).CopyTo(guidBytes, 0); // Store the 5-digit key in the first 4 bytes of the GUID
            return new Guid(guidBytes);
        }

        // Extract the 5-digit key from the GUID
        public string ExtractResetKeyFromGuid(Guid resetKeyGuid)
        {
            byte[] guidBytes = resetKeyGuid.ToByteArray();
            int resetKey = BitConverter.ToInt32(guidBytes, 0);
            return resetKey.ToString();
        }

        // Check if a given 5-digit key matches the one stored in the GUID
        public bool IsMatch(string inputKey, Guid resetKeyGuid)
        {
            return inputKey == ExtractResetKeyFromGuid(resetKeyGuid);
        }
    }

}
