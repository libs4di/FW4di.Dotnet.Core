/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using FW4di.Dotnet.Core.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Mocker = Moq.Mock;

namespace FW4di.Dotnet.Core.Tests.Mocking;

/// <summary>
/// Mocking will only be used in a test environment, so for testing purposes,
/// as a warm-up, I will pre-test it, which also demonstrates its functionality.
/// </summary>
[TestClass]
public class MockTests
{
    [TestMethod]
    public void GenerateObject()
    {
        // Normally, this should not even compile, but Moq generates an object from an interface.
        var mockObj1 = MockHelper.Generate<IMockTestInterface>();
        mockObj1.Description = "Description";
        mockObj1.PosX = 23;

        // An object with default values is created, and its properties cannot be modified afterward.
        Assert.IsTrue(mockObj1.Description == null && mockObj1.PosX == 0, "MockTests.GenerateObject - The mock object's values could be modified afterward.");

        // Another object from an interface.
        var mockObj2 = MockHelper.Generate<IMockTestInterface>();
        Mocker.Get(mockObj2).Setup(obj => obj.Description).Returns("Description");
        Mocker.Get(mockObj2).Setup(obj => obj.PosX).Returns(23);

        // With setup, the properties of the generated object can be modified.
        Assert.IsTrue(mockObj2.Description == "Description" && mockObj2.PosX == 23, "MockTests.GenerateObject - The mock object's values could not be set up.");

        // It can be re-setup later.
        Mocker.Get(mockObj2).Setup(obj => obj.PosX).Returns(24);
        Assert.IsTrue(mockObj2.PosX == 24, "MockTests.GenerateObject - The mock object's values could not be set up again.");
    }

    [TestMethod]
    public void GenerateBehavior()
    {
        var mockObj = MockHelper.Generate<IMockTestInterface>(MockBehavior.Default);
        Mocker.Get(mockObj).Setup(obj => obj.StringToInt(It.IsAny<string>()))
            .Callback<string>((str) => { })
            .Returns(20);
        Assert.IsTrue(mockObj.StringToInt("fgdfgfdg") == 20, "MockTests.GenerateBehavior - The method's behavior could not be set up.");
    }
}
