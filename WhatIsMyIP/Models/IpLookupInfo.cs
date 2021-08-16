namespace WhatIsMyIP.Models
{
    public class IpLookupInfo
    {
        public IpLookupInfo(string ipAddress)
        {
            Ip = ipAddress;
        }
        public string Ip { get; set; }
        public string Hostname { get; set; }
        public string Loc { get; set; }
        public string Org { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
