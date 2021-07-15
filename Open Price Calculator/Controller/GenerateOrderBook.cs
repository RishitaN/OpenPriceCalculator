using Open_Price_Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator
{
    public class GenerateOrderBook
    {
        public static TempOrderBook GetTempOrderBook()
        {
            //TempOrderBook defaultTempOrderBook = new TempOrderBook();
            try
            {
                if (!(OrderBook.SellBook.Count() > 0))
                {
                    throw new Exception(" NO sell Order found");


                }
                else if (!(OrderBook.BuyBook.Count() > 0))
                {
                    throw new Exception(" NO Buy Order found");
                }
                else
                {
                    //we take a DeepCopy of our Singleton OrderBook
                    //user can still keep placing buy and sell order - those will get added t OrderBook
                    //Meanwhile we can work on TempOrderBook to calculate Opening Price
                    TempOrderBook tempOrderBook = new TempOrderBook(OrderBook.BuyBook, OrderBook.SellBook);

                   
                    //sort the Buy order in Desc price and Ascending orderDate
                    tempOrderBook.BuyBook.OrderByDescending(x => x.BuyPrice).ThenBy(y => y.BuyOrderTime);

                    //sort the sell order in Asc price and Ascending orderDate
                    tempOrderBook.SellBook.OrderBy(x => x.SellPrice).ThenBy(y => y.SellOrderTime);

                    return tempOrderBook;

                }
               

            }
           
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}