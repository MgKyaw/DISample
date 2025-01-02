
public class HelloService
{
    MessageService _messageService;
    int _random;

    public HelloService(MessageService messageService)
    {
        _messageService = messageService;
        _random = new Random().Next();
    }

    public void Print()
    {
        Console.WriteLine($"Hello World #{_random} {_messageService.Message()}");
    }
}