using gRPC;
using Grpc.Core;
using Grpc.Core.Testing;
using gRPC.Data;
using gRPC.Models;
using gRPC.Services;
using gRPCUnitTests.DataUnitTests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace gRPCUnitTests.ServiceUnitTests;

public class ToDoServiceUnitTest
{
    public ToDoServiceUnitTest()
    {
        
    }

    [Fact]
    public async Task CreateToDoReturnsResult()
    {
        //Arrange
        Mock<AppDbContext> dbContextMock = new Mock<AppDbContext>();
       
        dbContextMock.Setup<DbSet<ToDoItem>>(db => db.ToDoItems)
            .ReturnsDbSet(DataUnitTests.MockData.GetMockToDoItemData());
       
        ToDoService service = new ToDoService(dbContextMock.Object);
        CreateToDoRequest request = new CreateToDoRequest()
        {
            Title = "Test",
            Description = "This is a test request",

        };
        
     
        //Act 
        var response = await service.CreateToDo(request,
            TestServerCallContext.Create(null, null, default, null, default, null, null, null, null, null, null));
        //Assert
        Assert.NotNull(response);
        
        Assert.Equal(0,response.Id);
       
        //How to test whats actually in the response (Its a sealed class) 
      
    }

    [Fact]
    public async Task GetAllTodoItemsReturnList()
    {
       //Arrange
       Mock<AppDbContext> dbContextMock = new Mock<AppDbContext>();
       
       dbContextMock.Setup<DbSet<ToDoItem>>(db => db.ToDoItems)
           .ReturnsDbSet(DataUnitTests.MockData.GetMockToDoItemData());
       
       ToDoService service = new ToDoService(dbContextMock.Object);
     
     
       //Act 
       var response = await service.ListToDo(new GetAllRequest(),TestServerCallContext.Create(null, null, default, null, default, null, null, null, null, null, null));

       //Assert
       Assert.NotNull(response);
       
       //How to test whats actually in the response (Its a sealed class) 
      //n Assert.Equal(,respone);
    }
    
    
    [Fact]
    public async Task ReadToDoReturnsResult()
    {
        //Arrange
        Mock<AppDbContext> dbContextMock = new Mock<AppDbContext>();
       
        dbContextMock.Setup<DbSet<ToDoItem>>(db => db.ToDoItems)
            .ReturnsDbSet(DataUnitTests.MockData.GetMockToDoItemData());
       
        ToDoService service = new ToDoService(dbContextMock.Object);
        ReadToDoRequest request = new ReadToDoRequest();
        request.Id = 2;
     
        //Act 
        var response = await service.ReadToDo(request,
            TestServerCallContext.Create(null, null, default, null, default, null, null, null, null, null, null));
        //Assert
        Assert.NotNull(response);
        Assert.Equal(2,response.Id);
       
        //because response is a sealed class it is difficult to test the specific content of the response
      
    }

/*
    [Fact]
    public async Task UpdateToDoResultTest()
    {
        //Arrange 
        Mock<AppDbContext> dbContextMock = new Mock<AppDbContext>();
        
        dbContextMock.Setup<DbSet<ToDoItem>>(db => db.ToDoItems)
            .ReturnsDbSet(DataUnitTests.MockData.GetMockToDoItemData());

        var item3 = MockData.GetMockToDoItemData().FirstOrDefault(x => x.Id == 3);
        
        
        
        ToDoService service = new ToDoService(dbContextMock.Object);
        UpdateToDoRequest request = new UpdateToDoRequest();
        
        
        
        //Act 
        //Assert 
    }
    */

/*
    [Fact]
    public async Task DeleteResultTest()
    {
        
    }

   */
}