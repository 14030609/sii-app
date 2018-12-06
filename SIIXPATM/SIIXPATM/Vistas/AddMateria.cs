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
    class AddMateria : ContentPage
    {
        private ListView lv_inst;
        private StackLayout st_inst;
        private List<Modelos.Grupo> list_inst;
        private WSGrupos objWsKardex;
        private WSAlumnos actAlumno;
        private DashBoard menuPage;
        //   private Label lblMateria, lblNogpo, lblMaestro, lblSalon;

        public AddMateria()
        {
            list_inst = new List<Modelos.Grupo>();
            objWsKardex = new WSGrupos();
            actAlumno = new WSAlumnos();

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
            var lblMaestro = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Maestro",
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
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
            var lblHorario = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Horas",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            var lblSalon = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Salon",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            var lblHorteo = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Hor Teo",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            var lblHorpra = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Hor Pra",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };

            var lblCreditos = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 8,
                Text = "Creditos",
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };


            lv_inst = new ListView()
            {
                HasUnevenRows = true, //Estandarizar items
                ItemTemplate = new DataTemplate(typeof(ResultCellCalificaciones))
            };
            lv_inst.ItemSelected += (sender, e) =>
            {

                Grupo objIns = (Grupo)e.SelectedItem;

                listas lis =new  listas();

                Settings.Settings.nogpo = objIns.nogpo;
                Settings.Settings.cvemat = objIns.cvemat;
                DisplayAlert("Grupo seleccionado", Settings.Settings.nogpo + "\n" +
                    Settings.Settings.cvemat + "\n", "Aceptar");



                if (Settings.Settings.rol.Equals("Alumno"))
                {
                    lis.cvemat = objIns.cvemat;
                    lis.nogpo = objIns.nogpo;
                    lis.nocont = Settings.Settings.nocont;
                    lis.parcial_1 = 0;
                    lis.parcial_2 = 0;
                    lis.parcial_3 = 0;
                    lis.parcial_4 = 0;
                                   DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia lista " + lis.nocont+ " "+lis.cvemat +"  "+lis.nogpo);

                    actAlumno.actAlumno(lis);
                              //                await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].materia);


                }


                //          Navigation.PushModalAsync(new AlumnosCalificar());
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
                        Children ={lblMateria,lblGrupo,lblMaestro,lblDia,lblSalon,lblCreditos }
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
                NavigationPage.SetHasNavigationBar(this, true);  //eliminar barra de navegación

                lv_inst.IsVisible = false;
                list_inst = await objWsKardex.getKardex();
                //                await DisplayAlert("Correcto", "Acceso correcto", "Aceptar materia " + list_inst[0].materia);

                lv_inst.ItemsSource = list_inst;
                lv_inst.IsVisible = true;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }

        }

    }
    class ResultCellCalificaciones : ViewCell
    {
        public ResultCellCalificaciones()
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
            lblmateria.SetBinding(Label.TextProperty, "materia");
            var lblOportunity = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblOportunity.SetBinding(Label.TextProperty, "nogpo");
            var lblQualification = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
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
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblSemester.SetBinding(Label.TextProperty, "dia");
            var lblHorario = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblHorario.SetBinding(Label.TextProperty, "horario");


            var lblParcial_3 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblParcial_3.SetBinding(Label.TextProperty, "salon");

            var lblParcial_4 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 10,
                HeightRequest = heigh,
                WidthRequest = 50,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblParcial_4.SetBinding(Label.TextProperty, "creditos");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblmateria,
//                    lblOportunity,
                    lblQualification,
                    lblSemester,
                    lblHorario,
                    lblParcial_3,
                    lblParcial_4
                }
            };
            View = stackList;
        }

    }
}
