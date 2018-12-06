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

    class HorarioPage : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Horario> list_inst;
        private WSHorario objWsHorario;
        public HorarioPage()
        {
            list_inst = new List<Modelos.Horario>();
            objWsHorario = new WSHorario();
            CrearGUIAsync();
        }
        public void CrearGUIAsync()
        {
            NavigationPage.SetHasNavigationBar(this, true);  //eliminar barra de navegación

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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                lv_inst.IsVisible = false;
                list_inst = await objWsHorario.getHorario(Settings.Settings.email);
                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }
    }
    class ResultCellHorarios : ViewCell
    {
        public ResultCellHorarios()
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
            lblmateria.SetBinding(Label.TextProperty, "cvemat");
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
            lblQualification.SetBinding(Label.TextProperty, "cvemae");

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
