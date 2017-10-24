﻿using System.Collections;
using System.Collections.Generic;

namespace EmbeddedStock.Models
{
    public class Category
    {
        public Category()
        {
            ComponentTypes =  new List<ComponentType>();    
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; set; }
    }
}