﻿using Koon.BAL.Implementation;
using Koon.DAL;
using Koon.Repository.Contracts;
using Koon.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmpoyeeDetails
{
    public class IndexSuccessTest
    {
        public Mock<KoonDBContext> mockAppDbContext = new Mock<KoonDBContext>();

        [Fact]
            //Arrange
            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object);
        }

        /*private List<EmployeeDetails> GetSampleEmployee()
        {
            var output = new List<EmployeeDetails>
            {
                new EmployeeDetails
                {
                    EmployeeID = 51,
                    FirstName = "Akash",
                    LastName = "Deep",
                    Email = "mailto:akash.deep.xv@gmail.com",
                    Phone = "7206111686",
                    MaritalStatus = ,
                    EmployeeStateId = 1,
                    City = "Ambala"
                },
                new
                {
                    EmployeeID = 5,
                    FirstName = "Ashish12",
                    LastName = "Singla12",
                    Email = "mailto:abc12@gmail.com",
                    Phone = "7206111212",
                    MaritalStatus = Unmarried,
                    EmployeeStateId = 1,
                    City = "Ambala12"
                 }
            };

            return output;
        }*/
    }
}