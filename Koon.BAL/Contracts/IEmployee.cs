using Koon.Models.Employees;
using Koon.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koon.BAL.Contracts
{
    public interface IEmployee
    {
        List<EmployeeDetails> GetAllEmployees(string searchString);
        IEnumerable<EmployeeState> GetAllStates();
        IEnumerable<EmployeeCity> GetAllCities();
        IEnumerable<EmployeeDepartment> GetAllDepartments();
        IEnumerable<EmployeeGender> GetAllGenders();
        IEnumerable<EmployeeMaritalStatus> GetAllMaritalStatus();
        IEnumerable<EmployeeCity> GetCitiesOfState(int stateId);
        EmployeeDetails GetEmpbyId(int id);
        bool AddEmployee(EmployeeDetails employee);
        void PopulateAddEmplVMObj(AddUpdateEmployeeViewModel obj);
        void CreateEmpImageProcessing(AddUpdateEmployeeViewModel obj);
        byte[] ImageToBytes(IFormFile file);
        byte[] Base64toImageBytes(string base64EncodedImage);
        bool UpdateEmployee(int id, EmployeeDetails updatedEmpObj);
        EmployeeState GetStatebyId(int id);
        EmployeeCity GetCitybyId(int id);
        void PopulateDetailsVMObj(int empid, DetailsViewModel obj);
        string ImageBytestoString(byte[] imageBytes);
        int Save();
        void DeleteEmployee(int id);
    }
}
