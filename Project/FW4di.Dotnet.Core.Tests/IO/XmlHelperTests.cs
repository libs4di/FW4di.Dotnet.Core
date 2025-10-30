/*
4di Framework .NET Core Library
Copyright (c) 2025 by 4D Illusions. All rights reserved.
Released under the terms of the GNU General Public License version 3 or later.
*/

using FW4di.Dotnet.Core.IO;

namespace FW4di.Dotnet.Core.Tests.IO;

[TestClass]
public class XmlHelperTests
{
    public class TestClass
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    private readonly TestClass testObject = new TestClass { Name = "John", Age = 30 };
    private readonly string expectedXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<TestClass>\r\n  <Name>John</Name>\r\n  <Age>30</Age>\r\n</TestClass>";

    [TestMethod]
    public void Serialize_ShouldReturnValidXml()
    {
        string xml = XmlHelper.Serialize(testObject);
        Assert.IsTrue(xml.Contains("</TestClass>"));
        Assert.IsTrue(xml.Contains("<Name>John</Name>"));
        Assert.IsTrue(xml.Contains("<Age>30</Age>"));
    }

    [TestMethod]
    public void Deserialize_ShouldReturnValidObject()
    {
        var obj = XmlHelper.Deserialize<TestClass>(expectedXml);
        Assert.IsNotNull(obj);
        Assert.AreEqual("John", obj.Name);
        Assert.AreEqual(30, obj.Age);
    }

    [TestMethod]
    public void SerializeToFile_And_DeserializeFromFile_ShouldWork()
    {
        string filePath = "test.xml";

        try
        {
            XmlHelper.SerializeToFile(testObject, filePath);
            var deserializedObject = XmlHelper.DeserializeFromFile<TestClass>(filePath);

            Assert.IsNotNull(deserializedObject);
            Assert.AreEqual("John", deserializedObject.Name);
            Assert.AreEqual(30, deserializedObject.Age);
        }
        finally
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Serialize_NullObject_ShouldThrowException()
    {
        XmlHelper.Serialize<TestClass>(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Deserialize_NullString_ShouldThrowException()
    {
        XmlHelper.Deserialize<TestClass>(null);
    }
}
