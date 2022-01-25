using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
      
        public class Card
      {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Person { get; set; }
            public size Sizes { get; set; }

            public Card(string title, string content, string person, size sizes)
            {
                Title = title;
                Content = content;
                Person = person;
                Sizes = sizes;
            }
        public enum size
        {
            xs = 1,
            s =2,
            m = 3,
            l = 4,
            xl = 5,
            xxl = 6
        }
    }
}


