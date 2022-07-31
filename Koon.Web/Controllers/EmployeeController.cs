using Koon.BAL.Contracts;
using Koon.BAL.Implementation;
using Koon.Models.Employees;
using Koon.Models.ViewModels;
using Koon.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koon.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        public IActionResult Index(string searchString = "", int pg = 1)
        {
           
            List<EmployeeDetails> employees = new List<EmployeeDetails>();
            try
            {
                

                employees = _employee.GetAllEmployees(searchString);
                const int pageSize = 5;
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = employees.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recsSkip = (pg - 1) * pageSize;
                //var data = employees.Skip(recsSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                
                return View(employees.Skip(recsSkip).Take(pager.PageSize).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(employees);
           
        }

        [HttpGet]
        public IActionResult Create(bool isSuccess = false)
        {
            AddUpdateEmployeeViewModel addEmployeeVMObj = new AddUpdateEmployeeViewModel();
            try
            {
                _employee.PopulateAddEmplVMObj(addEmployeeVMObj);
                addEmployeeVMObj.isSuccess = isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(addEmployeeVMObj);
        }

        [HttpPost]
        public IEnumerable<EmployeeCity> GetCitiesOfStates(int stateID)
        {
            IEnumerable<EmployeeCity> cityList = Enumerable.Empty<EmployeeCity>();
            try
            {
                cityList = _employee.GetCitiesOfState(stateID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cityList;
        }

        [HttpPost]
        public IActionResult Create(AddUpdateEmployeeViewModel empVM)
        {
            try
            {
                _employee.CreateEmpImageProcessing(empVM);

                if (ModelState.IsValid)
                {
                    if (_employee.AddEmployee(empVM.employee))
                    {
                        empVM.isSuccess = true;
                        return RedirectToAction(nameof(Create), new { isSuccess = empVM.isSuccess });
                    }
                }

                else
                {
                    _employee.PopulateAddEmplVMObj(empVM);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(empVM);
        }
        public IActionResult Details(int id)
        {
            DetailsViewModel detailVMObj = new DetailsViewModel();
            try
            {
                _employee.PopulateDetailsVMObj(id, detailVMObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(detailVMObj);
        }

        [HttpGet]
        public IActionResult Update(int id, bool isSuccess = false)
        {
            AddUpdateEmployeeViewModel vmObj = new AddUpdateEmployeeViewModel();
            try
            {
                _employee.PopulateAddEmplVMObj(vmObj);
                vmObj.employee = _employee.GetEmpbyId(id);
                vmObj.isSuccess = isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(vmObj);
        }
        
        [HttpPost]
        public IActionResult Update(AddUpdateEmployeeViewModel empVM)
        {
            try
            {
                _employee.CreateEmpImageProcessing(empVM);

                if (ModelState.IsValid)
                {
                    if (_employee.UpdateEmployee(empVM.employee.EmployeeId, empVM.employee))
                    {
                        empVM.isSuccess = true;
                        return RedirectToAction(nameof(Update), new { isSuccess = empVM.isSuccess });
                    }
                }

                else
                {
                    _employee.PopulateAddEmplVMObj(empVM);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(empVM);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employee.DeleteEmployee(id);

                }

                else

                    RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

    }

       
    }
    

