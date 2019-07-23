using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class Row : Entity
    {
        public int Number { get; set; }

        public string WorkSheetId { get; set; }
        public virtual WorkSheet WorkSheet { get; set; }

        public virtual ICollection<Col> Cols { get; set; }
    }
}
