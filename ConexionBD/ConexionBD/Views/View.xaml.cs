using ConexionBD.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConexionBD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View : ContentPage
    {
        public View()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (datos())
            {
                persona Persona = new persona
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = int.Parse(txtEdad.Text),
                };
                await App.SQLiteDB.SavePersonaAsync(Persona);
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                await DisplayAlert("Alerta", "Se han guardado los datos correctamente", "Aceptar");
                var personaList = await App.SQLiteDB.GetpersonasAsync();
                if (personaList!=null)
                {
                    Lstpersona.ItemsSource = personaList;
                }
            }

                
            else
            {
                await DisplayAlert("Error", "Ingresar todos Los Datos", "ok");
            }

            
            }
         public bool datos()
             {
            bool resp;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                resp = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                resp = false;
            }
            else
            {
                resp = true;
            }
            return resp;
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}