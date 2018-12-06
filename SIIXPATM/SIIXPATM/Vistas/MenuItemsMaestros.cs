using SIIXPATM.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class MenuItemsMaestros : ListView
    {

        public MenuItemsMaestros()
        {
            List<Item> lista = new List<Item>();
            lista.Add(
                new Item()
                {
                    titulo = "Ver Grupos",
                    page = typeof(AddMateria),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Ver Alumnos",
                    page = typeof(AlumnosPage),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Actualizar datos",
                    page = typeof(ActualizaDatosAlumno),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Enviar correo",
                    page = typeof(AlumnosCorreo),
                }
                );
            lista.Add(
                new Item()
                {
                    titulo = "Actualizar Calificaciones",
                    page = typeof(GruposCalificar),
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
