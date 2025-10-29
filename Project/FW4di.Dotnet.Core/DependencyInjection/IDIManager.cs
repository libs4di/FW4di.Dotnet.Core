/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.DependencyInjection;

public interface IDIManager
{
    void Init(Action bindings);
    void Bind<TInterface, TImplementation>(DILifetimeScopes scope) where TImplementation : TInterface;
    void Bind<TInterface, TImplementation>(DILifetimeScopes scope, TImplementation instance) where TImplementation : TInterface, ICloneable;
    T GetDependency<T>();
}
