using Koon.DAL;
using Koon.Models.Employees;
using Koon.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koon.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KoonDBContext _db;
        public EmployeeRepository(KoonDBContext db)
        {
            _db = db;
        }
        public List<EmployeeDetails> GetAllEmployees()
        {
            List<EmployeeDetails> employeeDetailsList = new List<EmployeeDetails>();
            try
            {
                employeeDetailsList = _db.EmployeeDetails.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employeeDetailsList;
        }
        IEnumerable<EmployeeState> IEmployeeRepository.GetAllStates()
        {
            IEnumerable<EmployeeState> employeeStateList = Enumerable.Empty<EmployeeState>();
            try
            {
                employeeStateList = _db.States.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employeeStateList;
        }

        public IEnumerable<EmployeeCity> GetAllCities()
        {
            IEnumerable<EmployeeCity> employeeCitiesList = Enumerable.Empty<EmployeeCity>();
            try
            {
                employeeCitiesList = _db.Cities.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employeeCitiesList;
        }

        public IEnumerable<EmployeeDepartment> GetAllDepartments()
        {
            IEnumerable<EmployeeDepartment> employeeDepartmentsList = Enumerable.Empty<EmployeeDepartment>();
            try
            {
                employeeDepartmentsList = _db.Departments.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employeeDepartmentsList;
        }

        public IEnumerable<EmployeeCity> GetCitiesOfState(int stateId)
        {
            IEnumerable<EmployeeCity> citiesList = Enumerable.Empty<EmployeeCity>();
            try
            {
                citiesList = _db.Cities.Where(m => m.StateId == stateId).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return citiesList;
        }

        public void AddEmployee(EmployeeDetails employee)
        {
            try
            {
                _db.EmployeeDetails.Add(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public int Save()
        {
            int result = 0;
            try
            {
                result = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public EmployeeDetails GetEmpbyId(int id)
        {
            EmployeeDetails emp = new EmployeeDetails();
            try
            {
                emp = _db.EmployeeDetails
            .FirstOrDefault(d => d.EmployeeId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emp;
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.EmployeeDetails.Find(id);
            if (employee != null) _db.EmployeeDetails.Remove(employee);
        }

        public void UpdateEmployee(EmployeeDetails oldEmpObj, EmployeeDetails updatedEmpObj)
        {
            try
            {
                _db.Entry(oldEmpObj).CurrentValues.SetValues(updatedEmpObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public EmployeeState GetStatebyId(int id)
        {
            EmployeeState stateObj = new EmployeeState();
            try
            {
                stateObj = _db.States.Where(state => state.StateId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stateObj;
        }

        public EmployeeCity GetCitybyId(int id)
        {
            EmployeeCity cityObj = new EmployeeCity();
            try
            {
                cityObj = _db.Cities.Where(city => city.CityId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cityObj;
        }
    }
}
