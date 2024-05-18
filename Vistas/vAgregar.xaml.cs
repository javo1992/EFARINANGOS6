using System.Net;

namespace EFARINANGOS6.Vistas;

public partial class vAgregar : ContentPage
{
    private const string url = "http://192.168.100.12/APPS/Proyecto_visual_app/db/wsestudiantes.php";
    public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues(url,"POST",parametros);
			Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
		{
			DisplayAlert("", "", "ok");
		}
    }
}