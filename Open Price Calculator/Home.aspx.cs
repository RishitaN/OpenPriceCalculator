using Open_Price_Calculator.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Open_Price_Calculator.Model;

namespace Open_Price_Calculator
{
    public partial class About : Page
    {
        Random rnd = new Random();
        OrderBook OB;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                OB = OrderBook.Instance();

                //Below implementatio is just to use session since ths code doesnt implement DB yet
                //if(OrderBook.BuyBook.Count() == 0)
                //{
                //    if (Session["BuyBook"] != null)
                //    {
                //        OrderBook.BuyBook = (List<BuyOrder>)Session["BuyBook"];
                //    }

                //    if (Session["SellBook"] != null)
                //    {
                //        OrderBook.BuyBook = (List<BuyOrder>)Session["SellBook"];
                //    }

                //}
                


            }
            catch (Exception ex)
            {
                throw ex;
            }          
            

        }

        

        public void BuyOrder_Click(object sender, EventArgs e)
        {
            int id = rnd.Next();
            DateTime dt = System.DateTime.Now;
            double price = double.Parse( txtBuyPrice.Text);
            int vol = Convert.ToInt32(txtBuyVol.Text);

            
            AddBuyOrder.AddBuy(id,price,vol,dt);
            Reset();
        }

        public void SellOrder_Click(object sender, EventArgs e)
        {
            int id = rnd.Next();
            DateTime dt = System.DateTime.Now;
            float price = float.Parse(txtBuyPrice.Text);
            int vol = Convert.ToInt32(txtBuyVol.Text);

            
            AddBuyOrder.AddBuy(id, price, vol, dt);
            Reset();

        }

        public void DisplayPrice_Click(object sender, EventArgs e)
        {
            MatchOrder matchorder = new MatchOrder();
            int vol;
            double price;
            TempOrderBook res = matchorder.PerformMatching(out vol, out price);
            lblOpenPrice.Text = $"Opening Price -{price.ToString()} with Vol -{vol.ToString()}"  ;
            Reset();

        }

        public void DisplayOrderBook_Click(object sender, EventArgs e)
        {
            try
            {
                //if(Session["BuyOrder"] == null)
                if(OrderBook.BuyBook.Count() == 0)
                {
                    AddOrdersForDemo();
                }
                BindOrderBookData();

            }
            catch(Exception ex)
            {
                throw ex;
            }

            
        }

        public void BindOrderBookData()
        {
            tblBook.Visible = true;
            this.rptBuy.DataSource = OrderBook.BuyBook;
            this.rptBuy.DataBind();

            this.rptSell.DataSource = OrderBook.SellBook;
            this.rptSell.DataBind();
        }
        public void Reset()
        {
            txtBuyPrice.Text = "";
            txtBuyVol.Text = "";
            txtSellPrice.Text = "";
            txtSellVolume.Text = "";

            tblBook.Visible = false;
            OrderBook.BuyBook.Clear();
            OrderBook.SellBook.Clear();

        }

        public void checkIfOrderAdded(bool res)
        {
            if (!res)
            {
                throw new Exception("Some error while adding the order");
            }
        }

        public void AddOrdersForDemo()
        {
            bool res;
            //for Demo purpose adding few Buy and sell order
            //Add buy Order

            res = AddBuyOrder.AddBuy(rnd.Next(), 100, 10, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddBuyOrder.AddBuy(rnd.Next(), 99, 50, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddBuyOrder.AddBuy(rnd.Next(), 98, 100, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddBuyOrder.AddBuy(rnd.Next(), 97, 30, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddBuyOrder.AddBuy(rnd.Next(), 96, 55, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddBuyOrder.AddBuy(rnd.Next(), 95, 40, System.DateTime.Now);
            checkIfOrderAdded(res);


            //Add Sell Order
            res = AddSellOrder.AddSell(rnd.Next(), 97, 80, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddSellOrder.AddSell(rnd.Next(), 98, 60, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddSellOrder.AddSell(rnd.Next(), 99.5, 75, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddSellOrder.AddSell(rnd.Next(), 100, 90, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddSellOrder.AddSell(rnd.Next(), 101, 100, System.DateTime.Now);
            checkIfOrderAdded(res);
            res = AddSellOrder.AddSell(rnd.Next(), 102, 20, System.DateTime.Now);
            checkIfOrderAdded(res);

            Session["BuyOrder"] = OrderBook.BuyBook;

            Session["SellOrder"] = OrderBook.SellBook;
        }

    }
}