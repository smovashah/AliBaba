
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Foreign
    {
        public int foreign_id { get; set; }
        public System.TimeSpan travel_time { get; set; }
        public int stop_number { get; set; }
        public string stop_path { get; set; }
        public int flight_id { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
