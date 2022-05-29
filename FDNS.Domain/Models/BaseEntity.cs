using System;
using System.ComponentModel.DataAnnotations;

namespace FDNS.Domain.Models
{
    public abstract class BaseEntity<TKey> where TKey : IComparable
    {
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BaseEntity<TKey> entity && entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 17;
        }
    }
}
