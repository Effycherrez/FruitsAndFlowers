using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FruitsAndFlowers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {

            try
            {
                String usuario = Convert.ToString(txtuser.Text);
                String clave = Convert.ToString(txtclave.Text);
                if (usuario == "estudiante2021" && clave == "uisrael2021")
                {
                    await Navigation.PushAsync(new Inicio());
                }
                else
                {
                    await DisplayAlert("Alerta", "Inserte sus credenciales de forma correcta", "Gracias");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Gracias");
            }


        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
			string clientId = null;
			string redirectUri = null;


			switch (Device.RuntimePlatform)
			{
				/*case Device.iOS:
					clientId = Constantes.GoogleiOSClientId;
					redirectUri = Constantes.GoogleiOSRedirectUrl;
					break;
				*/
				case Device.Android:
					clientId = Constantes.GoogleAndroidClientId;
					redirectUri = Constantes.GoogleAndroidRedirectUrl;
					break;
			}

			var authenticator = new OAuth2Authenticator(
				clientId,
				null,
				Constantes.GoogleScope,
				new Uri(Constantes.GoogleAuthorizeUrl),
				new Uri(redirectUri),
				new Uri(Constantes.GoogleAccessTokenUrl),
				null,
				true);

			authenticator.Completed += OnAuthCompleted;
			authenticator.Error += OnAuthError;

			StatusAutentificacion.Authenticator = authenticator;

			var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
			presenter.Login(authenticator);
		}
		async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
		{
			var authenticator = sender as OAuth2Authenticator;
			if (authenticator != null)
			{
				authenticator.Completed -= OnAuthCompleted;
				authenticator.Error -= OnAuthError;
			}


			if (e.IsAuthenticated)
			{

				Usuarios user = null;

				var request = new OAuth2Request("GET", new Uri(Constantes.GoogleUserInfoUrl), null, e.Account);
				var response = await request.GetResponseAsync();
				if (response != null)
				{
					string userJson = await response.GetResponseTextAsync();
					user = JsonConvert.DeserializeObject<Usuarios>(userJson);
				}


				Application.Current.Properties.Remove("Id");
				Application.Current.Properties.Remove("FirstName");
				Application.Current.Properties.Remove("LastName");
				Application.Current.Properties.Remove("DisplayName");
				Application.Current.Properties.Remove("EmailAddress");
				Application.Current.Properties.Remove("ProfilePicture");

				Application.Current.Properties.Add("Id", user.Id);
				Application.Current.Properties.Add("FirstName", user.GivenName);
				Application.Current.Properties.Add("LastName", user.FamilyName);
				Application.Current.Properties.Add("DisplayName", user.Name);
				Application.Current.Properties.Add("EmailAddress", user.Email);
				Application.Current.Properties.Add("ProfilePicture", user.Picture);
				await Navigation.PushAsync(new Inicio());

			}
		}
		void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }
    }
}
