using NUnit.Framework;
using System;
using System.Text;


namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected ApplicationManger app;
        public static Random r = new Random();
        [SetUp]
        public void SetupApllicationManager()
        {
            app = ApplicationManger.GetInstance();
    
        }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(r.NextDouble() * max);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
               stringBuilder.Append(Convert.ToChar(32 + Convert.ToInt32(r.NextDouble() * 65)));
            }
            return stringBuilder.ToString();
        }

        public static string GenerateName(int len)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int posThirdLetter = 2;
            while (posThirdLetter < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                posThirdLetter++;
                Name += vowels[r.Next(vowels.Length)];
                posThirdLetter++;
            }

            return Name;

        }

        public static ContactData.DateInfo GenerateDate()
        {
            string[] months = { "January", "February" };

            int year = r.Next(1960, DateTime.Now.Year + 1);
            string month = months[r.Next(months.Length)];
            int day = r.Next(1, 29);

            return new ContactData.DateInfo(
               day.ToString(),
               month,
               year.ToString()
            );
        }

    }
}
