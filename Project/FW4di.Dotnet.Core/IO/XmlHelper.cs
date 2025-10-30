/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using System.Xml;
using System.Xml.Serialization;

namespace FW4di.Dotnet.Core.IO;

/// <summary> The `XmlHelper` class provides simple methods for XML serialization and deserialization of .NET objects. </summary>
public static class XmlHelper
{
    public static string Serialize<T>(T? obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var serializer = new XmlSerializer(typeof(T));
        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(xmlWriter, obj);
                return stringWriter.ToString();
            }
        }
    }

    public static T Deserialize<T>(string? xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentNullException(nameof(xml));

        var serializer = new XmlSerializer(typeof(T));
        using (var stringReader = new StringReader(xml))
        {
            var result = serializer.Deserialize(stringReader);
            if (result is null)
                throw new InvalidOperationException("Deserialization returned null.");

            return (T)result;
        }
    }

    public static void SerializeToFile<T>(T? obj, string? filePath)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        var serializer = new XmlSerializer(typeof(T));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, obj);
        }
    }

    public static T DeserializeFromFile<T>(string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StreamReader(filePath))
        {
            var result = serializer.Deserialize(reader);
            if (result is null)
                throw new InvalidOperationException("Deserialization from file returned null.");

            return (T)result;
        }
    }
}
