/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using AutoMapper;

namespace FW4di.Dotnet.Core.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile(MappingList mapper)
    {
        mapper.Mappings.ForEach(mapPair => CreateMap(mapPair.Item1, mapPair.Item2));
    }
}
