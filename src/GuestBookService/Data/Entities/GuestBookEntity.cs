﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookService.Data.Entities;
public class GuestBookEntity
{
    public int Id { get; set; }

    public string GuestName { get; set; }

    public string Comment { get; set; }

    public DateTime CommentDate { get; set; }
}
