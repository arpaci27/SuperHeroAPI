namespace SuperHeroAPI.Entities
{
	public class SuperHero
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName  { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
