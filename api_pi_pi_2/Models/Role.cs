﻿using System;
using System.Collections.Generic;

namespace api_pi_pi_2.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
