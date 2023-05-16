namespace TweetBook.Constants.V1;
public static class ApiRoutes {
    public const string Root = "api";
    public const string V1 = "v1";
    public const string Base = $"{Root}/{V1}";
    public static class Posts {
        public const string GetAll = $"{Base}/posts";
    }
}
