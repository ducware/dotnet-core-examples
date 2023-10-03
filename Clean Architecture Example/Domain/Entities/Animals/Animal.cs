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

        public void UpdateAnimal(string name, string description, int age, bool is_bird)
        {
            this.Name = name;
            this.Description = description;
            this.Age = age;
            this.IsBird = is_bird;
            UpdatedAt = DateTime.Now;
        }
    }
}
