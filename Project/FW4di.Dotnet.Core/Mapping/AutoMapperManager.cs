/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using AutoMapper;
using Microsoft.Extensions.Logging;

namespace FW4di.Dotnet.Core.Mapping;

public class AutoMapperManager
{
    public IMapper Mapper { get; }

    Microsoft.Extensions.Logging.ILoggerFactory CreateSimpleLoggerFactory
    {
        get
        {
            return LoggerFactory.Create(builder =>
            {

            });
        }
    }

    public AutoMapperManager(MappingList mappingList)
    {
        if (mappingList != null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(mappingList));
            },
            CreateSimpleLoggerFactory);

            Mapper = config.CreateMapper();
        }
    }

    public TDestination Map<TSource, TDestination>(TSource source) => Mapper.Map<TSource, TDestination>(source);

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => Mapper.Map(source, destination);

    public object Map(object source, Type sourceType, Type destinationType) => Mapper.Map(source, sourceType, destinationType);

    public object Map(object source, object destination, Type sourceType, Type destinationType) => Mapper.Map(source, destination, sourceType, destinationType);
}
