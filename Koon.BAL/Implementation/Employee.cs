using Koon.BAL.Contracts;
using Koon.Models.Employees;
using Koon.Models.ViewModels;
using Koon.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Koon.BAL.Implementation
{
    public class Employee : IEmployee
    {
        private readonly IEmployeeRepository _empRepo;
        public Employee(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        public List<EmployeeDetails> GetAllEmployees(string searchString)
        {
            List<EmployeeDetails> employees = new List<EmployeeDetails>();
            try
            {
                employees = _empRepo.GetAllEmployees();
                if (!string.IsNullOrEmpty(searchString))
                {
                    employees = employees.Where(s => (s.FirstName + " " + s.LastName).ToLower().Contains(searchString.ToLower())).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employees;
        }

        public IEnumerable<EmployeeState> GetAllStates()
        {
            IEnumerable<EmployeeState> states = Enumerable.Empty<EmployeeState>();
            try
            {
                states = _empRepo.GetAllStates();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return states;
        }

        public IEnumerable<EmployeeCity> GetAllCities()
        {
            IEnumerable<EmployeeCity> employeeCities = Enumerable.Empty<EmployeeCity>();
            try
            {
                employeeCities = _empRepo.GetAllCities();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employeeCities;
        }

        public IEnumerable<EmployeeDepartment> GetAllDepartments()
        {
            IEnumerable<EmployeeDepartment> employeeDepartments = Enumerable.Empty<EmployeeDepartment>();
            try
            {
                employeeDepartments = _empRepo.GetAllDepartments();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employeeDepartments;
        }

        public IEnumerable<EmployeeGender> GetAllGenders()
        {
            IEnumerable<EmployeeGender> gendersList = Enumerable.Empty<EmployeeGender>();
            try
            {
                gendersList = Enum.GetValues(typeof(EmployeeGender))
                            .Cast<EmployeeGender>().Where(m => (int)m != -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return gendersList;
        }

        public IEnumerable<EmployeeMaritalStatus> GetAllMaritalStatus()
        {
            IEnumerable<EmployeeMaritalStatus> maritalStatusList = Enumerable.Empty<EmployeeMaritalStatus>();
            try
            {
                maritalStatusList = Enum.GetValues(typeof(EmployeeMaritalStatus))
                            .Cast<EmployeeMaritalStatus>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return maritalStatusList;
        }

        public IEnumerable<EmployeeCity> GetCitiesOfState(int stateId)
        {
            IEnumerable<EmployeeCity> citiesList = Enumerable.Empty<EmployeeCity>();
            try
            {
                citiesList = _empRepo.GetCitiesOfState(stateId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return citiesList;
        }

        public EmployeeDetails GetEmpbyId(int id)
        {
            EmployeeDetails emp = new EmployeeDetails();
            try
            {
                emp = _empRepo.GetEmpbyId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emp;
        }

        public bool AddEmployee(EmployeeDetails employee)
        {
            bool result = false;
            try
            {
                _empRepo.AddEmployee(employee);
                result = Save() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public void PopulateAddEmplVMObj(AddUpdateEmployeeViewModel obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.employeeStates = GetAllStates();
                    obj.employeeCities = GetAllCities();
                    obj.employeeDepartments = GetAllDepartments();
                    obj.employeeGenders = GetAllGenders();
                    obj.maritalStatus = GetAllMaritalStatus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int Save()
        {
            int result = -1;
            try
            {
                result = _empRepo.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
       
        public void DeleteEmployee(int id)
        {
            try
            {
                _empRepo.DeleteEmployee(id);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public byte[] ImageToBytes(IFormFile file)
        {
            byte[] imageInBytes = new byte[] { };
            try
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        imageInBytes = ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return imageInBytes;
        }

        public byte[] Base64toImageBytes(string base64EncodedImage)
        {
            byte[] imageInBytes = new byte[] { };

            try
            {
                string base64DecodedImage = "";
                base64DecodedImage = base64EncodedImage.Substring(22);
                imageInBytes = Convert.FromBase64String(base64DecodedImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return imageInBytes;
        }

        public void CreateEmpImageProcessing(AddUpdateEmployeeViewModel obj)
        {
            try
            {
                if (obj != null)
                {
                    if (obj.imageFile != null)
                        obj.employee.Image = ImageToBytes(obj.imageFile);

                    else if (obj.imageSrc != null)
                        obj.employee.Image = Base64toImageBytes(obj.imageSrc);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool UpdateEmployee(int id, EmployeeDetails updatedEmpObj)
        {
            bool result = false;
            
            try
            {
                EmployeeDetails oldEmpObj = GetEmpbyId(id);
               
                if (oldEmpObj.EmployeeId > 0)
                {
                    updatedEmpObj.EmployeeId = oldEmpObj.EmployeeId;
                    _empRepo.UpdateEmployee(oldEmpObj, updatedEmpObj);
                }

                result = Save() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public EmployeeState GetStatebyId(int id)
        {
            EmployeeState stateObj = new EmployeeState();
            try
            {
                stateObj = _empRepo.GetStatebyId(id);
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
                cityObj = _empRepo.GetCitybyId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cityObj;
        }
        public void PopulateDetailsVMObj(int empId, DetailsViewModel obj)
        {
            try
            {
                obj.employeeDetails = GetEmpbyId(empId);
                obj.StateName = GetStatebyId(obj.employeeDetails.StateId).StateName;
                obj.CityName = GetCitybyId(obj.employeeDetails.CityId).CityName;
                obj.imageSrc = ImageBytestoString(obj.employeeDetails.Image);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ImageBytestoString(byte[] imageBytes)
        {
            string imgSrc = "";
            try
            {
                string base64 = Convert.ToBase64String(imageBytes);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return imgSrc;
        }
    }
}
    


