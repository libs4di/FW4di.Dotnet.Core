/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

public class Service2 : IService2
{
    static int refCount;
    public int RefCounter2 => refCount;

    public Service2()
    {
        refCount++;
    }

    public static void Init()
    {
        refCount = 0;
    }
}
