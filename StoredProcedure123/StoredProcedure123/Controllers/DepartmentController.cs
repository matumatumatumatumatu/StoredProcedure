using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoredProcedure123.Data;
using StoredProcedure123.Models;

namespace StoredProcedure123.Controllers
{
    public class DepartmentController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config;


        public DepartmentController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchDepartment";
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Department> model = new List<Department>();
                while (sdr.Read())
                {
                    var details = new Department();
                    details.DepartmentId = Convert.ToInt32(sdr["DepartmentId"]);
                    details.DepartmentName = sdr["DepartmentName"].ToString();
                    details.DepartmentLocation = Convert.ToInt32(sdr["DepartmentLocation"]);
                    details.EmployeeCount = Convert.ToInt32(sdr["EmployeeCount"]);
                    details.WeeklySalary = Convert.ToInt32(sdr["WeeklySalary"]);
                    model.Add(details);
                }

                return View(model);
            }
        }
    }
}
