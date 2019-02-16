using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace POSCart.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuantityPopupPage : PopupPage
    {

        private string lblQuantity = string.Empty;

        public event EventHandler getData;

		public QuantityPopupPage ()
		{
			InitializeComponent ();
		}

        private void BtnClickedNo(object o, EventArgs e)
        {
            Button b = (Button)o;

            if(b.ClassId.ToString() == "1")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "1";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "2")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "2";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "3")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "3";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "4")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "4";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "5")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "5";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "6")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "6";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "7")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "7";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "8")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "8";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "9")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "9";
                lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "Clear")
            {
                lblTotalQuantity.Text = "0";
            }
            else if(b.ClassId.ToString() == "0")
            {
                lblTotalQuantity.Text = lblTotalQuantity.Text + "0";
               // lblTotalQuantity.Text = lblTotalQuantity.Text.TrimStart('0');
            }
            else if (b.ClassId.ToString() == "Enter")
            {
                // lblTotalQuantity.Text = lblTotalQuantity.Text + "0";
                if (Convert.ToInt32(lblTotalQuantity.Text) > 0)
                {
                    if (getData != null)
                    {
                        getData(this, new getQuantityData { productId = 0, quantity = Convert.ToInt32(lblTotalQuantity.Text) });
                    }

                    PopupNavigation.Instance.PopAllAsync(true);
                    //PopupNavigation.Instance.PopAsync(true);
                    
                }
            }



        }

        public static int Quantity { get; set; }
	}
}