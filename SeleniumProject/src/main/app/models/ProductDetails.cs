using System;

namespace SeleniumProject.src.main.app.models
{
    public class ProductDetails
    {
        public string name { get; set; }
        public string price { get; set; }
    }

    public class ProductDetailsBuilder
    {
        private ProductDetails _ProductDetails = new ProductDetails();

        public ProductDetailsBuilder SetName(string name)
        {
            _ProductDetails.name = name;
            return this;
        }

        public ProductDetailsBuilder SetPrice(string price)
        {
            _ProductDetails.price= price;
            return this;
        }

        public ProductDetails Build()
        {
            return _ProductDetails;
        }

    }
}
