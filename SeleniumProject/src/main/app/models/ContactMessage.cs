using System;

namespace SeleniumProject.src.main.app.models
{
    public class ContactMessage
    {
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string filePath { get; set; }

    }
        public class ContactMessageBuilder
        {
        private ContactMessage _contactMessage = new ContactMessage();

        public ContactMessageBuilder SetName(string name)
        {
            _contactMessage.name = name;
            return this;
        }

        public ContactMessageBuilder SetEmail(string email)
        {
            _contactMessage.email = email;
            return this;
        }

        public ContactMessageBuilder SetSubject(string subject)
        {
            _contactMessage.subject = subject;
            return this;
        }

        public ContactMessageBuilder SetMessage(string message)
        {
            _contactMessage.message = message;
            return this;
        }

        public ContactMessageBuilder SetFilepath(string filepath)
        {
            _contactMessage.filePath = filepath;
            return this;
        }

        public ContactMessage Build()
        {
            return _contactMessage;
        }

    }
    }
