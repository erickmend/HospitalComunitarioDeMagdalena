﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public void CreateEntity()
        {
            CreationDate = DateTime.UtcNow;
            EditEntity();
            IsActive = true;
            IsDeleted = false;
        }
        public void EditEntity()
        {
            LastUpdate = DateTime.UtcNow;
        }

        public void ChangeStatus()
        {
            IsActive = !IsActive;
            EditEntity();
        }

        public void Delete()
        {
            IsActive = false;
            IsDeleted = true;
            EditEntity();
        }
    }
}
