using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FruitsAndFlowers
{
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
                    await Navigation.PushAsync(new menu());
                }
                else
                {
                    DisplayAlert("Alerta", "Inserte sus credenciales de forma correcta", "Gracias");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Gracias");
            }


        }
    }
}
