using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Domain.Models.Boards;
using Domain.Models.Sections;
using Domain.Models.Sprints;
using Domain.Models.Tasks;
using Domain.Models.Teams;

namespace Front.Test
{
    internal class TestDataContext : IDataContext
    {
        public void AddBoard(Board board)
        {
            //New board is added))))
        }

        public Board GetBoard()
        {
            var user = new User {Name = "John"};
            
            var board = new Board
            {
                Title = "Test Board",
                Description = "Learning domain models",
                Owner = new User {Name = "Calimber"},

                Sprints = new List<Sprint>(),
                Sections = new List<Section>(),
            };

            var sprints = new List<Sprint>
            {
                new()
                {
                    Board = board,
                    Starts = DateTime.UtcNow,
                    Ends = DateTime.UtcNow.AddDays(30),
                },
            };

            board.Sprints = sprints;

            var sections = new List<Section>
            {
                new()
                {
                    Title = "Open",
                    Description = "Unfinished tasks",
                    Board = board,
                },
                new()
                {
                    Title = "Released",
                    Description = "Finished tasks",
                    Board = board,
                },
            };

            board.Sections = sections;

            var unfinished = new List<Task>
            {
                new()
                {
                    Title = "Do work",
                    Type = TaskType.Task,
                    Priority = TaskPriority.Normal,
                    Section = board.Sections.First(),
                    Sprint = new List<Sprint> {board.Sprints.First()},
                    Assignees = new List<User> {user},
                },
                
                new()
                {
                    Title = "Solve problems",
                    Type = TaskType.Bug,
                    Priority = TaskPriority.Critical,
                    From = DateTime.UtcNow,
                    Until = DateTime.UtcNow.AddDays(1),
                    Section = board.Sections.First(),
                    Sprint = new List<Sprint> {board.Sprints.First()},
                    Assignees = new List<User> {user},
                },
            };

            var finished = new List<Task>
            {
                new()
                {
                    Title = "Get some beer",
                    Type = TaskType.Feature,
                    Priority = TaskPriority.Fatal,
                    Section = board.Sections.First(),
                    Sprint = new List<Sprint> {board.Sprints.First()},
                    Assignees = new List<User> {user},
                },
            };

            board.Sections.ElementAt(0).Tasks = unfinished;
            board.Sections.ElementAt(1).Tasks = finished;

            board.Sprints.ElementAt(0).Tasks = finished.Concat(unfinished).ToList(); 
            
            return board;
        }
    }
}