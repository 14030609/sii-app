using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SIIXPATM.Vistas
{
    class Header : Frame
    {
        private RelativeLayout rlayout;
        public Header()
        {
            BoxView boxFondo = new BoxView
            {
                Color = Color.Black,
            };
            Image logo = new Image
            {

                Source = "itcelaya2.png"
            };
            Label nombre = new Label
            {
                Text ="Miguel Angel Velazquez Ayala",
            };
            rlayout = new RelativeLayout();
            rlayout.Children.Add(
                boxFondo,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent)=> { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; })
                );
            rlayout.Children.Add
                (
                logo,
                Constraint.Constant(0),
                Constraint.Constant(10),
                Constraint.RelativeToParent((parent) => { return parent.Width*.5; }),
                Constraint.RelativeToParent((parent) => { return parent.Height*.5; })
                );
            rlayout.Children.Add(
               nombre,
               Constraint.Constant(5),
               Constraint.Constant(150),
               Constraint.RelativeToParent((parent) => { return parent.Width * .1; }),
                Constraint.RelativeToParent((parent) => { return parent.Height * .1; })
               );
            Content = rlayout;
        }
    }
}
