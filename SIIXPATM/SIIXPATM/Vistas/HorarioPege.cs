using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    public class HorarioPege : ContentPage
    {
        private StackLayout stDatos;
        private StackLayout stHorario;
        private Label lblNombre,lblEspecialidad,lblNoControl;
        private Label lblNoGrupo, lblSalon, lblMateria,lblMaestro,lblDia,lblHoras;

        public HorarioPege()
         {
            //InitializeComponent();
            Padding = new Thickness(20);
            BackgroundColor = Color.FromHex("#BBFFFF");

            lblNombre = new Label
            {
                Text = "Nombre",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblEspecialidad = new Label
            {
                Text = "Especialidad",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblNoControl = new Label
            {
                Text = "NoControl",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            lblNoGrupo = new Label
            {
                Text = "Grupo",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblSalon = new Label
            {
                Text = "Salon",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblMateria = new Label
            {
                Text = "Materia",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            lblMaestro = new Label
            {
                Text = "Maestro",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblDia = new Label
            {
                Text = "Día",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lblHoras = new Label
            {
                Text = "Horas",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
           
            stHorario = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 500,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
            lblNoGrupo,
            lblSalon,
            lblMateria,
            lblMaestro,
            lblDia,
            lblHoras
            
            }
            };


            stDatos = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 500,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
            lblNombre,
            lblEspecialidad,
            lblNoControl,
            stHorario

            }
            };

            
            Content = stDatos;



        }

    }
}
