using EFARINANGOS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EFARINANGOS6.Vistas;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.100.12/APPS/Proyecto_visual_app/db/wsestudiantes.php";
	private readonly HttpClient estudiante = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();

    }

	public async void ObtenerDatos()
	{
		var content = await estudiante.GetStringAsync(url);
		List<Estudiante> mostra =  JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostra);
		listEstudiante.ItemsSource = est;
	}
}