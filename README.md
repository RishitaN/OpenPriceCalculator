# OpenPriceCalculator
The purpose of this code is to find the Opening price for exchange traded product by determining the maximum tradable volume based on orders in an order book.

#Constraints
DB is not implemented , so the data is not persisted
For sake of simplicity features like cancellation of orders, user login etc are not taken into account

#Basic class details
All the data objects are placed under Model Folder
All the business Logics are place under Controller Folder.

SellOrder will hold details of Sell order with ID, Price, Volume, time
BuyOrder will hold details of Buy order with ID, Price, Volume, time
OrderBook will hold all the SellOrder and buyOrder. It will be a singelton class, and can be updated continuously.

To calulate the Open Price at a particular time, we create a Deep copy of Orderbook, termed as TempOrderBook.
While we operate on the TempOrderBook, the OrderBook can aceppt additional buy and sell orders.

Set the Home.aspx as the startup page to run teh application.


