using System;
using System.Collections.Generic;

namespace apitestingDatabase.Models;

public partial class UserDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
}
