// var helloService = new HelloService();
// var serviceConsumer = new ServiceConsumer(helloService);

var helloService = (HelloService) Activator.CreateInstance(typeof(HelloService));
var serviceConsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), helloService);

helloService.Print();
serviceConsumer.Print();