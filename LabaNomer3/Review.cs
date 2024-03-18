using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer3
{
    public class Review
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string ContactNumber { get; set; }

        public Review(string userName, string text, int rating, string conatactnumber)
        {
            UserName = userName;
            Text = text;
            Rating = rating;
            ContactNumber = conatactnumber;
        }

        public void SaveReview()
        {
            string path = "reviews.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"Ім'я: {UserName}");
                sw.WriteLine($"Відгук: {Text}");
                sw.WriteLine($"Рейтинг: {Rating}");
                sw.WriteLine($"Контактний номер: {ContactNumber}");
                sw.WriteLine("-----------------------------");
            }
        }
    }
}
