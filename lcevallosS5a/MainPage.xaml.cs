﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace lcevallosS5a
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.16.30/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;

        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        //con esto sin aplastar el boton ya salen los datos

        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Estudiante> listaPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(listaPost);
            listaEstudiantes.ItemsSource = post;
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Insertar());
            
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto=(Estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo =Convert.ToInt32(codigoTem);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadTem = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadTem);

            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }
    }
}
