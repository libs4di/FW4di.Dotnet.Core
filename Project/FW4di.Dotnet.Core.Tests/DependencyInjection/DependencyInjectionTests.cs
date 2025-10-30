/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using FW4di.Dotnet.Core.DependencyInjection;

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

/// <summary>
/// It is not customary to test third-party dependencies – we 'blindly' trust all external dependencies :)
/// but in this case, the custom implementation that was added is being tested in this environment, and its usage is also visible from this.
/// </summary>
[TestClass]
public class DependencyInjectionTests
{
    IDIManager CreateDIEnvironment()
    {
        Service1.Init();
        Service2.Init();

        return new DIManager();
    }

    [TestMethod]
    public void InstanceLifecycle()
    {
        IDIManager di = CreateDIEnvironment();
        di.Init
        (
            () =>
            {
                di.Bind<IService1, Service1>(DILifetimeScopes.Singleton);
                di.Bind<IService2, Service2>(DILifetimeScopes.Transient);
            }
        );

        di.GetDependency<IService1>();
        var ser11 = di.GetDependency<IService1>(); // same object
        di.GetDependency<IService2>();
        var ser22 = di.GetDependency<IService2>(); // new Service2

        Assert.IsTrue(ser11.RefCounter1 == 1, "DependencyInjectionTests.InstanceLifecycle - Service1 is a singleton, only one instance should exist");
        Assert.IsTrue(ser22.RefCounter2 == 2, "DependencyInjectionTests.InstanceLifecycle - Service2 was created twice");
    }

    [TestMethod]
    public void InstanceInject()
    {
        string injectedName = "Prototype object";

        IDIManager di = CreateDIEnvironment();
        di.Init
        (
            () =>
            {
                di.Bind<IService1, Service1>(DILifetimeScopes.Transient);
                di.Bind<IService2, Service2>(DILifetimeScopes.Singleton);
                di.Bind<Injected, Injected>(DILifetimeScopes.Transient, new Injected() { Name = injectedName });
            }
        );

        di.GetDependency<IService1>(); // new Service1
        var ser2 = di.GetDependency<IService2>(); // new Service2 singleton
        var ser11 = di.GetDependency<IService1>(); // new instance of Service1

        Assert.IsTrue(ser11.RefCounter1 == 2, "DependencyInjectionTests.InstanceInject - Two instances of Service1 should be created");
        Assert.IsTrue(ser2.RefCounter2 == 1, "DependencyInjectionTests.InstanceInject - Service2 is a singleton, only one instance should exist");

        var injected1 = di.GetDependency<Injected>();
        var injected2 = di.GetDependency<Injected>();
        Assert.IsFalse(injected1.Equals(injected2), "DependencyInjectionTests.InstanceInject - Creating two transient Injected objects failed");
        Assert.IsFalse(ReferenceEquals(injected1, injected2), "DependencyInjectionTests.InstanceInject - Injected type is not following a transient lifecycle");

        IDIManager di2 = CreateDIEnvironment();
        di2.Init
        (
            () =>
            {
                di2.Bind<Injected, Injected>(DILifetimeScopes.Singleton, new Injected() { Name = injectedName });
            }
        );

        var injected11 = di2.GetDependency<Injected>();
        var injected22 = di2.GetDependency<Injected>();
        Assert.IsTrue(injected11.Equals(injected22), "DependencyInjectionTests.InstanceInject - Injected instances should be singleton");
        Assert.IsTrue(ReferenceEquals(injected11, injected22), "DependencyInjectionTests.InstanceInject - Injected type is not following a singleton lifecycle");
    }
}
