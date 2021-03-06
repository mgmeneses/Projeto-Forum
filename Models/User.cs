﻿using System;
using System.Collections.Generic;

namespace projeto_forum.Models
{
    public partial class User
    {
        public User()
        {
            Forum = new HashSet<Forum>();
            MessageFromUser = new HashSet<Message>();
            MessageToUser = new HashSet<Message>();
            TopicModifiedByUser = new HashSet<Topic>();
            TopicOwner = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Description { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsLocked { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime LastLogInDateTime { get; set; }

        public virtual ICollection<Forum> Forum { get; set; }
        public virtual ICollection<Message> MessageFromUser { get; set; }
        public virtual ICollection<Message> MessageToUser { get; set; }
        public virtual ICollection<Topic> TopicModifiedByUser { get; set; }
        public virtual ICollection<Topic> TopicOwner { get; set; }
    }
}
