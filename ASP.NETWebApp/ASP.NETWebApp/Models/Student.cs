using System;
using System.Collections.Generic;

namespace ASP.NETWebApp.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;
}
