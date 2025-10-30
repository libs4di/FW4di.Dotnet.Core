/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

namespace FW4di.Dotnet.Core.Tests.Mocking;

public interface IMockTestInterface
{
    string Description { get; set; }
    int AuthorId { get; set; }

    int PosX { get; set; }
    int PosY { get; set; }

    int StringToInt(string str);
}
