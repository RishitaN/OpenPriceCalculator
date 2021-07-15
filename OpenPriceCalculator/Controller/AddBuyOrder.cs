using Open_Price_Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Controller
{
    public class AddBuyOrder
    {
        //this method will take input from user and then add  for the BuyOrder
        public static bool AddBuy(int id, float price, int volume, DateTime dt)
        {
            bool res;
            try
            {
                BuyOrder b = new BuyOrder();
                b.BuyId = id;
                b.BuyPrice = price;
                b.BuyVolume = volume;
                b.BuyOrderTime = dt;

                OrderBook Order = OrderBook.Instance();
                Order.BuyBook.Add(b);
                Order.BuyBook.OrderByDescending(x => x.BuyPrice);

                res = true;
            }

            catch(Exception ex)
            {
                //can improve to display error msg nicely
                throw ex;                

            }     

            return res;

        }


        BuyOrder b1 = new BuyOrder()
        {
            BuyId = 1,
            BuyPrice = 100,
            BuyVolume = 10

        };

        BuyOrder b2 = new BuyOrder()
        {
            BuyId = 2,
            BuyPrice = 99,
            BuyVolume = 50

        };
        BuyOrder b3 = new BuyOrder()
        {
            BuyId = 3,
            BuyPrice = 98,
            BuyVolume = 100

        };
        BuyOrder b4 = new BuyOrder()
        {
            BuyId = 4,
            BuyPrice = 97,
            BuyVolume = 30

        };
        BuyOrder b5 = new BuyOrder()
        {
            BuyId = 4,
            BuyPrice = 97,
            BuyVolume = 30

        };
        BuyOrder b6 = new BuyOrder()
        {
            BuyId = 4,
            BuyPrice = 97,
            BuyVolume = 30

        };
    }
}