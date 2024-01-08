using gRPC.Models;

namespace gRPCUnitTests.ModelUnitTests;

public class ToDoItemTests
{
    [Fact]
    public void ToDoItemShouldReturnTrue()
    {
       
        ToDoItem toDoItem = new ToDoItem()
        {
            Id = 1,
            Title = "Test",
            Description = "This is a Test",
            ToDoStatus = "Done"
        };

        
        Assert.True(toDoItem.Id==1);
        Assert.True(toDoItem.Title.Equals("Test"));
        Assert.True(toDoItem.Description.Equals("This is a Test"));
        Assert.True(toDoItem.ToDoStatus.Equals("Done"));
    }
    [Fact]
    public void ToDoItemShouldReturnFalse()
    {
       
        ToDoItem toDoItem = new ToDoItem()
        {
            Id = 1,
            Title = "Test",
            Description = "This is a Test",
            ToDoStatus = "Done"
        };

        
        Assert.False(toDoItem.Id==2);
        Assert.False(toDoItem.Title.Equals("Test1"));
        Assert.False(toDoItem.Description.Equals("This is a Test that should return false"));
        Assert.False(toDoItem.ToDoStatus.Equals("incomplete"));
    }
}