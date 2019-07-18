using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Dto
{
    public class XlsxFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Name { set; get; }

        public virtual ICollection<Xlsx1> Xlsx1 { get; set; }
        public virtual ICollection<Xlsx2> Xlsx2 { get; set; }
    }
}
