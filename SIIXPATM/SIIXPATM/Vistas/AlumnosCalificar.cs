using SIIXPATM.Vistas;
using SIIXPATM.WebServices;
using System;
using SIIXPATM.Modelos;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class AlumnosCalificar : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Alumnos> list_inst;
        private WSAlumnosMateria objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public AlumnosCalificar()
        {
            list_inst = new List<Modelos.Alumnos>();
            objWsKardex = new WSAlumnosMateria();
            //   NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación
            DashBoard dashBoard = new DashBoard();

            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {

            menuPage = new DashBoard();
            menuPage.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);
            var lblGrupo = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "grupo",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            var lblAlumno = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "alumno",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };


            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellAlumnosCalificar))
            };
            lv_inst.ItemSelected += (sender, e) =>
            {

                Alumnos objIns = (Alumnos)e.SelectedItem;

                Settings.Settings.AlumnoName = objIns.alumno;
                Settings.Settings.nocont = objIns.nocont;
                Settings.Settings.AlumnoEmail = objIns.email;

                DisplayAlert("Alumno seleccionado", Settings.Settings.AlumnoName + "\n" +
                    Settings.Settings.nocont + "\n"
                    + Settings.Settings.AlumnoEmail + "\n", "Aceptar");
                //Agregar con settings 
                //                                App.Current.MainPage = new DashBoard();
                Navigation.PushModalAsync(new Calificaciones());

            };

            st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(20),
                Children =
                {
                    new StackLayout(){
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Padding = new Thickness (20),
                        Children ={lblGrupo,lblAlumno}
                    },
                    lv_inst
                }
            };
            Content = st_inst;
        }

        public void NavigationToPage(Item item)
        {
            Page pagina = (Page)Activator.CreateInstance(item.page);
            NavigationPage Detail = new NavigationPage(pagina);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                //                NavigationPage.SetHasNavigationBar(this, true);  //eliminar barra de navegación

                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.getALumnos("Ma1","1");
                   await DisplayAlert("Correcto", "Acceso correcto", "materia " + list_inst[0].nocont+" nogpo"+ list_inst[0].nogpo);

                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellAlumnosCalificar : ViewCell
    {
        public ResultCellAlumnosCalificar()
        {
            int width = 100, heigh = 35;

            var lblGrupo = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblGrupo.SetBinding(Label.TextProperty, "nogpo");

            var lblAlumno = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblAlumno.SetBinding(Label.TextProperty, "alumno");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblGrupo,
                    lblAlumno
                }
            };
            View = stackList;
        }

    }
}
