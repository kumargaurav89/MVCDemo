using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Enum
{
    public enum PersonType
    {
        [Display(Name ="Individual(retail) customer")]
        IN = 1,
        [Display(Name = "Employee(non - sales)")]
        EM ,
        [Display(Name = "Sales person")]
        SP,
        [Display(Name = "Store Contact")]
        SC,
        [Display(Name = "Vendor contact")]
        VC,
        [Display(Name = "General contact")]
        GC
    }
}

//SC = Store Contact, IN = Individual(retail) customer, SP = Sales person, 
//    EM = Employee(non - sales), VC = Vendor contact, GC = General contact