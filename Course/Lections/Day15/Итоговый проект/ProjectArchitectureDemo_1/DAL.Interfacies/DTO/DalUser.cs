namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}