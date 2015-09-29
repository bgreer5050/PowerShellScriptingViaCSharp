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
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.


                PowerShellInstance.AddScript("$dateTime = Get-Date;");
                PowerShellInstance.AddScript("$password = ConvertTo-SecureString \"p@ssw0rd\" -AsPlainText -Force;");
                PowerShellInstance.AddScript("$cred = New-Object System.Management.Automation.PSCredential (\"minwinpc\\Administrator\",$password);");
                PowerShellInstance.AddScript("Invoke-Command -ComputerName minwinpc -Credential $cred -ScriptBlock {Set-Date -Date $using:datetime;}");
                //PowerShellInstance.AddScript("Invoke-Command -ComputerName minwinpc -Credential $cred -ScriptBlock {Set-Date 'Monday, September 28, 2015 4:09:00 PM';}");


                PowerShellInstance.AddScript("get-date");
                //PowerShellInstance.AddScript("$dateTime = \"Sunday, September 27, 2015 7:20:00 AM\"; $password = ConvertTo-SecureString \"Bears,123\" -AsPlainText -Force; $cred = New-Object System.Management.Automation.PSCredential (\"BenlaptopPC\\Admin\",$password); Invoke-Command -ComputerName BenlaptopPC -Credential $cred -ScriptBlock {Set-Date -Date $using:datetime;}");

                //PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                //        "$d; $s; $param1; get-service");

                // use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                //PowerShellInstance.AddParameter("param1", "parameter 1 value!");
                Collection<PSObject> PSOutput =  PowerShellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {
                    if(outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    }
                }
                Console.WriteLine("DONE");
                Console.ReadLine();
            }


        }
    }
}
