using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public class Package
    {
        public string PackageName { get; set; }
        public string DependencyPackageName { get; set; }
        public bool IsInstalled { get; set; }
        public int OrderOfInstallation { get; set; }

        public Package()
        {
            IsInstalled = false;
            OrderOfInstallation = 0;
        }
    }
}
