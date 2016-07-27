using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using LakerScoutingService.DataObjects;
using LakerScoutingService.Models;
using Owin;
using System.Data.Entity.Migrations;
using LakerScoutingService.Migrations;

namespace LakerScoutingService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new LakerScoutingInitializer());

            //var migrator = new DbMigrator(new Migrations.Configuration());
            //migrator.Update();

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<LakerScoutingContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }
    public class LakerScoutingInitializer : DropCreateDatabaseAlways<LakerScoutingContext>
    {
        protected override void Seed(LakerScoutingContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };
            List<Team> teams = new List<Team>
            {
                new Team {Id = Guid.NewGuid().ToString(), TeamId = 5053, TeamName = "Laker Robotics", RookieYear = new DateTime(2014, 1, 8) },
                new Team {Id = Guid.NewGuid().ToString(), TeamId = 9999, TeamName = "Test Team", RookieYear = DateTime.Now }
            };
            List<Competition> competitions = new List<Competition>
            {
                new Competition {Id = Guid.NewGuid().ToString(), CompetitionId = 1, Location = "Waterford", TeamList = teams },
                new Competition {Id = Guid.NewGuid().ToString(), CompetitionId = 2, Location = "Flint", TeamList = new List<Team>() }
            };

            List<Match> matches = new List<Match>
            {
                new Match {Id = Guid.NewGuid().ToString(), CompetitionId = 1, TeamId = 5053, MatchNumber = 1, HighGoalsAttempted = 5, HighGoalsScored = 3, CrossLowBar = true},
                new Match {Id = Guid.NewGuid().ToString(), CompetitionId = 1, TeamId = 9999, MatchNumber = 1, HighGoalsAttempted = 3, HighGoalsScored = 0, CrossLowBar = false}
            };

            foreach (Competition competition in competitions)
            {
                context.Set<Competition>().Add(competition);
            }

            foreach (Team team in teams)
            {
                context.Set<Team>().Add(team);
            }
            foreach (Match match in matches)
            {
                context.Set<Match>().Add(match);
            }

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

