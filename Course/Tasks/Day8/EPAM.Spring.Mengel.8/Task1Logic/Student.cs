namespace Task1Logic
{
    /// <summary>
    /// Some student
    /// </summary>
    public class Student
    {
        #region Public Fields

        /// <summary>
        /// Name of student
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Age of stundent
        /// </summary>
        public int Age { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Try record to course and return string answer
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        public string RecordToCourse(Teacher teacher, Course course)
        {
            var archiveItem = Archive.Instance.FindData(teacher, course);

            if (archiveItem.CourseManager.State != EnumState.Recruitment)
                return "I can't go to this course. :(";

            archiveItem.StudentsAndRates.Add(new Achievement() { Student = this });
            return "I have been writen to this course!";
        }

        /// <summary>
        /// Study at course process
        /// </summary>
        /// <returns></returns>
        public string StudyAtCourse() =>
            $"I study now!";

        #endregion
    }
}
