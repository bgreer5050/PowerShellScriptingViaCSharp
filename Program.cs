using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace IoT_Scripts
{
    class Program
    {
        static void Main(string[] args)
        {
            using(PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " + "$d; $s; $param1; get-service");
                PowerShellInstance.AddParameter("param1", "parameter 1 value!");
                
                Collection<PSObject> PSOutput =  PowerShellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {
                    if(outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    }
                }

                Console.ReadLine();
            }


        }
    }
}
