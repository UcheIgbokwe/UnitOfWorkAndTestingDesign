using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class EntityBase<T>
    {
        public virtual T Id { get; set; }
        
        [Required, StringLength(maximumLength: 250)]
        public virtual string Name { get; set; }
    }
}