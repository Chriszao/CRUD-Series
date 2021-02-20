using System;
using Entities.Enum;

namespace Entities
{
    public class Serie : EntityBase
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id + 1;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public string ReturnTitle()
        {
            return Title;
        }
        public int ReturnId()
        {
            return Id;
        }
        public bool ReturnDeleted()
        {
            return Deleted;
        }
        public void Delete()
        {
            Deleted = true;
        }

        public override string ToString()
        {
            string recurrence = "";
            recurrence += $"Genre: {Genre + Environment.NewLine}";
            recurrence += $"Title: {Title + Environment.NewLine}";
            recurrence += $"Description: {Description + Environment.NewLine}";
            recurrence += $"Release year: {Year + Environment.NewLine}";
            recurrence += $"Deleted: {Deleted}.";
            return recurrence;
        }
    }
}