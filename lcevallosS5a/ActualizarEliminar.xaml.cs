using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lcevallosS5a
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEliminar : ContentPage
    {
        public ActualizarEliminar(int codigo, string nombre, string apellido, int edad ) 
        {
            InitializeComponent();
            txtCodigo.Text= codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text= apellido;
            txtEdad.Text = edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre=", txtNombre.Text);
                parametros.Add("apellido=", txtApellido.Text);
                parametros.Add("edad=", txtEdad.Text);
                cliente.UploadValues("http://192.168.16.30/ws_uisrael/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues("http://192.168.16.30/ws_uisrael/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}