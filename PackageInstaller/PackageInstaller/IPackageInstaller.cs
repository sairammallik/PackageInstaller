using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public interface IPackageInstaller
    {
        Dictionary<string, Package> ReturnStringArrayToDictionary(string[] packageArray);
        string validOuptut(Dictionary<string, Package> packageList);
    }
}
