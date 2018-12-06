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
    class kardexPage : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Kardex> list_inst;
        private WSKardex objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public kardexPage()
        {
            list_inst = new List<Modelos.Kardex>();
            objWsKardex = new WSKardex();
            //   NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación
            DashBoard dashBoard = new DashBoard();

            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {

            menuPage = new DashBoard();
            menuPage.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);
            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Materia",
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            var lblOportunidad = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "oportunidad",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };

            var lblCalificacion = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Calificacion",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            var lblsemestre = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Semestre",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellCargaKardex))
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
                        Children ={lblMateria,lblOportunidad,lblCalificacion,lblsemestre }
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
                list_inst = await objWsKardex.getKardex();
                await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].calif);

                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellCargaKardex : ViewCell
    {
        public ResultCellCargaKardex()
        {
            int width = 100, heigh = 35;

            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblMateria.SetBinding(Label.TextProperty, "materia");
            var lblOportunidad = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblOportunidad.SetBinding(Label.TextProperty, "oportunidad");

            var lblCalif = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblCalif.SetBinding(Label.TextProperty, "calif");
            var lblsemestre = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblsemestre.SetBinding(Label.TextProperty, "semestre");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblMateria,
                    lblOportunidad,
                    lblCalif,
                    lblsemestre
                }
            };
            View = stackList;
        }

    }
}
