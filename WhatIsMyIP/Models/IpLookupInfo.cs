namespace WhatIsMyIP.Models
{
    public class IpLookupInfo
    {
        public IpLookupInfo(string ipAddress, bool isIpForwarded)
        {
            Ip = ipAddress;
            IsIpForwarded = isIpForwarded;
        }
        public string Ip { get; set; }
        public bool IsIpForwarded { get; set; } = false;
        public string Hostname { get; set; }
        public string Loc { get; set; }
        public string Org { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
