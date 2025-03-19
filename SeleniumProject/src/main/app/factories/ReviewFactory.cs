using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.app.factories
{
    class ReviewFactory
    {
        public Review getRandomReview()
        {
            Review review = new ReviewBuilder()
            .SetName(Faker.Internet.UserName())
            .SetEmail(Faker.Internet.Email())
            .SetReview(Faker.Lorem.Sentence())
            .Build();
            return review;
        }
    }
}
