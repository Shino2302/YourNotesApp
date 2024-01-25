using System;
using System.Collections.Generic;
using System.Text;
using YourNotesApp.Model;

namespace YourNotesApp
{
    public class AppSettings
    {
        public static string ApiFirebase = "https://aplicaciondenotassaeg-default-rtdb.firebaseio.com/";
        private static string KeyAplication = "AIzaSyC_GavLfVkm1ZsZXE30Whv56Sz--L4zUmk";


        public static ResponseAuthentication oAuthentication { get; set; }
        private static string ApiUrlGoogleApis = "https://identitytoolkit.googleapis.com/v1/";

        public static string ApiAuthentication(string tipo)
        {
            if (tipo == "LOGIN")
                return ApiUrlGoogleApis + "accounts:signInWithPassword?key=" + KeyAplication;
            else if (tipo == "SIGNIN")
                return ApiUrlGoogleApis + "accounts:signUp?key=" + KeyAplication;
            else
                return "";
        }

    }
}
