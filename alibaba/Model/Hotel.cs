
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.Facility = new HashSet<Facility>();
            this.Room = new HashSet<Room>();
            this.HotelOrder = new HashSet<HotelOrder>();
        }

        public int hotel_id { get; set; }
        public Nullable<int> ratiing { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public int room_capacity { get; set; }
        public int empty_room { get; set; }
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facility> Facility { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrder> HotelOrder { get; set; }
    }
}
