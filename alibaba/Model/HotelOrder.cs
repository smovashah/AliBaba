
namespace Model
{
    using System;
    using System.Collections.Generic;

    public partial class HotelOrder
    {
        public int hotel_order_id { get; set; }
        public bool status { get; set; }
        public int price { get; set; }
        public System.DateTime time { get; set; }
        public int user_id { get; set; }
        public int hotel_id { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual User User { get; set; }
    }
}
