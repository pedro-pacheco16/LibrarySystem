namespace LibrarySystem.API.Entities
{

    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        
        }

        public int Id { get; private set; }
    }
}
