namespace LibrarySystem.Core.Entities
{

    public abstract class BaseEntity
    {
        protected BaseEntity()
        {

        }

        public int Id { get; private set; }

        public bool IsDeleted { get; private set; }

        public void setAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
