using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Entities
{
    public class Organisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string? OrgName { get; set; }

        //cross reference : every organization must have a employeeid/emp
        public Employee? Employee { get; set; }
    }
}
