using System.Collections.Generic;

namespace SeleniumProject.src.main.app.models
{
    public class CheckoutCustomerAddress
    {
        public string genderFirstLastName { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string cityStatePostalCode { get; set; }
        public string country { get; set; }
        public string mobile { get; set; }

        public CheckoutCustomerAddress(List<string> data)
        {
            this.genderFirstLastName = data[1];
            this.company = data[2];
            this.address = data[3];
            this.address2 = data[4];
            this.cityStatePostalCode = data[5];
            this.country = data[6];
            this.mobile = data[7];
        }
    }
}
