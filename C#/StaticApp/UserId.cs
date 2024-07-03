namespace StaticApp;

public class UserId
{
    private static int IdCounter = 0;
    public static int NewId => ++UserId.IdCounter;

    public readonly int Id;
    public UserId() => this.Id = UserId.NewId;
}