﻿using System;
using System.Collections.Generic;

namespace projeto_forum.Models
{
    public partial class Topic
    {
        public Topic()
        {
            InverseReplyToTopic = new HashSet<Topic>();
            InverseRootTopic = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ForumId { get; set; }
        public int? RootTopicId { get; set; }
        public int? ReplyToTopicId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDateTime { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime? ModifyDateTime { get; set; }
        public bool IsLocked { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual User Owner { get; set; }
        public virtual Topic ReplyToTopic { get; set; }
        public virtual Topic RootTopic { get; set; }
        public virtual ICollection<Topic> InverseReplyToTopic { get; set; }
        public virtual ICollection<Topic> InverseRootTopic { get; set; }
    }
}
