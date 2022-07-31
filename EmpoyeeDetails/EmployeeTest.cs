//using System;
//using Xunit;

//namespace EmpoyeeDetails
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Test1()
//        {

//        }
//    }
//}

using Koon.DAL;
using Koon.Repository.Contracts;
using Koon.Web.Controllers;using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore.Query;using Microsoft.Extensions.Logging;using Moq;using Newtonsoft.Json.Linq;using System;using System.Collections.Generic;using System.Linq;using System.Numerics;using System.Threading.Tasks;using Xunit;namespace EmployeeDetails{    public class EmployeeTest    {

        //public Mock<KoonDBContext> mockAppDbContext = new Mock<KoonDbContext>();
        //public Mock<IEmployeeRepository> mockEmployeeRepository = new Mock<IEmployeeRepository>();


        //[Fact]
        //public async void Test_GetEmployees_Success()
        //{
        //    mockEmployeeRepository.Setup(t => t.GetEmployees()).ReturnsAsync(GetSampleEmployee());
        //    //Arrange
        //    EmployeeController employeeController = new EmployeeController(mockAppDbContext.Object, mockEmployeeRepository.Object);
        //    var actionResult = await employeeController.Index("Ashish", "Ashish", 1);
        //    var viewResult = Assert.IsType<ViewResult>(actionResult);
        //    var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(viewResult.ViewData.Model);
        //    Assert.IsType<List<Employee>>(model);






    //    // Assert.IsType(GetSampleEmployee(),actionResult);
    //}
    ////.IsAssignableFrom<IEnumerable<Employee>>(
    ////        viewResult.ViewData.Model);
    //[Fact]
    //public async void Test_GetEmployeeById()
    //{
    //    int testSessionId = 4;
    //    mockEmployeeRepository.Setup(t => t.GetEmployee(testSessionId)).ReturnsAsync(GetSampleEmployee().First(
    //    s => s.EmployeeID == testSessionId));
    //    EmployeeController employeesController = new EmployeeController(mockAppDbContext.Object, mockEmployeeRepository.Object);
    //    var actionResult = await employeeController.Details(testSessionId);

    //    //  var viewResult = Assert.IsType<ViewResult>(actionResult);
    //    // var model = Assert.IsType<Employee>();
    //    //  var actualResult = result.Value as Employee;

    //    // Assert.IsType<OkObjectResult>(result);
    //    // Assert.Equal(SampleEmployee, ((Employee)actualResult));
    //    // Assert.IsType<List<Employee>>(model);
    //    //Assert.Equal(testSessionId, SampleEmployee.EmployeeID);
    //}



    //private List<Employee> GetSampleEmployee()
    //{
    //    var output = new List<Employee>
    //{
    //    new Employee
    //    {
    //        EmployeeID = 4,
    //        FirstName = "Ashish",
    //        LastName = "Singla",
    //        Email = "mailto:abc@gmail.com",
    //        Phone = "7206111686",
    //        MaritalStatus = MaritalStatus.Married,
    //        EmployeeStateId = 1,
    //        City = "Ambala"
    //    },
    //    new Employee
    //    {
    //        EmployeeID = 5,
    //        FirstName = "Ashish12",
    //        LastName = "Singla12",
    //        Email = "mailto:abc12@gmail.com",
    //        Phone = "7206111212",
    //        MaritalStatus = MaritalStatus.Unmarried,
    //        EmployeeStateId = 1,
    //        City = "Ambala12"
    //    }
    //};
    //    return output;
    //}
}}



//var result =  actionResult as OkObjectResult;
// var actual = result.Value as IEnumerable<Employee>;
// Assert.Equal(GetTestSessions().Count(), actual.Count());
//var viewResult = Assert.IsType<ViewResult>(actionResult);
// var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(viewResult.ViewData.Model);
// Assert.Equal(this.GetSampleEmployee().Count(), actual.Count());


//var sampleEmployee = new Employee()
//{
//    EmployeeID = 4,
//    FirstName = "Ashish",
//    LastName = "Singla",
//    Email = "mailto:abc@gmail.com",
//    Phone = "7206111686",
//    MaritalStatus = MaritalStatus.Married,
//    EmployeeStateId = 1,
//    City = "Ambala"
//};
