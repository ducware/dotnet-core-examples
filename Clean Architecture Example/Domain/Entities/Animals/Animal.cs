using Domain.Common;

namespace Domain.Entities.Animal
{
    public class Animal : Entity
    {
        public Animal() {}
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsBird { get; set; }
    }
}
