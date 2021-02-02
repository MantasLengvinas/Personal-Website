using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalUI.Services {
    public class Utility {
        public static string Encrypt(string password) {
            var MD = MD5.Create();
            string salt = "Ha^!n%!$S@a(t";
            byte[] bytes = MD.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
