using System;

namespace Task1Logic
{
    /// <summary>
    /// POCO class Course with name, description and other
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Name of this course
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Short description of the course
        /// </summary>
        public string Desciption { get; private set; }
        /// <summary>
        /// Time of course continue
        /// </summary>
        public DateTime Time { get; private set; }
        /// <summary>
        /// Who teach in the course
        /// </summary>
        public Teacher Teacher { get; private set; }
    }
}
