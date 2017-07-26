using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public class CreateEmployeeViewModel
    {
        [HiddenInput(DisplayValue =false)] //sets value to hidden and not displayed at all
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)] //treat the datetime as just a date since we don't need to know anything but the date
        //for a hire date. 
        public DateTime HireDate { get; set; }

    }
}