#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Models;
using ContactList.Services;

namespace ContactList.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContacts _Icontact;

        public ContactsController(IContacts Icontact)
        {
            _Icontact = Icontact;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var a = _Icontact.GetAll();
            return View(a);
        }

        // GET: Contacts/Details/5
        public IActionResult Details(int id)
        {
            Contacts contact = _Icontact.getByID(id);
            return View(contact);  
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _Icontact.Insert(contacts);
                _Icontact.Save();
            }
            return RedirectToAction("Index");
        }

        // GET: Contacts/Edit/5
        public IActionResult Edit(int id)
        {
            Contacts contacts = _Icontact.getByID(id);
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contacts contacts)
        {
            _Icontact.Update(contacts);
            _Icontact.Save();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Delete/5
        public IActionResult Delete(int id)
        {
            _Icontact.Delete(id);
            _Icontact.Save();
            return RedirectToAction("Index");
        }

        // POST: Contacts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _Icontact.Delete(id);
        //    _Icontact.Save();
        //    return View("Index");
        //}
    }
}
