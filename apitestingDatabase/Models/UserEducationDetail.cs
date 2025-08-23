using System;
using System.Collections.Generic;

namespace apitestingDatabase.Models;

public partial class UserEducationDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Degree { get; set; }

    public string? PassOut { get; set; }
}
