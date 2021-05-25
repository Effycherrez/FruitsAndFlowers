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
               
        private async  void bntRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {

                    await Navigation.PushAsync(new Registro());
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Gracias");
            }
        }

        private async void bntRecuperar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recuperar());
        }
    }
}
