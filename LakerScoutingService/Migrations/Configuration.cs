namespace LakerScoutingService.Migrations
{
    using DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LakerScoutingService.Models.LakerScoutingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LakerScoutingService.Models.LakerScoutingContext context)
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

