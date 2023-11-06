using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class CollaboratEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int collaboratId { get; set; }

        public string collaboratEmail { get; set;}

        [ForeignKey("user")]

        public int Id { get; set; }

        public virtual UserEntity user { get; set; }

        [ForeignKey("Note")]

        public int NoteId { get; set; }

        public virtual NoteEntity Note { get; set; }
    }
}
