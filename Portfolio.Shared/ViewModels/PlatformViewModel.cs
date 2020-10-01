namespace Portfolio.Shared.ViewModels
{
    public class PlatformViewModel
    {
        public PlatformViewModel() { }
        public PlatformViewModel(Platform p)
        {
            Id = p.Id;
            Name = p.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}