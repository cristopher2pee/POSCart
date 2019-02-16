using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POSCart.Controllers;
using POSCart.Models;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;

namespace POSCart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesPage : ContentPage
    {
        public SalesPage()
        {
            InitializeComponent();
            Init();
        }

        private List<Button> listButtonProduct;
        private List<Button> listProductDetailRow1;
        private List<Button> listProductDetailRow2;
        private List<Button> listProductDetailRow3;
        List<SalesViewModel> salesList = new List<SalesViewModel>();
        Button productDetailBtn;




        void Init()
        {
            LoadListofCart();

        }

        private void LoadListofCart()
        {
            int valuLength = 3;

            for (int ctr = 0; ctr <= valuLength; ctr++)
            {
                Button button = new Button { Text = "Cart " + ctr, Style = ButtonAttribute.setButtonAttribCart(), ClassId = ctr.ToString() };
                button.Clicked += ClickedbuttonCart;

                FirstColumnGrid.Children.Add(button);
            }
        }

        private void CancelClickSales(object o, EventArgs e)
        {
            salesList = new List<SalesViewModel>();
            PopulateListView();
            
        }
            

        private void DeleteSelectedItem(object o, EventArgs e)
        {
            if (ListViewItemCells.ItemsSource != null )
            {
                if (salesList.Count > 0)
                {
                    if (ListViewItemCells.SelectedItem != null)
                    {
                        var svm = ListViewItemCells.SelectedItem as SalesViewModel;
                        ListViewItemCells.SelectedItem = null;

                        if (svm != null)
                        {
                            if (salesList.Count > 0)
                            {
                                var itemRemove = salesList.Single(f => f.ProductId == svm.ProductId);
                                salesList.Remove(itemRemove);
                            }
                            PopulateListView();
                        }
                    }
                }
            }

        }        

        private void ClickedButtonProduct(object o, EventArgs e)
        {
            Button b = (Button)o;
            StockChildrenDetailRowsRemove();
            listProductDetailRow1 = new List<Button>();
            listProductDetailRow2 = new List<Button>();
            listProductDetailRow3 = new List<Button>();
           // DisplayAlert(b.ClassId.ToString(), "", "OK");

            int valuLength = Convert.ToInt32(b.ClassId.ToString());
            for (int ctr = 0; ctr <= valuLength; ctr++)
            {
                Button button = new Button { Text = "ProductDetail" + ctr, Style = ButtonAttribute.setButtonAttribProductDetail(), ClassId = ctr.ToString() };
                button.Clicked += ClickedProductDetail;

                if (ctr >= 0 && ctr <= 5)
                {
                    StockLayoutContainerRow1.Children.Add(button);
                    listProductDetailRow1.Add(button);
                }

                else if (ctr >= 6 && ctr <= 10)
                {
                    StockLayoutContainerRow2.Children.Add(button);
                    listProductDetailRow2.Add(button);
                }

                else if (ctr >= 11 && ctr <= 15)
                {
                    StockLayoutContainerRow3.Children.Add(button);
                    listProductDetailRow3.Add(button);
                }
                //else
                //{
                //    StockLayoutContainerRow4.Children.Add(button);
                //}

                // ProductbyCartLayout.Children.Add(button);
                //listButtonProduct.Add(button);
            }

        }
      

        private void ClickedProductDetail(object o, EventArgs e)
        {
           
            productDetailBtn = (Button)o;
            //productDetailBtn.IsEnabled = false;


            var popuppage = new QuantityPopupPage();
            popuppage.getData += SetListViewData;

          
            PopupNavigation.Instance.PushAsync(popuppage);
            
          //  productDetailBtn.IsEnabled = true;
        }


        protected void SetListViewData(object o, EventArgs e)
        {

            int Id = salesList.Count + 1;
            getQuantityData ea = (getQuantityData)e;
            decimal _TotalPrice = 60.30m * ea.quantity;
            var getSVMfromModal = new SalesViewModel { ProductDetailName = productDetailBtn.Text.ToString(), Quantity = ea.quantity, TotalPrice = _TotalPrice, ProductId = Id };
            //SalesViewModel getDatafromList = null;        
            
            //if (salesList.Count > 0)
            //{
            //    getDatafromList = new SalesViewModel();
            //     getDatafromList = salesList.SingleOrDefault(f => f.ProductDetailName == getSVMfromModal.ProductDetailName);
            //}

            //if(getDatafromList!=null)
            //{
            //    salesList.Remove(getDatafromList);
            //    getSVMfromModal.Quantity = getDatafromList.Quantity + getSVMfromModal.Quantity;
            //    getSVMfromModal.TotalPrice = getSVMfromModal.Quantity * _TotalPrice;
            //}

            salesList.Add(getSVMfromModal);
            salesList.GroupBy(f => f.ProductDetailName);
            PopulateListView();
            //productDetailBtn.IsEnabled = true;
        }

        private void ClickedbuttonCart(object o, EventArgs e)
        {
            RemoveChildrenInStocklayout();  
            StockChildrenDetailRowsRemove();
            listButtonProduct = new List<Button>();
            Button b = (Button)o;
           // DisplayAlert(b.ClassId.ToString(), "", "OK");

            int valuLength = 0;

            if(Convert.ToInt32(b.ClassId) == 0)
            {
                valuLength = 15;
            }
            else
            {
                valuLength = 5;
            }
            

            for (int ctr = 0; ctr <= valuLength; ctr++)
            {
                Button button = new Button { Text = "Produc" + ctr, Style = ButtonAttribute.setButtonAttribProduct(), ClassId = ctr.ToString() };
                button.Clicked += ClickedButtonProduct;

                ProductbyCartLayout.Children.Add(button);
                listButtonProduct.Add(button);
            }


        }

        private void PopulateListView()
        {
            var culture = System.Globalization.CultureInfo.GetCultureInfo("phi");
            ListViewItemCells.ItemsSource = null;
            ListViewItemCells.ItemsSource = salesList;
            lblTotalSales.Text = string.Format(culture,"{0:C}", salesList.Sum(f => f.TotalPrice));
           // lblTotalSales.Text = salesList.Sum(f => f.TotalPrice).ToString();
        }
            

        private void RemoveChildrenInStocklayout()
        {
            if (listButtonProduct != null)
            {
                if (listButtonProduct.Count > 0)
                {
                    foreach (var ss in listButtonProduct)
                    {
                        ProductbyCartLayout.Children.Remove(ss);
                    }
                }
            }
        }

        private void StockChildrenDetailRowsRemove()
        {
            if(listProductDetailRow1 != null)
            {
                if(listProductDetailRow1.Count > 0)
                {
                    foreach(var ss in listProductDetailRow1)
                    {
                        StockLayoutContainerRow1.Children.Remove(ss);
                    }
                }
            }

            if (listProductDetailRow2 != null)
            {
                if (listProductDetailRow2.Count > 0)
                {
                    foreach (var ss in listProductDetailRow2)
                    {
                        StockLayoutContainerRow2.Children.Remove(ss);
                    }
                }
            }

            if (listProductDetailRow3 != null)
            {
                if (listProductDetailRow3.Count > 0)
                {
                    foreach (var ss in listProductDetailRow3)
                    {
                        StockLayoutContainerRow3.Children.Remove(ss);
                    }
                }
            }


        }

       
    }

    public class getQuantityData : System.EventArgs
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    public class MessageDelateRespond : System.EventArgs
    {
        //true for yes and fales for no
        public bool isRepond { get; set;}
        public int productId { get; set; }
    }
}