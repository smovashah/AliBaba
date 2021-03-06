
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Foreign = new HashSet<Foreign>();
            this.Internal = new HashSet<Internal>();
        }

        public int flight_id { get; set; }
        public string ticket_type { get; set; }
        public string flight_class { get; set; }
        public string departure_airport { get; set; }
        public string destination_airport { get; set; }
        public int load_amount { get; set; }
        public int trip_id { get; set; }

        public virtual Trip Trip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foreign> Foreign { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internal> Internal { get; set; }
    }
}
