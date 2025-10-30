/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using System;
using System.Collections.Generic;

namespace FW4di.Dotnet.Core.Mapping;

public class MappingList
{
    public List<Tuple<Type, Type>> Mappings { get; } = new List<Tuple<Type, Type>>();

    public void AddMapping<TSource, TDestination>()
    {
        Mappings.Add(Tuple.Create(typeof(TSource), typeof(TDestination)));
    }
}
