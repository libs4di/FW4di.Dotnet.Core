/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

public interface IService2
{
    int RefCounter2 { get; }
    void CreateService1();
}
