using System;
using System.Collections.Generic;
using System.Text;

namespace FruitsAndFlowers
{
	public static class Constantes
	{
		public static string AppName = "fruitsandflowers";

		// Google Autorizacion
		public static string GoogleAndroidClientId = "807651629563-917c9lemantrt6ufbic16rqghmndbhrb.apps.googleusercontent.com";

		// Valores que permanecen constantes
		public static string GoogleScope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
		public static string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		public static string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		public static string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		// aqui colocamos nuestro id de maera inversa, primero com.googleusercontent.apps. luego los caracteres del ID  :/oauth2redirect appended
		public static string GoogleAndroidRedirectUrl = "com.googleusercontent.apps.807651629563-917c9lemantrt6ufbic16rqghmndbhrb:/oauth2redirect";


	}
}
