using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Model
{
    public class BuyOrder
    {
        private int _id;
        private int _volume;
        private double _price;
        private DateTime _orderTime;

        public int BuyId
        {
            get { return _id; }
            set { this._id = value; }
        }
        public int BuyVolume {
            get { return _volume;   }
            set {
                if (value <= 0) { throw new Exception(" Volume must be greater than 0"); }
                else
                {
                    this._volume = value;
                }
            }
        }

        public double BuyPrice
        {
            get { return _price; }
            set {
                if (value <= 0) { throw new Exception(" Price must be greater than 0"); }
                else
                {
                    this._price = value;
                }
            }
        }

        public DateTime BuyOrderTime
        {
            get { return _orderTime; }
            set
            {
                if (value != null)
                {
                    this._orderTime = value;
                }
                else
                {
                    _orderTime = System.DateTime.Now;
                }
            }
        }
    }
}