

namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class UsersWithNonZeroBalance
    {
        public int user_id { get; set; }
        public bool gender { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telephone { get; set; }
        public string national_id { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public string email { get; set; }
        public string mobile_phone { get; set; }
        public string account_number { get; set; }
        public string card_number { get; set; }
        public string shaba_number { get; set; }
        public double balance { get; set; }
    }
}
