﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FußballBestellung
{
    public class Football
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int Amount { get; set; }


        public Football(string name, int size, string brand, double price, string ImagePath)
        {
            this.Name = name;
            this.Size = size;
            this.Brand = brand;
            this.Price = price;
            this.ImagePath = ImagePath;
            this.Amount = 0;
        }
        public Football()
        {

        }
    }
}
