﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class NoteEntity
    {
        internal DateTime Modifieder;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public DateTime? Reminder { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public bool IsArchieve { get; set; }

        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("user")]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }


    }
}
