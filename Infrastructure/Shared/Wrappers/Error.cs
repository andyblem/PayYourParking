namespace Shared.Wrappers
{
    public class Error
    {
        public string? ErrorMessage { get; set; }
        public string? PropertyName { get; set; }

        public IEnumerable<string>? ErrorMessages { get; set; }

    }
}
