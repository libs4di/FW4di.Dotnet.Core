/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using System;

namespace FW4di.Dotnet.Core.Tests.DependencyInjection;

public class Injected : ICloneable
{
    public string Name { get; set; }

    public readonly Guid Id;

    public Injected()
    {
        Id = Guid.NewGuid();
    }

    public object Clone()
    {
        return new Injected() { Name = Name };
    }

    public override bool Equals(object obj)
    {
        var other = obj as Injected;
        if (other == null)
            return false;

        return Equals(other);
    }

    protected bool Equals(Injected other)
    {
        return Id.Equals(other.Id) && Name == other.Name;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Id.GetHashCode() * 397) ^ (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
