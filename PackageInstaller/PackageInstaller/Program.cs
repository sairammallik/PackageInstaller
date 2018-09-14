using PackageInstaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] packagesArray =
                { "KittenService: ",
                "LetMeme: CyberPortal",
                "CyberPortal: Ice",
                "CamelCaser: KittenService",
                "FraudStream: LetMeme",
                "Ice: " };

            IPackageInstaller packageInstaller;
            packageInstaller = new PackageInstaller();
            var packagesList = packageInstaller.ReturnStringArrayToDictionary(packagesArray);
            string output = packageInstaller.validOuptut(packagesList);
        }
    }
}