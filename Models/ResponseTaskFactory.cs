using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public static class ResponseTaskFactory
    {

        public static ResponseDto CreateDto(int status, string? message, Tarea? task)
        {
            return new ResponseDto()
            {
                Message = message,
                Status = status,
                Task = task
            };
        }

    }

    public class ResponseDto
    {
        public string? Message { get; set; }
        public int Status { get; set; }
        public Tarea? Task { get; set; }
    }
}