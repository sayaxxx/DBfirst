using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class TeamDto
{
    public string  Name { get; set; }
    public  ICollection<DriverDto> Drivers { get; set; }
}