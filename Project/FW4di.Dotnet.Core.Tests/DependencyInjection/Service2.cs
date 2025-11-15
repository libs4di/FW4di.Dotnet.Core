/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using FW4di.Dotnet.Core.DependencyInjection;

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

public class Service2 : IService2
{
    static int refCount;
    public int RefCounter2 => refCount;

    IDIManager di;

    public Service2(IDIManager di)
    {
        this.di = di;
        refCount++;
    }

    public void CreateService1()
    {
        var ser1 = di.GetDependency<IService1>();
    }

    public static void Init()
    {
        refCount = 0;
    }
}
