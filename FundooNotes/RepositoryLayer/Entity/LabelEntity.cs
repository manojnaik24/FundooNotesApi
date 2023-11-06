using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public  class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int columnsid {  get; set; }
        public string labelName {  get; set; }

        [ForeignKey("user")]

        public int Id { get; set; }

        public virtual UserEntity user { get; set; }

        [ForeignKey("NoteId")]

        public int NoteId { get; set; }

        public virtual NoteEntity Note { get; set; }

    }
}
