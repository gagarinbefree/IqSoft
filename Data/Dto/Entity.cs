using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Dto
{
    public class Entity
    {
        [Key]
        [Column("Id", TypeName = "varchar(36)")]
        public string Id { get; set; }
    }
}
