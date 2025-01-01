// var helloService = new HelloService();
// var serviceConsumer = new ServiceConsumer(helloService);

// var helloService = (HelloService) Activator.CreateInstance(typeof(HelloService));
// var serviceConsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), helloService);

var dependencyContainer = new DependencyContainer();
dependencyContainer.AddDependency(typeof(HelloService));
dependencyContainer.AddDependency<ServiceConsumer>();

var dependencyResolver = new DependencyResolver(dependencyContainer);

var helloService = dependencyResolver.GetService<HelloService>();

helloService.Print();
//serviceConsumer.Print();