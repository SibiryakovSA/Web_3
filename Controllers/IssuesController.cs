using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_3_6.Models.DataBase;
using Web_3_6.Models.DataBase.Classes;

namespace Web_3_6.Controllers
{
    public class IssuesController : Controller
    {
        public Context db = null;

        public IssuesController(Context context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("issues", GetIssues());
        }

        private IActionResult IssuesPartial()
        {
            return PartialView("issuesPartial", GetIssues());
        }
        
        [Authorize]
        public IQueryable<Issue> GetIssues()
        {
            if (User.Claims.ToList()[1].Value == "2")
                return GetAllIssues();
            return GetUserIssues();
        }

        [Authorize(Roles = "2")]
        private IQueryable<Issue> GetAllIssues()
        {
            return db.issues;
        }

        [Authorize]
        private IQueryable<Issue> GetUserIssues()
        {
            var user = db.users.FirstOrDefault(x => x.login == User.Claims.ToList()[0].Value);
            return db.issues.Where(x => x.userId == user.id);
        }


        [Authorize]
        [HttpPost]
        public IActionResult DeleteIssue(int id)
        {
            var user = db.users.FirstOrDefault(x => x.login == User.Claims.ToList()[0].Value);
            IQueryable<Issue> userIssues;
            if (user.role == 2)
            {
                userIssues = db.issues;
            }
            else
                userIssues = db.issues.Where(x => x.userId == user.id);

            var issue = userIssues.FirstOrDefault(x => x.id == id);
            if (issue != null) {
                var comments = db.comments.Where(x => x.issueId == issue.id);
                db.RemoveRange(comments);
                db.Remove(issue);
                db.SaveChanges();
            }

            return IssuesPartial();
        }

        //ПРОТЕСТИ МЕТОД
        [Authorize]
        [HttpPost]
        public IActionResult AddIssue(string issueName, string issueText = "", bool isComplited = false)
        {
            var user = db.users.FirstOrDefault(x => x.login == User.Claims.ToList()[0].Value);
            var issue = new Issue() { isComplited = isComplited, issueText = issueText, issueName = issueName, userId = user.id };

            db.issues.Add(issue);
            db.SaveChanges();

            return IssuesPartial();
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult EditIssue(int issueId, string issueName = null, string issueText = null,
            bool? isComplited = null)
        {
            var userClaims = User.Claims.ToList();
            var user = db.users.FirstOrDefault(u => u.login == userClaims[0].Value);
            var issue = db.issues.FirstOrDefault(i => i.id == issueId);
            
            if (issue == null)
                return NotFound();

            if (userClaims[1].Value != "2" && issue.userId != user.id)
                return Forbid();

            if (issueName == null && issueText == null && isComplited == null)
                return BadRequest();
            
            if (issueName != null) 
                issue.issueName = issueName;

            if (issueText != null)
                issue.issueText = issueText;

            if (isComplited != null) 
                issue.isComplited = (bool) isComplited;

            db.SaveChanges();
            return IssuesPartial();
        }
    }
}
