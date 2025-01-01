var service = new HelloService();
var consumer = new ServiceConsumer(service);
service.Print();
consumer.Print();