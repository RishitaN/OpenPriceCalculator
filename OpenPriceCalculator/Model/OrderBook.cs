using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Model
{
    public class OrderBook
    {
        public  List<BuyOrder> BuyBook;

        public  List<SellOrder> SellBook;

       

        private static OrderBook _instance = null;

        private static readonly object check = new object();

        //This is the main OrderBook, only one instance should exist
        public static OrderBook Instance()
        {
            //get{
                lock (check)
                {
                    if(_instance == null)
                    {
                        _instance = new OrderBook();
                        _instance.BuyBook = new List<BuyOrder>();
                        _instance.SellBook = new List<SellOrder>();
                    }
                    return _instance;
                }
                
            //}
            
        }



    }
}