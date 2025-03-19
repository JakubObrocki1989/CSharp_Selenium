using System;

namespace SeleniumProject.src.main.app.models
{
    public class CreditCardDetails
    {
        public string cardOwner { get; set; }
        public string cardNumber { get; set; }
        public string cvcNumber { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
    }

    public class CreditCardDetailsBuilder
    {
        private CreditCardDetails _CreditCardDetails = new CreditCardDetails();

        public CreditCardDetailsBuilder SetCardOwner(string cardOwner)
        {
            _CreditCardDetails.cardOwner = cardOwner;
            return this;
        }

        public CreditCardDetailsBuilder SetCardNumber(string cardNumber)
        {
            _CreditCardDetails.cardNumber = cardNumber;
            return this;
        }

        public CreditCardDetailsBuilder SetCvcNumber(string cvcNumber)
        {
            _CreditCardDetails.cvcNumber = cvcNumber;
            return this;
        }

        public CreditCardDetailsBuilder SetExpiryMonth(string expiryMonth)
        {
            _CreditCardDetails.expiryMonth = expiryMonth;
            return this;
        }

        public CreditCardDetailsBuilder SetExpiryYear(string expiryYear)
        {
            _CreditCardDetails.expiryYear = expiryYear;
            return this;
        }

        public CreditCardDetails Build()
        {
            return _CreditCardDetails;
        }

    }
    }
