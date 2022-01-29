namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class TripTicket
    {
        public int trip_ticket_id { get; set; }
        public int ticket_id { get; set; }
        public int trip_id { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
