#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamManagement.Data;
using TeamManagement.Models;
using TeamManagement.Models.dto;

namespace TeamManagement.Controllers
{
    public class TeamsController : Controller
    {
          private readonly TeamManagementContext _context;

        public TeamsController(TeamManagementContext context)
        {
            _context = context;
        }

        // GET: Teams
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team.ToListAsync());
        }
        //public IActionResult Member(int? Id)
        //{
        //    // Member team1 = new Member();
        //    var teams = from m in _context.Member
        //                where m.TeamId == Id
        //                join t in _context.Team on m.TeamId equals t.Id
        //                select new Member
        //                {
        //                    Name = m.Name,
        //                    Gender = m.Gender,
        //                    DOB = m.DOB,
        //                    MaritalStatus = m.MaritalStatus,
        //                    Address = m.Address,
        //                    PhoneNo = m.PhoneNo,
        //                    Skills = m.Skills,
        //                    Hobbies = m.Hobbies,
        //                    JobTitle = m.JobTitle,
        //                    Technology = m.Technology,
        //                    TeamId = m.TeamId
        //                };
        //    //Member team1 = new Member();
        //    //List<Member> teams = new List<Member>();

        //    //  team1 = _context.Member
        //    //     .FirstOrDefault(m => m.TeamId==Id);
        //    //  teams.Add(team1);

        //    // ViewBag.Member = teams;
        //    return View(teams);

        //}
        public IActionResult Member(int? Id)
        {
           //TeamMemberRole teamMemberRole = new TeamMemberRole();
            //ViewBag.Id = Id;
            //var result = from t in _context.Team
            //             where t.Id == Id
            //             join m in _context.Member on t.Id equals m.TeamId
            //             join r in _context.Role on t.RoleId equals r.RoleId
            //             select new TeamMemberRole
            //             {
            //                 Id = t.Id,
            //                 TeamName = t.TeamName,
            //                 MemberName = m.Name,
            //                 RoleName = r.RoleName,
            //             };


            //+var teams =  _context.NewMembers.Where(x => x.TeamId == Id).ToList();

            var result = from n in _context.NewMembers
                         where n.TeamId == Id
                         join m in _context.Member on n.MemberId equals m.MemberId
                         join r in _context.Role on n.RoleId equals r.RoleId
                         select new TeamMemberRole
                         {
                             Id = n.TeamId,
                             TeamName = _context.Team.Where(x=>x.Id == n.TeamId).FirstOrDefault().TeamName,
                             MemberName = m.Name,
                             RoleName = r.RoleName,
                         };

            if (result.Count()==0)
            {
                var teamMember = from n in _context.Team.Where(x => x.Id == Id)
                                 select new TeamMemberRole
                                 {
                                     Id = n.Id

                                 };
                return View("ErrorView", teamMember);
            }
            else
            {
                return View(result);
            }

        }

       
        public async Task<IActionResult> UpdateMember([Bind("Id,MemberId,RoleId")] Team team)
        {
            NewMembers newMembers = new NewMembers();   
            newMembers.TeamId = team.Id;
            newMembers.MemberId = team.MemberId;
            newMembers.RoleId = team.RoleId;
            _context.NewMembers.Add(newMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Member", new {id = newMembers.TeamId});
        }



        public IActionResult ADD(int? id)
        {

            ViewBag.Team = _context.Team.FirstOrDefault(m => m.Id == id).TeamName;
            ViewBag.Member = _context.Member.ToList();
            ViewBag.Role = _context.Role.ToList();
            ViewBag.Id = id;
            return View();
        }
       

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,ManagerName,Description,ProjectDone,NoOfMember")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,ManagerName,Description,ProjectDone,NoOfMember")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
    }
}
