using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FruitsAndFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            if (Application.Current.Properties["ProfilePicture"] != null)
                imgPerfil.Source = Application.Current.Properties["ProfilePicture"].ToString();

            if (Application.Current.Properties["Id"] != null)
                lblId.Text = lblId.Text + Application.Current.Properties["Id"].ToString();

            if (Application.Current.Properties["FirstName"] != null)
                lblNombre.Text = lblNombre.Text + Application.Current.Properties["FirstName"].ToString();

            if (Application.Current.Properties["LastName"] != null)
                lblApellido.Text = lblApellido.Text + Application.Current.Properties["LastName"].ToString();

            if (Application.Current.Properties["EmailAddress"] != null)
                lblEmail.Text = lblEmail.Text + Application.Current.Properties["EmailAddress"].ToString();

        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}