using System;

namespace Web_3_6.Models.DataBase.Classes
{
    public class Comment
    {
        public int id { get; set; }
        public DateTime? creationDateAndTime { get; set; }
        public string commentText { get; set; }
        public int userId { get; set; }
        public int issueId { get; set; }
    }
}