public class MessageService
{
    int _random;

    public MessageService()
    {
        _random = new Random().Next();
    }

    public string Message()
    {
        return $"Yo #{_random}";
    }
}