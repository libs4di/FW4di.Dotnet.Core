/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.DependencyInjection;

public enum DILifetimeScopes
{
    /// <summary> always create new object </summary>
    Transient,

    /// <summary> only one object </summary>
    Singleton,

    /// <summary> one object per thread </summary>
    Thread,
}
