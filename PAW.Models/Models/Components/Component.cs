﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Models.Components;

public class Component : ComponentBase
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

