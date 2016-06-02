using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Required imports for db access
using lesson_4.Models;
using System.Web.ModelBinding;


namespace lesson_4
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                // Use the student model to save a new record
                Student NewStudent = new Student();

                NewStudent.FirstMidName = txtFirstName.Text;
                NewStudent.LastName = txtLastName.Text;
                NewStudent.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                // Add a new student to the StudentTable collection
                db.Students.Add(NewStudent);

                // Run insert
                db.SaveChanges();

                // Redirect to the updated students page
                Response.Redirect("Students.aspx");
            }
        }

    }
}