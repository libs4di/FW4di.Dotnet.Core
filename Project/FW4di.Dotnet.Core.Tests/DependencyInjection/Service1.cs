/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

public class Service1 : IService1
{
    static int refCount;
    public int RefCounter1 => refCount;

    public Service1()
    {
        refCount++;
    }

    public static void Init()
    {
        refCount = 0;
    }
}
