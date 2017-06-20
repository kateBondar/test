using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Meeting
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //Todo: declare partisipant object
        public IList<string> Participants { get; set; }

        public DateTime Date { get; set; }

        public string Adress  { get; set; }
    }
}
