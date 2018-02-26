using System.Collections.Generic;

namespace Task1Logic
{
    /// <summary>
    /// POCO class with teacher, his course manager and list of students
    /// </summary>
    public class ArchiveItem
    {
        /// <summary>
        /// Some teacher
        /// </summary>
        public Teacher Teacher { get; set; }
        /// <summary>
        /// POCO manager with course and state of course
        /// </summary>
        public CourseProcessing CourseManager { get; set; }
        /// <summary>
        /// List of students and their marks
        /// </summary>
        public List<Achievement> StudentsAndRates { get; set; }
    }
}
