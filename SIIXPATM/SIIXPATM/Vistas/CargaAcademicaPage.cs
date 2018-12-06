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
    class CargaAdemicaPage : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.CargaAcademica> list_inst;
        private WSCargaacademica objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public CargaAdemicaPage()
        {
            list_inst = new List<Modelos.CargaAcademica>();
            objWsKardex = new WSCargaacademica();
            //   NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación
            DashBoard dashBoard = new DashBoard();

            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {

            menuPage = new DashBoard();
            menuPage.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);
            var lblmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text="CveMat",
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Materia",
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            var lblGrupo = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Grupo",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };

            var lblDia = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Dia",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            var lblhorario = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Horario",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };



            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellCargaAcademica))
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
                        Padding = new Thickness (30),
                        Children ={lblmateria,lblMateria,lblGrupo,lblDia,lblhorario }
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
               // await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].cvemat);
                
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellCargaAcademica : ViewCell
    {
        public ResultCellCargaAcademica()
        {
            int width = 100, heigh = 35;

            var lblmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = width,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblmateria.SetBinding(Label.TextProperty, "cvemat");
            var lblMateria = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblMateria.SetBinding(Label.TextProperty, "nombre");
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

            var lblDia = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblDia.SetBinding(Label.TextProperty, "dia");
            var lblhorario = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblhorario.SetBinding(Label.TextProperty, "horario");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblmateria,
                    lblMateria,
                    lblGrupo,
                    lblDia,
                    lblhorario
                }
            };
            View = stackList;
        }

    }
}
