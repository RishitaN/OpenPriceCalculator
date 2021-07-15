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
        public float openPrice;
        public int openVol;


        public bool PerformMatching()
        {
            bool res;
            try
            {
                TempOrderBook temp = GenerateOrderBook.GetTempOrderBook();
                if (temp.BuyBook.Count() > 0)
                {

                    throw new Exception("No Buy Order found");
    
                }

                if (temp.SellBook.Count() > 0)
                {
                    throw new Exception("No sell Order found");
                }

                res = OrderMatch(temp);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return res;
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

                for (int i = 0; i< length; i++)
                {
                    
                    float buyPrice = tempBook.BuyBook[i].BuyPrice;

                    float sellPrice = tempBook.SellBook[i].SellPrice;

                    message.Append($"buyPrice - {buyPrice} / sell price - {sellPrice};");

                    if (buyPrice > sellPrice)
                    {

                        continue;
                    }
                    else if (buyPrice <= sellPrice)
                    {
                        message.Append("match found");



                        tempBook = OnMatchPriceFound(tempBook, i);
                        continue;
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
            try
            {
                int buyVol = tempBook.BuyBook[index].BuyVolume;
                int sellVol = tempBook.SellBook[index].SellVolume;

                if (buyVol < sellVol)
                {
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        buyVol += tempBook.BuyBook[i].BuyVolume;
                        sellVol += tempBook.SellBook[i].SellVolume;

                        int vol = buyVol - sellVol;
                        if ( vol >= 0)
                        {
                            openPrice = tempBook.BuyBook[index].BuyPrice;
                            openVol = tempBook.SellBook[index].SellVolume;

                            RemoveOrderfromBook(tempBook, index);
                        }
                        else
                        {
                            openPrice = tempBook.BuyBook[index].BuyPrice;
                            openVol = tempBook.BuyBook[index].BuyVolume;

                            RemoveOrderfromBook(tempBook, index);
                        }
                    }
                }

            }
            catch
            {

            }
            
            return tempBook;
        }

        public void RemoveOrderfromBook(TempOrderBook tempBook, int index)
        {
            tempBook.BuyBook.RemoveAt(index);
            tempBook.SellBook.RemoveAt(index);
        }

    }
}