using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IAccessBuilder
    {
        IServiceCollection Services { get; }
    }
}
