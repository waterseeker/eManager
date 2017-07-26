using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb : DbContext, IDepartmentDataSource
    {

        public DepartmentDb() : base("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        void IDepartmentDataSource.Save()
        {
            SaveChanges(); //this method is already in dbcontext 
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
           get { return Employees; }
        }
        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }
    }
}