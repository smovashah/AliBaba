
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Internal
    {
        public int internal_id { get; set; }
        public int terminal { get; set; }
        public bool is_available { get; set; }
        public string special_offer { get; set; }
        public int flight_id { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
