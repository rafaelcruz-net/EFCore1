﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public String Text { get; set; }
        public int PostId { get; set; }

    }
}
