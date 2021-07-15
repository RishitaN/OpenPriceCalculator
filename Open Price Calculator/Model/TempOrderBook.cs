using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Model
{
    public class TempOrderBook
    {
        public List<BuyOrder> BuyBook;

        public List<SellOrder> SellBook;

        public TempOrderBook(){
            this.BuyBook = new List<BuyOrder>();
            this.SellBook = new List<SellOrder>();
        }

        public TempOrderBook(List<BuyOrder> buyOrder, List<SellOrder> sellOrder)
        {
            this.BuyBook = buyOrder;
            this.SellBook = sellOrder;

        }


        public TempOrderBook DeepCopy()
        {
            TempOrderBook cloneOrderBook = new TempOrderBook(OrderBook.BuyBook, OrderBook.SellBook);

            return cloneOrderBook;
        }
    }
}