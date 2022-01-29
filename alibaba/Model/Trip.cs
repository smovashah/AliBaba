
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            this.Bus = new HashSet<Bus>();
            this.Flight = new HashSet<Flight>();
            this.TripTicket = new HashSet<TripTicket>();
        }

        public int trip_id { get; set; }
        public System.DateTime destination_time { get; set; }
        public int capacity { get; set; }
        public int cost { get; set; }
        public int company_id { get; set; }
        public Nullable<System.DateTime> departure_time { get; set; }
        public Nullable<int> destination_id { get; set; }
        public Nullable<int> departure_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bus> Bus { get; set; }
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripTicket> TripTicket { get; set; }
    }
}
