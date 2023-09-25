﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjPizzaRestaurAndDrink20230925.Models
{
    public class UserStatusMV
    {
        [Display(Name = "#Unique No")]
        public int UserStatusID { get; set; }

        [Display(Name = "Account Status")]
        public string UserStatus { get; set; }
    }
}