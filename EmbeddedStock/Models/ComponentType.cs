﻿using System.Collections.Generic;

namespace EmbeddedStock.Models
{
    public class ComponentType
    {
        public long ComponentTypeId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string Datasheet { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        public string AdminComment { get; set; }
        public virtual ESImage Image { get; set; }
        public ICollection<Component> Components { get; protected set; }
        public ICollection<ComponentTypeCategory> ComponentTypeCategories { get; protected set; }

        public ComponentType()
        {
            Components = new List<Component>();
            ComponentTypeCategories = new List<ComponentTypeCategory>();
        }
    }
}