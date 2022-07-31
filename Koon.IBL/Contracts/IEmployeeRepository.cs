using Koon.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koon.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        List<EmployeeDetails> GetAllEmployees();
        IEnumerable<EmployeeState> GetAllStates();
        IEnumerable<EmployeeCity> GetAllCities();
        IEnumerable<EmployeeDepartment> GetAllDepartments();
        IEnumerable<EmployeeCity> GetCitiesOfState(int stateId);
        EmployeeDetails GetEmpbyId(int id);
        void AddEmployee(EmployeeDetails employee);
        void UpdateEmployee(EmployeeDetails oldEmpObj, EmployeeDetails updatedEmpObj);
        EmployeeState GetStatebyId(int id);
        EmployeeCity GetCitybyId(int id);
        int Save();
        void DeleteEmployee(int id);
    }
}
