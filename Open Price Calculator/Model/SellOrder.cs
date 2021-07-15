using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_Price_Calculator.Model
{
    public class SellOrder
    {

        private int _id;
        private double _price;
        private DateTime _orderTime;
        private int _volume;

        public int SellId
        {
            get { return _id; }
            set { this._id = value; }
        }
        public int SellVolume
        {
            get { return _volume; }
            set {
                if (value <= 0) { throw new Exception(" Volume must be greater than 0"); }
                else
                {
                    this._volume = value;
                }
                
            }
        }

        public double SellPrice
        {
            get { return _price; }
            set {
                if (value <=0 ) { throw new Exception(" Price must be greater than 0"); }
                else {
                    this._price = value;
                }
            }
        }

        public DateTime SellOrderTime
        {
            get { return _orderTime; }
            set { 
                if(value != null)
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