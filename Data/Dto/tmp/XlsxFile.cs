using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Dto.tmp
{
    public class XlsxFile : Entity
    {
        public string Name { get; set; }
        public DateTime UploadDateTime { get; set; }

        public virtual ICollection<XlsxList1> Xlsx1 { get; set; }
        public virtual ICollection<XlsxList2> Xlsx2 { get; set; }
    }
}
