using System;
using System.Collections.Generic;
using System.Text;

namespace Sonic.DTO.Extended.Store
{
    [Serializable]
    public class Location
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
