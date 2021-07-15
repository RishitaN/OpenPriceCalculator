using Open_Price_Calculator.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Open_Price_Calculator
{
    public partial class About : Page
    {
        Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public void BuyOrder_Click(object sender, EventArgs e)
        {
            int id = rnd.Next();
            DateTime dt = System.DateTime.Now;
            float price = float.Parse( txtBuyPrice.Text);
            int vol = Convert.ToInt32(txtBuyVol.Text);          
             

            AddBuyOrder.AddBuy(id,price,vol,dt);

        }

        public void SellOrder_Click(object sender, EventArgs e)
        {
            int id = rnd.Next();
            DateTime dt = System.DateTime.Now;
            float price = float.Parse(txtBuyPrice.Text);
            int vol = Convert.ToInt32(txtBuyVol.Text);


            AddBuyOrder.AddBuy(id, price, vol, dt);

        }

        public void DisplayPrice_Click(object sender, EventArgs e)
        {
             //perform = new per
        }



    }
}