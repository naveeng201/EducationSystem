using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    public class ClassSubjectViewModel
    {
        public int Id { get; set; }
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
    }
}
