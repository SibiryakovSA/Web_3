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
            return View("issues");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetIssues()
        {
            if (User.Claims.ToList()[1].Value == "2")
                return GetAllIssues();
            return GetUserIssues();
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult GetAllIssues()
        {
            return Ok(db.issues);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserIssues()
        {
            var user = db.users.FirstOrDefault(x => x.login == User.Claims.ToList()[0].Value);
            return Ok(db.issues.Where(x => x.userId == user.id));
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
                var t = db.Remove(issue);
                db.SaveChanges();
                return Ok(GetIssues());
            }

            return NotFound();
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

            return Ok();
        }
    }
}
