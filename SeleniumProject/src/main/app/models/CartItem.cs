using System;

namespace SeleniumProject.src.main.app.models
{
    public class CartItem
    {
        public string name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string totalPrice { get; set; }
    }

    public class CartItemBuilder
    {
        private CartItem _CartItem = new CartItem();

        public CartItemBuilder SetName(string name)
        {
            _CartItem.name = name;
            return this;
        }

        public CartItemBuilder SetPrice(string price)
        {
            _CartItem.price = price;
            return this;
        }

        public CartItemBuilder SetQuantity(string quantity)
        {
            _CartItem.quantity = quantity;
            return this;
        }

        public CartItemBuilder SetTotalPrice(string totalPrice)
        {
            _CartItem.totalPrice = totalPrice;
            return this;
        }

        public CartItem Build()
        {
            return _CartItem;
        }

    }
}
