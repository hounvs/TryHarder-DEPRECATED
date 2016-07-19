using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TryHarder.Models;
using System.IdentityModel.Services;
using System.Configuration;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using System.Collections.Generic;
using Auth0.AspNet;
using Auth0.ManagementApi.Models;
using System.Dynamic;
using Auth0.ManagementApi;

namespace TryHarder.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !this.Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "/";
            }

            // you can use this for the 'authParams.state' parameter
            // in Lock, to provide a return URL after the authentication flow.
            ViewBag.State = "ru=" + HttpUtility.UrlEncode(returnUrl);

            return this.View();
        }

        public RedirectResult Logout()
        {
            // Clear the session cookie
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            // Redirect to Auth0's logout endpoint
            var returnTo = "http://localhost:55484/";

            return this.Redirect(
                string.Format(CultureInfo.InvariantCulture,
                    "https://{0}/v2/logout?returnTo={1}",
                    ConfigurationManager.AppSettings["auth0:Domain"],
                    this.Server.UrlEncode(returnTo)));
        }

        // TODO: Add update user function
        //public async Task<ActionResult> UpdateUser(int SummonerId)
        //{
        //    var token = ClaimsPrincipal.Current.FindFirst("access_token").Value;
        //    ManagementApiClient client = new ManagementApiClient(
        //        ConfigurationManager.AppSettings["auth0:UpdateToken"],
        //        new Uri(string.Format("https://{0}/v2", ConfigurationManager.AppSettings["auth0:Domain"])));
        //    var updateUserRequest = new UserUpdateRequest();
        //    updateUserRequest.AppMetadata = new ExpandoObject();
        //    updateUserRequest.AppMetadata.SummonerId = SummonerId;
        //    var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
        //    var updateUserResponse = await client.Users.UpdateAsync(userId, updateUserRequest);

        //    return RedirectToAction("Index");
        //}
    }

    //public class UpdateCallback : HttpTaskAsyncHandler
    //{
    //    [Authorize]
    //    public override async Task ProcessRequestAsync()
    //    {
    //        var token = ClaimsPrincipal.Current.FindFirst("access_token").Value;
    //        ManagementApiClient client = new ManagementApiClient(token
    //            /*ConfigurationManager.AppSettings["auth0:UpdateToken"]*/,
    //            new Uri(string.Format("https://{0}/v2", ConfigurationManager.AppSettings["auth0:Domain"])));
    //        var updateUserRequest = new UserUpdateRequest();
    //        updateUserRequest.AppMetadata = new ExpandoObject();
    //        updateUserRequest.AppMetadata.SummonerId = context.Request.QueryString["SummonerId"];
    //        //var userId = ClaimsPrincipal.Current.FindFirst("user_id").Value;
    //        var updateUserResponse = await client.Users.UpdateAsync(context.User.Identity.GetUserId(), updateUserRequest);
    //    }
    //}
}