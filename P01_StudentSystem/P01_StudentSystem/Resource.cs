using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem
{
    internal class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public enum ResourceType
        {
            video,
            Presentation,
            Document,
            Other
        }
        public string EndDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
                 
    }
}
