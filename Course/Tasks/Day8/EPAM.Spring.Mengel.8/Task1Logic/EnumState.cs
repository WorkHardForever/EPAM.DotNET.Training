namespace Task1Logic
{
    /// <summary>
    /// State of course
    /// </summary>
    public enum EnumState
    {
        /// <summary>
        /// Hust created course
        /// </summary>
        Awaiting,
        /// <summary>
        /// Start recording students to course
        /// </summary>
        Recruitment,
        /// <summary>
        /// Course start work
        /// </summary>
        AtProcess,
        /// <summary>
        /// Course over it's work
        /// </summary>
        Finished
    }
}
