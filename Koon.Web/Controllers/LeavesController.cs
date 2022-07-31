using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Koon.DAL;
using Koon.Models.Leave;
using Koon.Models.ViewModels;
using MimeKit;
using Koon.Models.Employees;

namespace Koon.Web.Controllers
{
    public class LeavesController : Controller
    {
        private readonly KoonDBContext _context;

        public LeavesController(KoonDBContext context)
        {
            _context = context;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.LeaveApplications.ToListAsync());
        }        

        // GET: Leaves/Apply
        public IActionResult Apply(int id, string fname, string lname, string mail)
        {
            ApplyLeave leaveObj = new ApplyLeave();
            leaveObj.EmployeeId = id;
            leaveObj.Name = fname + " " + lname;
            leaveObj.Email = mail;
            return View(leaveObj);
        }

        // POST: Leaves/Apply
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply([Bind("Email, EmployeeId, Name, LeaveId, FromDate,ToDate,NumberOfDays,LeaveType,LeaveCategory,ReasonForLeave")] ApplyLeave leaveForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveForm);
                await _context.SaveChangesAsync();
                Sent(leaveForm);
                return RedirectToAction(nameof(Index));
            }

            return View(leaveForm);
        }

        public void Sent(ApplyLeave leave)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("IT Admin", "try.for.ems@gmail.com"));
            message.To.Add(new MailboxAddress(leave.Name, leave.Email));
            message.Subject = leave.ReasonForLeave;
            message.Body = new TextPart("html")
            {
                Text =
                "<htm><em>Dear " +
                leave.Name + " " +
                ", </em><br>" +
                "You application for a " +
                leave.LeaveCategory + " " +
                leave.LeaveType + " " +
                "from " +
                leave.FromDate + "to " +
                leave.ToDate + " " +
                "for a total of " + leave.NumberOfDays + " days. <br>" +
                "You will be notified once your leave gets approved.<br> PS: This is an auto - generated mail, please do not reply."
                + "<br>Regards, <br> IT Admin </htm > ",
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("try.for.ems@gmail.com", "Admin@2314");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        //GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveForm = await _context.LeaveApplications
                .FirstOrDefaultAsync(m => m.LeaveId == id);
            if (leaveForm == null)
            {
                return NotFound();
            }

            return View(leaveForm);
        }

        //// POST: Leaves/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var leaveForm = await _context.LeaveApplications.FindAsync(id);
        //    _context.LeaveApplications.Remove(leaveForm);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            deleteconfirm(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult deleteconfirm(int id)
        {
            DeleteLeaveApplication(id);
;
            return RedirectToAction(nameof(Index));
        }

        public bool DeleteLeaveApplication(int leaveId)
        {
            var result = _context.LeaveApplications
                .FirstOrDefault(e => e.LeaveId == leaveId);
            try
            {
                if (result != null)
                {
                    _context.LeaveApplications.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        private bool LeaveFormExists(int id)
        {
            return _context.LeaveApplications.Any(e => e.LeaveId == id);
        }
    }
}
