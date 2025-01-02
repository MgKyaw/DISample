// var helloService = new HelloService();
// var serviceConsumer = new ServiceConsumer(helloService);

// var helloService = (HelloService) Activator.CreateInstance(typeof(HelloService));
// var serviceConsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), helloService);

var dependencyContainer = new DependencyContainer();
dependencyContainer.AddDependency(typeof(HelloService));
dependencyContainer.AddDependency<ServiceConsumer>();
dependencyContainer.AddDependency<MessageService>();

var dependencyResolver = new DependencyResolver(dependencyContainer);

var service = dependencyResolver.GetService<ServiceConsumer>();

service.Print();
//serviceConsumer.Print();