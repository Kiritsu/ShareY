﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychicPotato.Authentications;
using PsychicPotato.Database;
using PsychicPotato.Models;

namespace PsychicPotato.Controllers
{
    [Route("admin"), Authorize(Policy = AdminRequirement.PolicyName)]
    public class AdminController : PsychicPotatoController
    {
        public AdminController(PsychicPotatoContext dbContext) : base(dbContext)
        {
        }

        [Route(""), HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("uploads"), HttpGet]
        public IActionResult Uploads()
        {
            var model = new AdminUploadsViewModel
            {
                Uploads = _dbContext.Uploads
                    .Include(x => x.Author)
                    .ToList()
            };
            return View(model);
        }

        [Route("uploads/{userGuid}"), HttpGet]
        public IActionResult Uploads(Guid? userGuid)
        {
            var model = new AdminUploadsViewModel
            {
                Uploads = _dbContext.Uploads
                    .Include(x => x.Author)
                    .Where(x => x.AuthorGuid == userGuid)
                    .ToList()
            };
            return View(model);
        }

        [Route("users"), HttpGet]
        public IActionResult Users()
        {
            var model = new AdminUsersViewModel
            {
                Users = _dbContext.Users
                    .Include(x => x.Token)
                    .Include(x => x.Uploads)
                    .ToList()
            };
            return View(model);
        }

        [Route("users/{userGuid}"), HttpGet]
        public IActionResult UserByGuid(Guid? userGuid)
        {
            return View();
        }

        [Route("settings"), HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
    }
}