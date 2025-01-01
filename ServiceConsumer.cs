public class ServiceConsumer
{
    HelloService _helloService;

    public ServiceConsumer(HelloService helloService)
    {
        _helloService = helloService;
    }

    public void Print()
    {
        _helloService.Print();
    }
}