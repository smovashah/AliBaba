
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Transaction
    {
        public int transaction_id { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public System.DateTime time { get; set; }
        public int user_id { get; set; }

        public virtual User User { get; set; }
    }
}
