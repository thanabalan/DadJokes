namespace DadJokes.API.Models
{
    public class BaseReponse
    {
        public bool Success { get; set; }
    }

    public class JokesResponse : BaseReponse
    {
        public List<JokesBody> Body { get; set; }
    }
    public class JokesResponseCount : BaseReponse
    {
        public int Body { get; set; }
    }

    public class JokesBody
    {
        public string? _id { get; set; }
        public string? Type { get; set; }
        public string? Setup { get; set; }
        public string? Punchline { get; set; }
    }
}
