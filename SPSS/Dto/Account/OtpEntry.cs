﻿namespace SPSS.Dto.Account
{
    public class OtpEntry
    {
        public string Base32Secret { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
