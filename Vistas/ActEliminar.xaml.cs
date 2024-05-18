using EFARINANGOS6.Models;
using System.Net;
using System.Text;

namespace EFARINANGOS6.Vistas;

public partial class ActEliminar : ContentPage
{

    public ActEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var id = txtCodigo.Text;
        string url = "http://192.168.100.12/APPS/Proyecto_visual_app/db/wsestudiantes.php?codigo="+id;
        string query = "&nombre="+txtNombre.Text+"&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
           var res =  cliente.UploadValues(url+query, "PUT", parametros);
            // Convertir la respuesta en un string
            string responseString = Encoding.UTF8.GetString(res);

            // Mostrar la respuesta en la consola
            //Console.WriteLine(responseString);
             Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
        {
            DisplayAlert("", "", "ok");
        }

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmación", "¿Desea eliminar el registro?", "Sí", "No");

        if (answer)
        {
            var id = txtCodigo.Text;
            string url = "http://192.168.100.12/APPS/Proyecto_visual_app/db/wsestudiantes.php?codigo=" + id;
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                var res = cliente.UploadValues(url, "DELETE", parametros);
                Navigation.PushAsync(new vEstudiante());

            }
            catch (Exception ex)
            {
                DisplayAlert("", "", "ok");
            }

        }
        else
        {
            // Acción si el usuario elige "No"
            await DisplayAlert("Cancelado", "La actualización ha sido cancelada.", "OK");
        }


      
    }
}