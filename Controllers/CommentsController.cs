using System;
using System.Linq;
using Web_3_6.Models.DataBase;
using Web_3_6.Models.DataBase.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_3_6.Controllers
{
    public class CommentsController : Controller
    {
        private readonly Context db = null;

        public CommentsController(Context context)
        {
            db = context;
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetIssueComments(int issueId)
        {
            var userClaims = User.Claims.ToList();
            var user = db.users.FirstOrDefault(u => u.login == userClaims[0].Value);
            var issue = db.issues.FirstOrDefault(i => i.id == issueId);
            
            if (issue == null)
                return NotFound();

            if (userClaims[1].Value != "2" && issue.userId != user.id)
                return NotFound();

            var comments = db.comments.Where(x => x.issueId == issueId);
            return PartialView("CommentsPartial", comments);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddIssueComment(int issueId, string commentText)
        {
            var userClaims = User.Claims.ToList();
            var user = db.users.FirstOrDefault(u => u.login == userClaims[0].Value);
            var issue = db.issues.FirstOrDefault(i => i.id == issueId);
            
            if (issue == null)
                return NotFound();

            if (userClaims[1].Value != "2" && issue.userId != user.id)
                return NotFound();

            var comment = new Comment()
            {
                commentText = commentText,
                creationDateAndTime = DateTime.Now,
                issueId = issueId,
                userId = user.id
            };

            db.comments.Add(comment);
            db.SaveChanges();
            //return Ok();
            var comments = db.comments.Where(x => x.issueId == issueId);
            return PartialView("CommentsPartial", comments);
        }
    }
}