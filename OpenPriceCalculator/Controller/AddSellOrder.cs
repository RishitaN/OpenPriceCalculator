using Open_Price_Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Controller
{
    public class AddSellOrder
    {
        public static bool AddSell(int id, float price, int volume, DateTime dt)
        {
            bool res;
            try
            {
                SellOrder s = new SellOrder();
                s.SellId = id;
                s.SellPrice = price;
                s.SellVolume = volume;
                s.SellOrderTime = dt;

                OrderBook Order = OrderBook.Instance();
                Order.SellBook.Add(s);
                //Order.SellBook.OrderByDescending(x => x.SellPrice);

                res = true;
            }

            catch (Exception ex)
            {
                //can improve to display error msg nicely
                throw ex;

            }

            return res;

        }
    }
}