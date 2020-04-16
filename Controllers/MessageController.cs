using System;
using projeto_forum.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace projeto_forum.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private ForumDbContext _dbContext;

        public MessageController(ForumDbContext dbContext){
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index() {
            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            var messages = _dbContext.Message.Include("ToUser").Include("FromUser")
                .Where(m => m.ToUserId == user.Id || m.FromUserId == user.Id);
            return View(messages);
        }

        [HttpGet]
        public IActionResult Create(string toUserName) {
            var toUser = _dbContext.User.SingleOrDefault(u => u.Name == toUserName);
            if (toUser == null) {
                throw new Exception("User does not exist.");
            }

            var message = new Message { ToUserId = toUser.Id, ToUser = toUser };
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Message model) {
            if (!ModelState.IsValid) {
                throw new Exception("Invalide messasge information.");
            }

            var fromUser = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            model.FromUserId = fromUser.Id;
            model.SendDateTime = DateTime.Now;
            await _dbContext.Message.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            var message = _dbContext.Message.Include("ToUser").Include("FromUser")
                .SingleOrDefault(m => m.Id == id);
            if (message == null) {
                throw new Exception("Message does not exist.");
            }

            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            if (message.ToUserId != user.Id && message.FromUserId != user.Id) {
                throw new Exception("Message access dinied.");
            }

            if (message.ToUserId == user.Id) {
                message.IsRead = true;
            }

            _dbContext.Message.Update(message);
            await _dbContext.SaveChangesAsync();
            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            var message = _dbContext.Message.SingleOrDefault(m => m.Id == id);
            if (message == null) {
                throw new Exception("Message does not exist.");
            }

            var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
            if (message.ToUserId != user.Id && message.FromUserId != user.Id) {
                throw new Exception("Message access dinied.");
            }

            _dbContext.Message.Remove(message);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}