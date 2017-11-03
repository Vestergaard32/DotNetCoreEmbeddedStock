using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmbeddedStock.Models
{
    public class ComponentViewModel
    {
        public SelectList ComponentTypes;
        public Component Component;
    }
}
