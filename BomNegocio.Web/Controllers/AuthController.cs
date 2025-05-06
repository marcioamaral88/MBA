using BomNegocio.Dados.Repositorios;
using BomNegocio.Modelo;
using BomNegocio.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BomNegocio.Web.Controllers
{
 
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;   
        private readonly VendedorRepositorio _vendedorRepositorio;

        public AuthController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,                           
                              VendedorRepositorio vendedorRepositorio)
        {
            _signInManager = signInManager;
            _userManager = userManager;  
            _vendedorRepositorio = vendedorRepositorio;
        }

        [HttpGet]
        public IActionResult Registrar() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
                try
                {
                    var user = new IdentityUser
                    {
                        UserName = registerUser.Email,
                        Email = registerUser.Email,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, registerUser.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);

                        Vendedor vendedor = new Vendedor();

                        vendedor.Id = user.Id;
                        vendedor.Nome = user.UserName;
                        _vendedorRepositorio.Adicionar(vendedor);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Favor, verifique o mínimo de segurança para criar a senha!");
                    }

                    
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Erro no cadastro!"+ e.Message);
                }
   
            return View(registerUser);

        }

        [HttpGet]
        public IActionResult Login() => View();
          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
                try
                {
                    var user = await _userManager.FindByEmailAsync(loginUser.Email);
                    if (user == null)
                        ModelState.AddModelError("", "Usuário ou senha incorretos!");
                   
                    var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, true);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home");
                    }else
                        ModelState.AddModelError("", "Usuário ou senha incorretos!");
             
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Usuário ou senha incorretos!");
                }

            return View(loginUser);
        }

        [HttpGet]
        public IActionResult AcessoNegado() => View();
               
        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
