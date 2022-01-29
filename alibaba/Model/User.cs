

namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.HotelOrder = new HashSet<HotelOrder>();
            this.Ticket = new HashSet<Ticket>();
            this.Transaction = new HashSet<Transaction>();
        }

        public int user_id { get; set; }
        public bool gender { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telephone { get; set; }
        public string national_id { get; set; }
        public Nullable<System.DateTime> birth_data { get; set; }
        public string email { get; set; }
        public string mobile_phone { get; set; }
        public string account_number { get; set; }
        public string card_number { get; set; }
        public string shaba_number { get; set; }
        public double balance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrder> HotelOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
