
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Bus
    {
        public int bus_id { get; set; }
        public string bus_type { get; set; }
        public string departure_terminal { get; set; }
        public string destination_terminal { get; set; }
        public int trip_id { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
