using System;
using System.IO;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.app.factories
{
    class ContactMessageFactory
    {
        public ContactMessage getContactUsMessage()
        {
            ContactMessage contactMessage = new ContactMessageBuilder()
                    .SetName(Faker.Internet.UserName())
                    .SetEmail(Faker.Internet.Email())
                    .SetSubject(Faker.Internet.DomainWord())
                    .SetMessage(Faker.Lorem.Sentence())
                    .SetFilepath(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../src/test/resources/ContactUsAttachment.txt")))
                    .Build();
            return contactMessage;
        }
    }
}
