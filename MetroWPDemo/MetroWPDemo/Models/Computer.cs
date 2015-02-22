using System.Runtime.Serialization;
using System.Text;

namespace MetroWPDemo.Models
{
    [DataContract]
    public class Computer
    {
        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        [DataMember(Name = "price")]
        public int Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The computer brand is ");
            sb.Append(Brand);
            sb.Append(", and the price is ");
            sb.Append(Price.ToString());
            sb.Append(".");
            return sb.ToString();
        }
    }
}
