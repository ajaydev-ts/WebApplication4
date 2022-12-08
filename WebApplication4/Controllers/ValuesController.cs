using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly companyContext cc;  //object creation
        public ValuesController(companyContext cc)
        {
            this.cc = cc;
        }
        [HttpGet("getallEmployee")]
        public List<Employee> getemp()
        {
            var data = this.cc.Employees.ToList();
            return data;
        }
        [HttpPost("postallEmployee")]
        public string postemp(Employee ep)
        {
            this.cc.Add(ep);
            this.cc.SaveChanges();
            return "Success";
        }
        [HttpPut("updateEmployee")]

        public string updateemp(Employee ep)
        {
            if (ep == null || ep.Empid == 0)
            {
                return "bad request";
            }
            this.cc.Employees.Update(ep);
            this.cc.SaveChanges();
            return "Success";
        }
        [HttpGet("getall")]
        public List<Department> get1()
        {
            var data = this.cc.Departments.ToList();
            return data;
        }
        [HttpPost("postall")]
        public string post1(Department dep)
        {
            this.cc.Add(dep);
            this.cc.SaveChanges();
            return "Success";
        }
        [HttpPut("updateDepartment")]

        public string putdept(Department dep)
        {
            if (dep == null || dep.DeptId == 0)
            {
                return "bad request";
            }

            this.cc.Departments.Update(dep);
            var data = this.cc.Departments.Find(dep.DeptId);
            if (data == null)
            {
                return "no data found";
            }
            data.Deptame = dep.Deptame;
            data.DeptId = dep.DeptId;
            this.cc.SaveChanges();
            return "Success";
        }
        [HttpDelete("delDept")]
          public string delete(int id)
        {
            var data = this.cc.Departments.Find(id);
            if(data == null)
            {
                return "no data ";
            }
            this.cc.Departments.Remove(data);
            this.cc.SaveChanges();
            return "Success";
        }
        [HttpDelete("delemployee")]
        public string deleteemp(Employee em)
        {
            this.cc.Employees.Remove(em);
            this.cc.SaveChanges();
            return "Success";
        }

    }
}
