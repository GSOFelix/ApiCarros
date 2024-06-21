﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Requests
{
    public abstract class PagedRequest : Request
    {
        public int PageSize { get; set; }   
        public int PageNumber { get; set; }
    }
}