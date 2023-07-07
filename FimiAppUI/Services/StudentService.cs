﻿using FimiAppUI.Contracts;
using System.Collections.Generic;
using System.IO;

namespace FimiAppUI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId)
        {
            return await _httpClient.GetFromJsonAsync< IEnumerable<StudentModel>> ($"api/student/{classId}");
        }
        public async Task<StudentModel> GetStudentByStudentNumber(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<StudentModel>($"api/student/{studentNumber}");
        }
    }
}
