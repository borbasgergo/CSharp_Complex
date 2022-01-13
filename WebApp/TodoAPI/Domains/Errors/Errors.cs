namespace WebApp.TodoAPI.Domains.Errors;

public static class Errors
{
    public static readonly Error NotFound 
        = new ("NoTodoFound", "Todo could not be found with the given ID!");

    public static readonly Error NotDeleted 
        = new ("TodoNotDeleted", "Todo could not be deleted!");

    public static readonly Error NotAuthenticated
        = new("NotAuthenticated", "No permission for this action!");
}