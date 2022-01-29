
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class Room
    {
        public int room_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int hotel_id { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
