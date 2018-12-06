using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    
    class DashBoard : ContentPage
    {
        private StackLayout stkLAyout,stkLayoutHor;
        private Frame frmheader;
        public ListView lvMenu { get; set; }
       

        public DashBoard()
        {
            Title = "SII";
            Icon = "Icon.png";
            frmheader = new Header();

            if (Settings.Settings.rol.Equals("Alumno"))
            {
                lvMenu = new MenuItem();
            }else
            {
                lvMenu = new MenuItemsMaestros();
            }


            stkLayoutHor = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new Image
                    {
                        Source ="migue.jpg",
                        HeightRequest =30
                    },
                    new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        Text = "TECNM | Instituto Tecnologico de Celaya",
                        FontSize = 12,FontFamily ="Roboto"
                    }
                }
            };
            stkLAyout = new StackLayout
            {
                Children =
                {
                    frmheader,

                    lvMenu,
                   // stkLayoutHor
                }
            };
            Content = stkLAyout;
        }
    }
}




