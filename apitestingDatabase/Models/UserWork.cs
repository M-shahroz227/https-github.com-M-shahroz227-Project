using System;
using System.Collections.Generic;

namespace apitestingDatabase.Models;

public partial class UserWork
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Job { get; set; }

    public string? Company { get; set; }
}
