﻿namespace FimiAppLibrary.DataAccess
{
    public class StudentData : IStudentData
    {
        private readonly ISqlDbConnection _db;

        public StudentData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<StudentModel>> GetStudent()
        {
            string sql = "SELECT * FROM dbo.Student";
            return _db.LoadData<StudentModel, dynamic>(sql, new { });
        }
        public Task InsertStudent(StudentModel student)
        {
            string sql = @"INSERT INTO dbo.Student(FirstName, MiddleName, Surname)
                            VALUES (@FirstName, @MiddleName, @Surname)";
            return _db.SaveData(sql, student);
        }
    }
}