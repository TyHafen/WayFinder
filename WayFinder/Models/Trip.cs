using System;
using WayFinder.Interfaces;

namespace WayFinder.Models
{
    public class Trip : Virtual<int>
    {
        public string Name { get; set; }
    };

    public class Virtual<T> : IRepoItem<T>
    {
        public new T Id { get; set; }
        public new DateTime CreatedAt { get; set; }
        public new DateTime UpdatedAt { get; set; }

    }
}