using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectCSharpCGV
{
    public class CheckValidate
    {
      public static  bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private static readonly Regex phoneNumber = new Regex(@"\d{2}\d{3}\d{3}\d{4}");

        public static bool VerifyPhoneNumber(string pNumber)
        {
            return phoneNumber.IsMatch(pNumber);
        }
    }
}