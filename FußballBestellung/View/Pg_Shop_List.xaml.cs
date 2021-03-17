﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FußballBestellung
{
    /// <summary>
    /// Interaction logic for Pg_Shop.xaml
    /// </summary>
    public partial class Pg_Shop_List : Page
    {
        Football football1;
        Football football2;
        Football football3;
        Football football4;

        List<Football> footballs = new List<Football>();
        List<Football> cart = new List<Football>();
        List<Football> shopItems;
        double totalPrice = 0;
        public Pg_Shop_List()
        {
            InitializeComponent();

            football1 = new Football("LGE Uniforia", 5, "Adidas", 18.70, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "/Images/adidas-lge-uniforia.png");
            footballs.Add(football1);
            football2 = new Football("68er Light Fussbal F126", 5, "Derbystar", 11.48, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "/Images/68er Light Fussbal F126.png");
            footballs.Add(football2);
            football3 = new Football("Tri Concept 2.0 Ultra", 5, "Uhlsport", 16.77, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "/Images/Tri Concept 2.0 Ultra Lite 290 Gramm F01.png");
            footballs.Add(football3);
            football4 = new Football("Senzor Lightball", 5, "Erima", 14.97, Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "/Images/Senzor Lightball 350 Gramm.png");
            footballs.Add(football4);


            shopItems = new List<Football>();
            foreach(var item in footballs)
            {
                shopItems.Add(new Football() { Name = item.Name, Brand = item.Brand, Price = item.Price, ImagePath = item.ImagePath });
            }

            CustomItems.ItemsSource = shopItems;

        }

        //
        // Form Methods
        //

        private void ShopBtn_Add_Click(object sender, RoutedEventArgs e)
        {
            //ToDo getSelected Football as index
            cart.Add(footballs[0]);
            totalPrice += footballs[0].Price;
            displayCart();
            updateTotalPrice();
        }
        private void ShopBtn_Remove_Click(object sender, RoutedEventArgs e)
        {
            //if (cart.Count > 0 && cart.Contains(footballs[footballListCounter]))
            //{
            //    var x = getSelectedItem();
            //    cart.Remove(footballs[footballListCounter]);
            //    lbl_ItemsInCart.Content = $"Items in Cart: {cart.Count}";
            //    totalPrice -= footballs[footballListCounter].Price;
            //    displayCart();
            //    updateTotalPrice();
            //}
        }

        //
        //Navigation
        //
        private void ShopBtn_Submit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pg_Delivery(cart, totalPrice));
        }



        //
        //Helper
        //


        ListBoxItem addListBoxItem()
        {
            var ListBoxItem = new ListBoxItem();

            return ListBoxItem;
        }
        void updateTotalPrice()
        {
            lbl_Cart_Price_Value.Content = $"{totalPrice.ToString("C2")}";
        }

        //fills tb_cart with items in cart
        void displayCart()
        {
            string list = "";
            foreach (var item in cart)
            {
                list += item.Name + Environment.NewLine;
            }

            tb_cart.Text = list;
        }

        
    }
}
