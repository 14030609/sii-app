using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    public class KardexP : ContentPage
    {
        private StackLayout stKardex;
        private Label lblMateria, lblOportunidad, lblCalificacion;

        public KardexP()
        {
            //InitializeComponent();
            Padding = new Thickness(20);
            BackgroundColor = Color.FromHex("#BBFFFF");

            lblMateria = new Label
            {
                Text = "Materia",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblOportunidad = new Label
            {
                Text = "Oportunidad",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblCalificacion = new Label
            {
                Text = "Calificacion",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            stKardex = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 500,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
            lblMateria,
            lblOportunidad,
            lblCalificacion
            }
            };



            Content = stKardex;



        }

    }
}
