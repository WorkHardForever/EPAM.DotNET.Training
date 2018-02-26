using System;
using System.Collections.Generic;

namespace Task1Logic
{
    /// <summary>
    /// Some teacher
    /// </summary>
    public class Teacher
    {
        #region Public Fields

        /// <summary>
        /// Name of teacher
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Age of expirience this teacher
        /// </summary>
        public int AgeOfExpirience { get; set; }
        /// <summary>
        /// Teacher's rank
        /// </summary>
        public string Rank { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        public void CreateCourse(Course course) =>
            Archive.Instance.CreateCourse(this, course);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        public void StartRecordToCourse(Course course) =>
            Archive.Instance.SetCourseState(this, course, EnumState.Recruitment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        public void StartCourse(Course course)
        {
            Archive.Instance.SetCourseState(this, course, EnumState.AtProcess);
            StudyAllStudentInCourse(course);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <param name="studentsMarks"></param>
        public void FinishCourse(Course course, List<int> studentsMarks)
        {
            var arhiveItem = Archive.Instance.FindData(this, course);

            if (arhiveItem.StudentsAndRates.Count != studentsMarks.Count)
                throw new ArgumentException($"Different counts between {nameof(arhiveItem.StudentsAndRates)} and {nameof(studentsMarks)}");

            RateTheStudents(arhiveItem, studentsMarks);

            arhiveItem.CourseManager.State = EnumState.Finished;
        }

        #endregion

        #region Private Method

        private void StudyAllStudentInCourse(Course course)
        {
            var arhiveItem = Archive.Instance.FindData(this, course);
            foreach (var item in arhiveItem.StudentsAndRates)
            {
                item.Student.StudyAtCourse();
            }
        }

        private void RateTheStudents(ArchiveItem arhiveItem, List<int> studentsMarks)
        {
            for (int i = 0; i < arhiveItem.StudentsAndRates.Count; i++)
            {
                arhiveItem.StudentsAndRates[i].Mark = studentsMarks[i];
            }
        }

        #endregion
    }
}
