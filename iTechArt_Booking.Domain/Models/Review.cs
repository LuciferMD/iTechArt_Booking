﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class Review
    {
        public long Id { get; set; }

         public User User { get; set; }

        public Hotel Hotel { get; set; }

        public string Text { get; set; }

    }
}
