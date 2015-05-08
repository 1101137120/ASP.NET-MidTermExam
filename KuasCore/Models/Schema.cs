using System;
namespace KuasCore.Models
{
   public class Schema
    {
        public string CourseID { get; set; }

        public string CourseName { get; set; }

        public Int32 CourseDescription { get; set; }

        public override string ToString()
        {
            return "Schema: CourseID = " + CourseID + ", CourseName = " + CourseName + ".";
        }
    }
}
