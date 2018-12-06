using SIIXPATM;
using SIIXPATM.Modelos;
using SIIXPATM.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class DashBoardMaestro : MasterDetailPage
    {
        private DashBoard menuPage;
        private SIIXPATM.Vistas.AddMateria fondo;

        public DashBoardMaestro()
        {
            crearGui();
        }

        private void crearGui()
        {
            menuPage = new DashBoard();

                fondo = new SIIXPATM.Vistas.AddMateria();
                menuPage.lvMenu.ItemSelected += (Sender, e) => NavigationToPage(e.SelectedItem as Item);

                Master = menuPage;
                Detail = new NavigationPage(fondo);
            


        }
        public void NavigationToPage(Item item)
        {
            Page pagina = (Page)Activator.CreateInstance(item.page);
            Detail = new NavigationPage(pagina);
        }


    }
}