
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.TripTicket = new HashSet<TripTicket>();
        }

        public int ticket_id { get; set; }
        public int user_id { get; set; }
        public System.DateTime buy_time { get; set; }
        public decimal price { get; set; }
        public int seat_number { get; set; }

        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripTicket> TripTicket { get; set; }
    }
}
