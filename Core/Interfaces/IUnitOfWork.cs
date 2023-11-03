using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interface;
public interface IUnitOfWork
{
    IDriver Drivers { get; }
    ITeam Teams { get; }
    Task<int> SaveAsync();
}