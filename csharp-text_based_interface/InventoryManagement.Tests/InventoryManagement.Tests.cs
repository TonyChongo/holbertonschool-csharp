using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLibrary;

[TestClass]
public class JSONStorageTests
{
    [TestMethod]
    public void TestNewObject()
    {
        // Arrange
        JSONStorage storage = new JSONStorage();
        Item item = new Item
        {
            id = "item1",
            name = "Test Item",
            description = "Test description",
            price = 10.99f,
            tags = new List<string> { "tag1", "tag2" }
        };

        // Act
        storage.New(item);

        // Assert
        Assert.IsTrue(storage.All().ContainsKey("Item.item1"));
    }

    // More test methods for other JSONStorage functionality...
}
