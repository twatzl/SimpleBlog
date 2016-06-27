using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Entity
{
    public class EntityObject : IEntityObject
    {
        #region IEnityObject Members

        [Key]
        public virtual int Id { get; set; }

        [Timestamp]
        public virtual byte[] Timestamp
        {
            get;
            set;
        }

        #endregion
    }
}
