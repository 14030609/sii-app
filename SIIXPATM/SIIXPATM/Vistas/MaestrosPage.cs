﻿using SIIXPATM.Vistas;
using SIIXPATM.WebServices;
using System;
using SIIXPATM.Modelos;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class MaestrosPage : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Maestro> list_inst;
        private WSMaestro objWsKardex;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public MaestrosPage()
        {
            list_inst = new List<Modelos.Maestro>();
            objWsKardex = new WSMaestro();
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
                Text = "maestro",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            var lblAlumno = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "email",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };


            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellMaestros))
            };
            lv_inst.ItemSelected += (sender, e) =>
            {

                Maestro objIns = (Maestro)e.SelectedItem;

                Settings.Settings.AlumnoName = objIns.nombre;
                Settings.Settings.cvemae = objIns.cvemae;
                Settings.Settings.MaestroEmail = objIns.email;

                DisplayAlert("Alumno seleccionado", Settings.Settings.MaestroName + "\n" +
                    Settings.Settings.cvemae + "\n"
                    + Settings.Settings.AlumnoEmail + "\n", "Aceptar");
                //Agregar con settings 
                //                App.Current.MainPage = new DashBoard();
                 Navigation.PushModalAsync(new Correo());

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
                list_inst = await objWsKardex.getMaestros();
                //   await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].nocont);

                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellMaestros : ViewCell
    {
        public ResultCellMaestros()
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
            lblGrupo.SetBinding(Label.TextProperty, "nombre");

            var lblAlumno = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblAlumno.SetBinding(Label.TextProperty, "email");

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