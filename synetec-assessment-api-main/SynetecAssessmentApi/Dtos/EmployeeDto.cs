﻿namespace SynetecAssessmentApi.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
