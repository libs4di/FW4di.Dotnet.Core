/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using Moq;

namespace FW4di.Dotnet.Core.Mocking;

public static class MockHelper
{
    public static T Generate<T>() where T : class
    {
        return new Mock<T>().Object;
    }

    public static T Generate<T>(MockBehavior behavior) where T : class
    {
        var mockRepo = new MockRepository(behavior)
        {
            DefaultValue = DefaultValue.Mock
        };

        return mockRepo.Create<T>().Object;
    }
}
