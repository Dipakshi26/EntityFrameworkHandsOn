using EmployeeData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    public class CRUDManager
    {
        DemoDBContext demoDBContext = new DemoDBContext();
        public void InsertInOrgs(Employee employee, List<Organisation> OrgList)
        {

            var objEmployee = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                OrganisationList = OrgList

            };
            demoDBContext.Employees.Add(objEmployee);
            demoDBContext.SaveChanges();
        }
        public List<Employee> ReadEmployeeWithOrgs()
        {
            var listItem = demoDBContext.Employees.Include(emp => emp.OrganisationList).ToList();
            return listItem;
        }
        public void UpdateEmpOrgs(int employeeId, Employee employee, List<Organisation> UpdatedList)
        {
            var eachEmployee = demoDBContext.Employees.Where(emp => emp.ID == employeeId).Include(empProps => empProps.OrganisationList).First();
            if (eachEmployee != null)
            {
                eachEmployee.Name = employee.Name;
                eachEmployee.Address = employee.Address;
                eachEmployee.OrganisationList = UpdatedList;
            }
            else
            {
                Console.WriteLine("Cannot find employee id.");
            }
            demoDBContext.Employees.Update(eachEmployee);
            demoDBContext.SaveChanges();


        }

        public void DeleteImpOrg(int empId)
        {
            var removeEmp = demoDBContext.Employees.Where(emp => emp.ID == empId).Include(empProp => empProp.OrganisationList).First();
            if (removeEmp != null)
            {
                demoDBContext.Employees.Remove(removeEmp);
                removeEmp.OrganisationList.Clear();
                demoDBContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"No Record Found With This Id : {empId}");
            }
        }
    }
}
