using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL
    {
        private static EmployeeBLL instance;
        public static EmployeeBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeBLL();
                }
                return instance;
            }
            private set { }
        }
        private EmployeeBLL() { }
        public string GetEmployeeNameByEmployeeId(string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
                if (employee == null) return null;
                return employee.EmployeeName;
            }
        }
        public string GetEmployeeIdByAccountId(string accountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var employee = context.Employees.FirstOrDefault(p => p.AccountId == accountId);
                if (employee == null) return null;
                return employee.EmployeeId;
            }
        }
        public List<Employee> GetListEmployee()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var employees = context.Employees.ToList();
                return employees;
            }
        }
        public Employee GetEmployeeByEmployeeId(string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
                return employee;
            }
        }
        public string GetRandomEmployeeId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string employeeId = "nv" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Employees.Any(p => p.EmployeeId == employeeId))
                {
                    employeeId = "nv" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return employeeId;
            }
        }
        public string GetRandomUserNameAccount()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string userName = "nhanvien" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Employees.Any(p => p.EmployeeName == userName))
                {
                    userName = "nhanvien" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return userName;
            }
        }
        public string GetAccountIdByEmployeeId(string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
                if (employee == null) return null;
                return employee.AccountId;
            }
        }
        public void AddNewEmployee(Employee employee)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Employees.AddOrUpdate(employee);
                context.SaveChanges();
            }
        }
        public void DeleteEmployee(string EmployeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == EmployeeId);
                if (employee == null) return;
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}
