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
    class KardexPage2 : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Grupo> list_inst;
        private WSGrupos objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public KardexPage2()
        {
            list_inst = new List<Modelos.Grupo>();
            objWsKardex = new WSGrupos();
         //   NavigationPage.SetHasNavigationBar(this, false);  //eliminar barra de navegación
            DashBoard dashBoard = new DashBoard();

            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {

            menuPage = new DashBoard();
            menuPage.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);

            /*
                        lblMateria= new Label
                        {
                            Text = "Materia",
                            FontSize = 15,
                            TextColor = Color.FromHex("#003399"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        };
                        lblNogpo = new Label
                        {
                            Text = "grupo",
                            FontSize = 15,
                            TextColor = Color.FromHex("#003399"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        };
                        lblMaestro = new Label
                        {
                            Text = "maestro",
                            FontSize = 15,
                            TextColor = Color.FromHex("#003399"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        };

                        lblSalon = new Label
                        {
                            Text = "salon",
                            FontSize = 15,
                            TextColor = Color.FromHex("#003399"),
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        };

                        stGrupos = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HeightRequest = 500,
                            WidthRequest = 400,
                            HorizontalOptions = LayoutOptions.Center,
                            Children =
                        {
                        lblMateria,
                        lblNogpo,
                        lblMaestro,
                        lblSalon
                        }
                        };


                */




            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellGrupos))
            };

            st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(20),
                Children =
                {
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
                NavigationPage.SetHasNavigationBar(this, true);  //eliminar barra de navegación

                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.getKardex();
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellGrupos : ViewCell
    {
        public ResultCellGrupos()
        {
            int width = 100, heigh = 35;

            var lblmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = width,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblmateria.SetBinding(Label.TextProperty, "materia");
            var lblOportunity = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblOportunity.SetBinding(Label.TextProperty, "nogpo");
            var lblQualification = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblQualification.SetBinding(Label.TextProperty, "maestro");

            var lblSemester = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblSemester.SetBinding(Label.TextProperty, "salon");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblmateria,
                    lblOportunity,
                    lblQualification,
                    lblSemester
                }
            };
            View = stackList;
        }

    }
}
