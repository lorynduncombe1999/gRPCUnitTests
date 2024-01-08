using gRPC.Models;

namespace gRPCUnitTests.DataUnitTests;

public static class MockData
{
    public static List<ToDoItem> GetMockToDoItemData()
    {
        ToDoItem toDoItem1 = new ToDoItem()
        {
            Title = "To do item 1",
            Id = 1,
            Description = "This is the first to do item",
            ToDoStatus = "This item is complete"
        };

        ToDoItem toDoItem2 = new ToDoItem()
        {
            Title = "To do item 2",
            Id = 2,
            Description = "This is the second to do item",
            ToDoStatus = "This item is incomplete"
        };
        
        ToDoItem toDoItem3 = new ToDoItem()
        {
            Title = "To do item 2",
            Id = 3,
            Description = "This is the third to do item",
            ToDoStatus = "This item is incomplete"
        };
        ToDoItem toDoItem4 = new ToDoItem()
        {
            Title = "To do item 2",
            Id = 4,
            Description = "This is the second to do item",
            ToDoStatus = "This item is incomplete"
        };
        List<ToDoItem> mockToDoItemData = new List<ToDoItem>
        {
            toDoItem1,
            toDoItem2,
            toDoItem3,
            toDoItem4
        };

        return mockToDoItemData;
    }
}