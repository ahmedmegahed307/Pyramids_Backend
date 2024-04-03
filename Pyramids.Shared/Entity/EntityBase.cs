namespace Pyramids.Shared.Entity
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTimeOffset CreatedAt { get; set; } = DateTime.Now;
        public virtual int? CreatedByUserId { get; set; } 
    }
}
