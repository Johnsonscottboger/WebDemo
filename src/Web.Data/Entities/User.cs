using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data.Entities
{
    public class User
    {
        [Key]
        public Int64 UserId { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string profileImageUrl { get; set; }
        public string Location { get; set; }
        public string Signature { get; set; }
        public string Profile { get; set; }
        public string Weibo { get; set; }
        public string Avatar { get; set; }
        public string GithubId { get; set; }
        public string GithubUserName { get; set; }
        public string GithubAccessToken { get; set; }
        public bool Is_Block { get; set; } = false;

        public Int32 Score { get; set; }
        public Int32 Topic_Count { get; set; }
        public Int32 Reply_Count { get; set; }
        public Int32 Follower_Count { get; set; }
        public Int32 Following_Count { get; set; }
        public Int32 Collect_Tag_Count { get; set; }
        public Int32 Collect_Topic_Count { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public bool Is_Star { get; set; }
        public string Level { get; set; }
        public bool Active { get; set; }

        public bool Receive_Reply_Mail { get; set; } = false;
        public bool Receive_At_Mail { get; set; } = false;
        public bool From_WP { get; set; }

        public Int32 Retrieve_Time { get; set; }
        public string Retrieve_Key { get; set; }

        public string AccessToken { get; set; }

        public int UnreadMsg_Count { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
