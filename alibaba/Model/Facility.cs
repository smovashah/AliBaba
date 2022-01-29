
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Facility
    {
        public int facility_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int hotel_id { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
