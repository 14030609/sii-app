using SIIXPATM.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class MenuItem : ListView
    {

        public MenuItem()
        {
            List<Item> lista = new List<Item>();
            lista.Add(
                new Item() { titulo = "Ver Carga Academica",
                    page = typeof(CargaAdemicaPage),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Add materia",
                    page = typeof(AddMateria),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Consulta Calificaciones",
                    page = typeof(CalificacionesPage),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Ver Kardex",
                    page = typeof(kardexPage),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Actulizar datos",
                    page = typeof(ActualizaDatosAlumno),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Enviar correo",
                    page = typeof(MaestrosPage),
                }
                );

            lista.Add(
                new Item()
                {
                    titulo = "Cerrar Sesion",
                    page = typeof(MainPage),
                }
                );


            ItemsSource = lista;
            DataTemplate celda = new DataTemplate(typeof(ImageCell));
            celda.SetBinding(TextCell.TextProperty, "titulo");
            celda.SetBinding(ImageCell.ImageSourceProperty, "icono");
            ItemTemplate = celda;
            
        }
    }

}
