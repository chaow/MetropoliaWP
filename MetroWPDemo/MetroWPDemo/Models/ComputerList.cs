using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MetroWPDemo.Models
{
    [DataContract]
    public class ComputerList
    {
        [DataMember(Name = "result")]
        public string result { get; set; }

        [DataMember(Name = "computers")]
        public List<Computer> computerList { get; set; }
    }
}