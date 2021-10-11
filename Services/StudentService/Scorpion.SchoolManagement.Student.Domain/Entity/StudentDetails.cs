using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Scorpion.SchoolManagement.Common.Infra.Persister.Entity;

namespace Scorpion.SchoolManagement.Student.Domain.DBEntity
{
    public class StudentDetails: EntityBase
    {
        [Key]
        public int RecordId { get; set; }
        public string StudentName { get; set; }
    }
}
