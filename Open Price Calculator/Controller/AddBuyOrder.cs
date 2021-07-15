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
        public static bool AddBuy(int id, double price, int volume, DateTime dt)
        {
            bool res;
            try
            {
                BuyOrder b = new BuyOrder();
                b.BuyId = id;
                b.BuyPrice = price;
                b.BuyVolume = volume;
                b.BuyOrderTime = dt;

                //OrderBook Order = OrderBook.Instance();
                OrderBook.BuyBook.Add(b);
                OrderBook.BuyBook.OrderByDescending(x => x.BuyPrice);

                res = true;

            }

            catch(Exception ex)
            {
                //can improve to display error msg nicely
                throw ex;                

            }     

            return res;

        }
    }
}