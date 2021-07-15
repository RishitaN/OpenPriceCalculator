using Open_Price_Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Open_Price_Calculator.Controller
{
    public class MatchOrder
    {
        public double openPrice;
        public int openVol;
        Random rnd = new Random();
        


        public TempOrderBook PerformMatching(out int vol, out double price)
        {
            bool res;
            try
            {
                TempOrderBook temp = GenerateOrderBook.GetTempOrderBook();
                if (temp.BuyBook.Count() <= 0)
                {

                    throw new Exception("No Buy Order found");

                }

                if (temp.SellBook.Count() <= 0)
                {
                    throw new Exception("No sell Order found");
                }

                res = OrderMatch(temp);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            vol = openVol;
            price = openPrice;
            return GenerateOrderBook.GetTempOrderBook(); ;
        }

        public bool OrderMatch(TempOrderBook tempBook)
        {
            bool res = false;
            StringBuilder message = new StringBuilder();
            try
            {
                int BuyOrderCount = tempBook.BuyBook.Count();
                int SellOrderCount = tempBook.SellBook.Count();

                int length = Math.Min(BuyOrderCount, SellOrderCount);

                for (int i = 0; i < length; i++)
                {

                    double buyPrice = tempBook.BuyBook[i].BuyPrice;

                    double sellPrice = tempBook.SellBook[i].SellPrice;

                    message.Append($"buyPrice - {buyPrice} / sell price - {sellPrice};");

                    if (buyPrice > sellPrice)
                    {

                        continue;
                    }
                    else if (buyPrice <= sellPrice)
                    {
                        message.Append("match found");



                        tempBook = OnMatchPriceFound(tempBook, i);
                        break;
                    }

                    //else if (buyPrice < sellPrice)
                    //{

                    //    continue;
                    //}
                    else { }

                    res = true;
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return res;

        }

        public TempOrderBook OnMatchPriceFound(TempOrderBook tempBook, int index)
        {
            BuyOrder buyOrder;
            SellOrder sellOrder;
            try
            {
                int buyVol = tempBook.BuyBook[index].BuyVolume;
                int sellVol = tempBook.SellBook[index - 1].SellVolume;
               

                for (int i = index - 1; i >= 0; i--)
                {
                    buyVol += tempBook.BuyBook[i].BuyVolume;

                    if (i - 1 < 0) { }
                    else
                    {
                        sellVol += tempBook.SellBook[i - 1].SellVolume;
                    }

                }

                int vol = buyVol - sellVol;
                if (vol < 0)
                {
                    openPrice = tempBook.BuyBook[index].BuyPrice;
                    openVol = buyVol;

                    //UpdateOrderBook;

                    for (int i = index; i > 0; i--)
                    {
                        buyOrder = tempBook.BuyBook[i];
                        OrderBook.BuyBook.Remove(buyOrder);

                        if (i - 1 <= 0) {
                            sellOrder = tempBook.SellBook[i-1];
                            OrderBook.SellBook.Remove(sellOrder); 
                        }
                        

                    }

                    SellOrder so = new SellOrder()
                    {
                        SellId = rnd.Next(),
                        SellPrice = tempBook.SellBook[index].SellPrice,
                        SellVolume = sellVol - buyVol

                    };

                    OrderBook.SellBook.Add(so);

                    
                }
                else if (vol == 0)
                {
                    openPrice = tempBook.BuyBook[index].BuyPrice;
                    openVol = buyVol;

                    UpdateOrderBook(tempBook, index);
                }
                else
                {
                    openPrice = tempBook.BuyBook[index].BuyPrice;
                    openVol = sellVol;

                    //UpdateOrderBook(index);

                    for (int i = index; i > 0; i--)
                    {
                        buyOrder = tempBook.BuyBook[i];
                        OrderBook.BuyBook.Remove(buyOrder);
                        if (i - 1 <= 0) {
                            sellOrder = tempBook.SellBook[i - 1];
                            OrderBook.SellBook.Remove(sellOrder); }


                    }

                    BuyOrder bo = new BuyOrder()
                    {
                        BuyId = rnd.Next(),
                        BuyPrice = tempBook.BuyBook[index].BuyPrice,
                        BuyVolume = buyVol - sellVol

                    };

                    OrderBook.BuyBook.Add(bo);
                }

                //}

            }
            catch
            {

            }

            return tempBook;
        }

        public void UpdateOrderBook( TempOrderBook temp, int index)
        {
            BuyOrder bo;
            SellOrder so;
            for (int i = index; i > 0; i--)
            {
                bo = temp.BuyBook[i];
                so = temp.SellBook[i];
                OrderBook.BuyBook.Remove(bo);
                OrderBook.SellBook.Remove(so);

            }
        }

    }
}