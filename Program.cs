var helloService = new HelloService();
var serviceConsumer = new ServiceConsumer(helloService);
helloService.Print();
serviceConsumer.Print();