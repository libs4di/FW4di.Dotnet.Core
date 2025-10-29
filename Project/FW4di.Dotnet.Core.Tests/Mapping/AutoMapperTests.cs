/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using FW4di.Dotnet.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW4di.Dotnet.Core.Tests.Mapping;

/// <summary>
/// It is not common to test 3rd party libraries – we "blindly" trust all external dependencies :)
/// but here, the added custom implementation is being tested in this environment, and its usage is also demonstrated.
/// </summary>
[TestClass]
public class AutoMapperTests
{
    AutoMapperManager CreateMapEnvironment()
    {
        var mappingList = new MappingList();
        mappingList.AddMapping<MapDTO2, MapDTO1>();
        mappingList.AddMapping<MapDTO2, MapDTO2>();

        return new AutoMapperManager(mappingList);
    }

    MapDTO2 CreateDTO2()
    {
        return new MapDTO2()
        {
            Id = 122,
            Name = "DTO2",
            Description = "This is DTO2",
            Author = "LoxTop Corporation",
            AuthorId = 10,
            AuthorName = "LoxTop CTO"
        };
    }

    [TestMethod]
    public void MappingSameTypes()
    {
        var map = CreateMapEnvironment();
        var DTO2 = CreateDTO2();

        var DTO22 = map.Map<MapDTO2, MapDTO2>(DTO2);
        Assert.IsTrue(DTO2.Equals(DTO22), "AutoMapperTests.MappingSameTypes - failed to map DTO2 to another new DTO2 instance");
        Assert.IsFalse(ReferenceEquals(DTO2, DTO22), "AutoMapperTests.MappingSameTypes - failed to map DTO2 to a new distinct instance");

        DTO2.Name = "DTO3";
        DTO2.Author = "Umbrella Corporation";
        var DTO33 = map.Map<MapDTO2, MapDTO2>(DTO2);
        Assert.IsTrue(DTO2.Equals(DTO33), "AutoMapperTests.MappingSameTypes - failed to map modified DTO2 to another new DTO2 instance");
        Assert.IsFalse(ReferenceEquals(DTO2, DTO33), "AutoMapperTests.MappingSameTypes - failed to map modified DTO2 to a new distinct instance");
    }

    [TestMethod]
    public void MappingDifferentTypes()
    {
        var map = CreateMapEnvironment();
        var DTO2 = CreateDTO2();

        var DTO1 = map.Map<MapDTO2, MapDTO1>(DTO2);
        Assert.IsTrue(DTO1.Description == DTO2.Description && DTO1.AuthorId == DTO2.AuthorId, "AutoMapperTests.MappingDifferentTypes - failed to map DTO2 to a new DTO1 instance");
    }
}
