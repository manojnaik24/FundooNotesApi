﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class NoteModel
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public bool IsArchieve { get; set; }
        public bool IsTrash { get; set; }
        public bool IsPin { get; set; }
        public DateTime? Reminder { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
