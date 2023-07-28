using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RealEstate.Entities.Entities;
using RealEstate.UI.Models;
using MailKit.Net.Smtp;

namespace RealEstate.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM vm)
        {
            var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            var user = await userManager.FindByNameAsync(vm.Username);

            if (result.Succeeded && user.EmailConfirmed == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result.Succeeded && user.EmailConfirmed == false)
            {
                return RedirectToAction("Index", "ConfirmEmail");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterVM vm)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);
            if (vm.Password == null || vm.ConfirmPassword == null)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.Username,
                ConfirmCode = x,
                PhoneNumber=vm.PhoneNumber                
            };
            if (vm.Password == vm.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(user, vm.Password);
                await userManager.AddToRoleAsync(user, "Customer");
                if (result.Succeeded)
                {
                    SendMail(vm, x);
                    TempData["Username"] = user.UserName;
                    return RedirectToAction("Index", "ConfirmEmail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View();
        }





        private static void SendMail(RegisterVM vm, int code)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "demoprojemail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", vm.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Kayıt işlemi için onay kodunuz : " + code + ".";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Kayıt Onay Kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("demoprojemail@gmail.com", "lpcrysgsrzoeepzt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }
    }
}
