using SIIXPATM.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace SIIXPATM.Vistas
{
    class MasterDetail : MasterDetailPage
    {

        public MasterDetail()
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.lvMenu.ItemSelected += (sender, e) => NavigationToPage(e.SelectedItem as Item);
            this.Master = dashBoard;
            MainPage login = new MainPage();
            this.Detail = new NavigationPage(login);
        }

        public void NavigationToPage(Item item)
        {
            Page pagina = (Page)Activator.CreateInstance(item.page);
            Detail = new NavigationPage(pagina);
        }

    }
}
