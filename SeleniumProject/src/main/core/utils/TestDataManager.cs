using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace SeleniumFramework.util
{
    public class TestDataManager
    {
        public string Region { get; set; }
        public BrowserConfig browserConfig { get; set; }
        public Environments environments { get; set; }
        public IList<User> user { get; set; }

        private static TestDataManager instance = null;

        public static TestDataManager GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new TestDataManager();
                return instance;
            }
        }
        private TestDataManager()
        {
            IConfiguration config = getTestData();
            Region = config.GetValue<string>("Region");
            browserConfig = config.GetSection("Browser").Get<BrowserConfig>();
            environments = config.GetSection("Environments").GetSection(Region).Get<Environments>();
            user = config.GetSection("Users").Get<List<User>>();
            Console.WriteLine($"Region = {Region}");
        }

        public IConfiguration getTestData()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory).Parent;

            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(parentDirectory.FullName)
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();

        }

        public string GetRootFolderPath()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory).Parent;
            return parentDirectory.FullName;
        }

        public User GetUserById(string id)
        {
            return user.FirstOrDefault(u => u.UserId == id);
        }

        public string GetDownloadPath()
        {
            var userDir = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(userDir).Parent.Parent.FullName;
            var downloadsDir = browserConfig.Downloads;
            string tmp = projectDirectory + downloadsDir;
            return tmp;
        }


    }
    public class BrowserConfig
    {
        public string Name { get; set; }
        public bool Headless { get; set; }
        public bool IgnoreSSL { get; set; }
        public string Size { get; set; }
        public string Downloads { get; set; }
        public WebElement webElement { get; set; }

        public class WebElement
        {
            public int Timeout { get; set; }
            public int Polling { get; set; }

            public WebElement() { }
        }

        public BrowserConfig()
        {

        }

    }

    public class Environments
    {
        public string AppUrl { get; set; }
        public string ApiUrl { get; set; }

        public Environments() { }
    }

    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }
    }
}
