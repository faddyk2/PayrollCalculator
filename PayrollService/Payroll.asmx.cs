using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PayrollService
{
    /// <summary>
    /// Summary description for Payroll
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Payroll : System.Web.Services.WebService
    {

        [WebMethod]
        public double CalculateFullTimeSalary(double annualSalary, int hoursPerWeek, int weeksPerYear, int loggedHours)
        {
            if (annualSalary <= 0 || hoursPerWeek <= 0 || weeksPerYear <= 0)
                throw new ArgumentException("Invalid input values.");

            double hourlyRate = annualSalary / (hoursPerWeek * weeksPerYear);
            double monthlySalary = loggedHours * hourlyRate;
            return monthlySalary;
        }

        [WebMethod]
        public string CalculatePartTimeSalary(double hourlyRate, int hoursWorked, int maxWeeklyHours)
        {
            string warning = "";
            if (hoursWorked > maxWeeklyHours)
                warning = "Warning: Overtime detected. Please consult HR.";

            double salary = hourlyRate * hoursWorked;
            return $"Salary: {salary}. {warning}";
        }

        [WebMethod]
        public double CalculateContractSalary(double milestoneFee, int milestonesCompleted, double fixedProjectFee, bool useFixed)
        {
            return useFixed ? fixedProjectFee : milestoneFee * milestonesCompleted;
        }

        [WebMethod]
        public double CalculateFreelanceSalary(List<string> taskCategories, List<int> taskCounts, List<double> taskRates)
        {
            if (taskCategories.Count != taskCounts.Count || taskCategories.Count != taskRates.Count)
                throw new ArgumentException("Mismatch in task lists.");

            double total = 0.0;
            for (int i = 0; i < taskCategories.Count; i++)
            {
                total += taskCounts[i] * taskRates[i];
            }
            return total;
        }
    }
}
