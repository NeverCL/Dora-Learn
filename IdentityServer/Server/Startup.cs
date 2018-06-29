using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(opt=>{
                    opt.UserInteraction.LoginUrl = "/login";
                    opt.UserInteraction.LogoutUrl = "/logout";
                    opt.UserInteraction.ErrorUrl = "/error";
                })
                .AddDeveloperSigningCredential()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddTestUsers(Config.GetUsers());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseMiddleware<LoginMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }

    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TestUserStore _users;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        public LoginMiddleware(RequestDelegate next,
            IEventService events,
            IIdentityServerInteractionService interaction = null,
            TestUserStore users = null)
        {
            _next = next;
            _events = events;
            _interaction = interaction;
            _users = users;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/login"){
                var returnUrl = context.Request.Query["returnurl"];
                var user = _users.FindByUsername("alice");
                await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.SubjectId, user.Username));
                AuthenticationProperties props = null;
                await context.SignInAsync(user.SubjectId, user.Username, props);
                context.Response.Redirect(returnUrl);
            }else if (context.Request.Path == "/logout"){
                await context.Response.WriteAsync("logout lai le");
            }else if (context.Request.Path == "/error"){
                var errorId = context.Request.Query["errorId"];
                var message = await _interaction.GetErrorContextAsync(errorId);
                await context.Response.WriteAsync(message.ErrorDescription);
            }else{
                await _next.Invoke(context);
            }
        }
    }

}