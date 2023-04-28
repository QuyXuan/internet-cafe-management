using DAL;
using System;
using System.Collections.Generic;
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
    }
}
