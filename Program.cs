// var helloService = new HelloService();
// var serviceConsumer = new ServiceConsumer(helloService);

// var helloService = (HelloService) Activator.CreateInstance(typeof(HelloService));
// var serviceConsumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), helloService);

var dependencyContainer = new DependencyContainer();
dependencyContainer.AddTransient<ServiceConsumer>();
dependencyContainer.AddTransient<HelloService>();
dependencyContainer.AddSingleton<MessageService>();

var dependencyResolver = new DependencyResolver(dependencyContainer);

var service1 = dependencyResolver.GetService<ServiceConsumer>();

service1.Print();

var service2 = dependencyResolver.GetService<ServiceConsumer>();

service2.Print();

var service3 = dependencyResolver.GetService<ServiceConsumer>();

service3.Print();
//serviceConsumer.Print();