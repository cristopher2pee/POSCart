using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace POSCart.Controllers
{
    public class ButtonAttribute
    {
        public static Style setButtonAttribCart()
        {

            var setButtonAttribCart = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter { Property= Button.VerticalOptionsProperty, Value= LayoutOptions.Start},
                    new Setter { Property=Button.TextColorProperty,  Value=Color.White},
                    new Setter { Property =Button.BackgroundColorProperty, Value = Color.RoyalBlue },
                    new Setter{ Property=Button.HeightRequestProperty, Value=100},
                    new Setter{ Property=Button.HorizontalOptionsProperty, Value=LayoutOptions.FillAndExpand},
                    new Setter{ Property=Button.BorderColorProperty, Value=Color.White},
                    new Setter{ Property=Button.FontSizeProperty, Value=25}

                }
            };

            return setButtonAttribCart;
        }

        public static Style setButtonAttribProduct()
        {
            var setButtonAttribProduct = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter { Property= Button.VerticalOptionsProperty, Value= LayoutOptions.FillAndExpand},
                    new Setter { Property=Button.TextColorProperty,  Value=Color.White},
                    new Setter { Property =Button.BackgroundColorProperty, Value = Color.DarkBlue },
                    new Setter{ Property=Button.WidthRequestProperty, Value=150},
                    new Setter{ Property=Button.HorizontalOptionsProperty, Value=LayoutOptions.Start},
                    new Setter{ Property=Button.BorderColorProperty, Value=Color.White}
                }
            };
            return setButtonAttribProduct;
        }

        public static Style setButtonAttribProductDetail()
        {
            var setButtonAttribProduct = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter { Property= Button.VerticalOptionsProperty, Value= LayoutOptions.FillAndExpand},
                    new Setter { Property=Button.TextColorProperty,  Value=Color.White},
                    new Setter { Property =Button.BackgroundColorProperty, Value = Color.DodgerBlue },
                    new Setter{ Property=Button.WidthRequestProperty, Value=150},
                    new Setter{ Property=Button.HorizontalOptionsProperty, Value=LayoutOptions.Start}
                }
            };
            return setButtonAttribProduct;
        }

    }
}
