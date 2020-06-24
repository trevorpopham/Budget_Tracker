using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using Budget_Tracker.Helpers;
using Budget_Tracker.Models;
using Microsoft.AspNet.Identity;

namespace Budget_Tracker.Controllers
{
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserRoleHelper roleHelper = new UserRoleHelper();
        

        [Authorize] // role head
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InviteUser(string userId, int householdId, string email)
        {
            var user = db.Users.Find(userId);

            Invitation invitation = new Invitation
            {
                Code = Guid.NewGuid(),
                HouseholdId = householdId,
                Created = DateTime.Now,
                TimeToLive = DateTime.Now.AddDays(1),
                IsValid = true,
                RecipientEmail = email
            };
            db.Invitations.Add(invitation);
            db.SaveChanges();

            var callbackUrl = Url.Action("RegisterUser", "Account", new { code = invitation.Code }, protocol: Request.Url.Scheme);
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.From = new MailAddress("mattpark102@outlook.com");
            mailMessage.Subject = "Invite to financial portal.";
            mailMessage.Body = $"You got an invite from {user.FullName} to join household {user.Household.Name}. Click <a href=\"" + callbackUrl + "\">here</a>.";
            mailMessage.IsBodyHtml = true;
            ModelState.AddModelError("Message", "Message has been sent.");
            EmailHelper.Send(mailMessage);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult KickUser(string userId)
        {
            var user = db.Users.Find(userId);

            user.HouseholdId = null;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string householdName, bool createBudgets)
        {
            var user = db.Users.Find(User.Identity.GetUserId());

            Household household = new Household
            {
                Name = householdName
            };

            db.Households.Add(household);

            if (createBudgets)
            {
                #region Budgets

                Budget food = new Budget
                {
                    Name = "Food",
                    Spent = 0,
                    Target = 0
                };

                Budget utilities = new Budget
                {
                    Name = "Utilities",
                    Spent = 0,
                    Target = 0
                };

                Budget entertainment = new Budget
                {
                    Name = "Entertainment",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem restaurant = new BudgetItem
                {
                    Name = "Restaurant",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem fastFood = new BudgetItem
                {
                    Name = "Fast Food",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem groceries = new BudgetItem
                {
                    Name = "Groceries",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem electricity = new BudgetItem
                {
                    Name = "Electricity",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem gas = new BudgetItem
                {
                    Name = "Gas",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem water = new BudgetItem
                {
                    Name = "Water",
                    Spent = 0,
                    Target = 0
                };

                BudgetItem internet = new BudgetItem
                {
                    Name = "Cable and Internet",
                    Spent = 0,
                    Target = 0
                };

                db.SaveChanges();

                food.BudgetItems.Add(groceries);
                food.BudgetItems.Add(fastFood);
                food.BudgetItems.Add(restaurant);

                utilities.BudgetItems.Add(gas);
                utilities.BudgetItems.Add(water);
                utilities.BudgetItems.Add(electricity);

                entertainment.BudgetItems.Add(internet);

                db.SaveChanges();

                household.Budgets.Add(food);
                household.Budgets.Add(utilities);
                household.Budgets.Add(entertainment);

                db.SaveChanges();

                #endregion
            }

            user.HouseholdId = household.Id;

            db.SaveChanges();

            roleHelper.ChangeUserRoleTo(user.Id, "Head");

            return RedirectToAction("Index", "Home");
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBudget(int budgetId, decimal balance, decimal startAmount)
        {
            var household = db.Households.Find(budgetId);
            household.Balance = balance;
            household.StartAmount = startAmount;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveMember(string userId)
        {
            var user = db.Users.Find(userId);
            var household = db.Households.Find(user.HouseholdId);
            user.HouseholdId = null;
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult LeaveHouseholdHeadWithMembers(string userId, string newHeadId)
        {
            var user = db.Users.Find(userId);
            user.HouseholdId = null;
            roleHelper.ChangeUserRoleTo(newHeadId, "Head");
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
