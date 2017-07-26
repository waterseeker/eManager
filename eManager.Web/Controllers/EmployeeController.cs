using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;
        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        [HttpGet] //runs the following code on a Get request
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();//initializes the view model
            model.DepartmentId = departmentId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if(ModelState.IsValid) //if the object created by the createemployeeviewmodel was valid ...
            {
                var department = _db.Departments.Single (d => d.Id == viewModel.DepartmentId);
                var employee = new Employee();
                //copy info from view model
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                //add the new employee to the employee collection\
                department.Employees.Add(employee);

                _db.Save();


                //redirect after successfully creating a new employee so we can see the employee on the department details page
                return RedirectToAction("detail", "department", new { id = viewModel.DepartmentId });
            }
            return View(viewModel); //if it's not, send user back to the viewModel
        }
    }
}