using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccount.BLL.Bank;
using BankAccount.BLL.Interfaces;
using BankAccount.DAL.Account;
using BankAccount.DAL.DataModel;
using BankAccount.DAL.Storages;

namespace WebBank.Controllers
{
    public class HomeController : Controller
    {
        private IBank _bank = new Bank(new DbAccountStorage(), new IdGenerator(), "", "");        

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<PersonInfo> persons = _bank.GetPersons();
            ViewBag.Persons = persons;
             
            return View(persons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string surName, string mail)
        {
            ViewBag.Message = "Creating an account";

            try
            {
                _bank.CreateNewAccount(name, surName, mail);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string id, int currency, int cashType)
        {
            ViewBag.Message = "New cash";

            try
            {
                _bank.AddCash(id, (Currency)currency, (CashType)cashType);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Replenish()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Replenish(string id, Currency currency, double amount)
        {
            ViewBag.Message = "Replenishment";

            try
            {
                _bank.Replenish(id, currency, amount);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdraw(string id, Currency currency, double amount)
        {
            ViewBag.Message = "Withdraw";

            try
            {
                _bank.Deposit(id, currency, amount);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transfer(
            string sourceId, 
            string destinationId, 
            int sourceCurrency, 
            int destinationCurrency, 
            double amount)
        {
            ViewBag.Message = "Transferring";

            try
            {
                _bank.Transfer(sourceId, destinationId, (Currency)sourceCurrency, (Currency)destinationCurrency, amount);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Close()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Close(string id)
        {
            ViewBag.Message = "Closing";

            try
            {
                _bank.CloseAccount(id);
                TempData["Allert"] = "Success";
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Error";
                TempData["AllertMessage"] = e.Message;
            }

            return View();
        }
    }
}