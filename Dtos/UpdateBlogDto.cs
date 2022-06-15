﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace react_api.Dtos
{
    public class UpdateBlogDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
    }
}
