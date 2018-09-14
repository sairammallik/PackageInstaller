using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public class PackageInstaller : IPackageInstaller
    {
        public Dictionary<string, Package> ReturnStringArrayToDictionary(string[] packageArray)
        {
            var packageList = new Dictionary<string, Package>();
            foreach (var packageString in packageArray)
            {
                Package package = new Package();
                string[] s = packageString.Split(':');
                package.PackageName = s[0];
                package.DependencyPackageName = s[1].Trim();
                if (package.DependencyPackageName == "")
                    package.IsInstalled = true;
                packageList.Add(package.PackageName, package);
            }
            return packageList;
        }


        public string validOuptut(Dictionary<string, Package> packageList)
        {
            StringBuilder packageOrder = new StringBuilder();

            Queue<string> packageQ = new Queue<string>();
            var packages = packageList.ToDictionary(x => x.Key, x => x.Value).Where(x => x.Value.DependencyPackageName == "");

            //Base Case
            if (packageList.Count < 1 || packages.Count() < 1)
                return "INVALID INPUT";

            foreach (var package in packages)
            {
                packageList[package.Key].IsInstalled = true;
                packageOrder.Append(packageList[package.Key].PackageName + ", ");
                packageQ.Enqueue(package.Key);
            }

            while (packageQ.Count > 0)
            {
                var ele = packageQ.Dequeue();
                var packagev2 = packageList.ToDictionary(x => x.Key, x => x.Value).Where(x => x.Value.DependencyPackageName.Contains(ele));
                foreach (var v2 in packagev2)
                {
                    packageList[v2.Key].IsInstalled = true;
                    packageOrder.Append(packageList[v2.Key].PackageName + ", ");
                    packageQ.Enqueue(v2.Key);
                }
            }

            if (packageList.Where(x => x.Value.IsInstalled == false).Count() > 0)
                return "INVALID INPUT";
            else
                return packageOrder.ToString(); ;
        }
    }
}
