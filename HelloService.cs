
public class HelloService
{
    MessageService _messageService;

    public HelloService(MessageService messageService)
    {
        _messageService = messageService;
    }

    public void Print()
    {
        Console.WriteLine($"Hello World {_messageService.Message()}");
    }
}