﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Messenger.Models;

namespace Messenger.Models
{
    public class MessengerContext : DbContext
    {

        public MessengerContext(): base("Name=DatabaseConnection")
        {
        }

        public DbSet<UserViewModels> Users { get; set; }
        public DbSet<ConversationViewModels> Conversations { get; set; }
        public DbSet<FriendViewModels> Friends { get; set; }
        public DbSet<PersonalizationViewModels> Personalizations { get; set; }
        public DbSet<GroupListViewModels> Groups { get; set; }
        public DbSet<GroupMemberViewModels> Members { get; set; }
        public DbSet<ConversationGroupViewModels> ConversationGroups { get; set; }

    }
}