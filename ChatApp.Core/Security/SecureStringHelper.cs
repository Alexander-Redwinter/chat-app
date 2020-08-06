using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace ChatApp.Core.Security
{
    public static class SecureStringHelper
    {

        public static String Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return String.Empty;

            var unmanagedString = IntPtr.Zero;

            try
            {
                //unsecures string
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                //returns pointer to string
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

        }


    }
}
