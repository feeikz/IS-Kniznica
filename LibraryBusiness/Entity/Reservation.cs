using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Entity
{
    public class Reservation
    {
        public int ID { get; set; }
        public int ID_knihy { get; set; }
        public int ID_zakaznika { get; set; }
        public DateTime od { get; set; }
        public  DateTime dokedy{ get; set; }


        
    }
}
