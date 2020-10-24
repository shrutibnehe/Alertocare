using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Utility
{
    public class Validations_Icu
    {
        public bool ValidateIcu(Icu icu)
        {
            
            if (String.IsNullOrEmpty(icu.Id) ||String.IsNullOrEmpty(icu.LayoutId))
            {
                return false;
            }
            return true;
           
        }
       
    }
}
