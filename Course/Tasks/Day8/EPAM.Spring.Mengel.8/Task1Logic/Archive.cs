using System;
using System.Collections.Generic;

namespace Task1Logic
{
    /// <summary>
    /// Singleton archive class for saving elective data
    /// </summary>
    public sealed class Archive
    {
        #region Public Field

        /// <summary>
        /// Main storage for archive
        /// </summary>
        public List<ArchiveItem> ArchiveList { get; private set; } = new List<ArchiveItem>();

        #endregion

        #region Private Readonly Field

        private static readonly Lazy<Archive> lazy = new Lazy<Archive>(() => new Archive());

        #endregion

        #region Constructor

        private Archive() { }

        #endregion

        #region Public Static Property

        /// <summary>
        /// Singleton main method
        /// </summary>
        public static Archive Instance { get { return lazy.Value; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddData(ArchiveItem item) =>
            ArchiveList.Add(item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDataAt(int index) =>
            ArchiveList.RemoveAt(index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        public ArchiveItem FindData(Teacher teacher, Course course) =>
            ArchiveList.Find(i => i.CourseManager.Course == course && i.Teacher == teacher);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="course"></param>
        public void CreateCourse(Teacher teacher, Course course)
        {
            ArchiveList.Add(new ArchiveItem()
            {
                CourseManager = new CourseProcessing() { Course = course, State = EnumState.Awaiting },
                Teacher = teacher,
                StudentsAndRates = null
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="course"></param>
        /// <param name="state"></param>
        public void SetCourseState(Teacher teacher, Course course, EnumState state) =>
            FindData(teacher, course).CourseManager.State = state;

        #endregion

        #region Private Methods



        #endregion
    }
}
