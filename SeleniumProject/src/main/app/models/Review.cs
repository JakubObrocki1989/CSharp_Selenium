using System;

namespace SeleniumProject.src.main.app.models
{
    public class Review
    {
        public string name { get; set; }
        public string email { get; set; }
        public string review { get; set; }
    }

    public class ReviewBuilder
    {
        private Review _Review = new Review();

        public ReviewBuilder SetName(string name)
        {
            _Review.name = name;
            return this;
        }

        public ReviewBuilder SetEmail(string email)
        {
            _Review.email = email;
            return this;
        }

        public ReviewBuilder SetReview(string review)
        {
            _Review.review = review;
            return this;
        }

        public Review Build()
        {
            return _Review;
        }

    }
}
