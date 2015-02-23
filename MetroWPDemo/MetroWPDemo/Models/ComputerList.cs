using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MetroWPDemo.Models
{
    [DataContract]
    public class ComputerList
    {
        [DataMember(Name = "result")]
        public string result { get; set; }

        [DataMember(Name = "header")]
        public string header { get; set; }

        [DataMember(Name = "computers")]
        public List<Computer> computerList { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Result: ");
            sb.Append(result);
            sb.Append("\n");
            foreach(Computer c in computerList)
            {
                sb.Append(c.ToString());
                sb.Append("\n");
            }
            sb.Append(header);
            return sb.ToString();
        }
    }
}