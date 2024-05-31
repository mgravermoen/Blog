using BlogProject;

namespace BlogPostTests;

public class ReadCommandTests
{

    [Fact]
    public void HappyPath()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        ReadCommand read = new ReadCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , Body = "stubBody1", Author = "stubAuthor1", Created = DateTime.Parse("5/8/2024 9:34:42 PM"), KeyID = 1},
                                              new Post { Title = "stubTitle2" , Body = "stubBody2", Author = "stubAuthor2", Created = DateTime.Parse("5/8/2024 9:34:43 PM"), KeyID = 2},
                                              new Post { Title = "stubTitle3" , Body = "stubBody3", Author = "stubAuthor3", Created = DateTime.Parse("5/8/2024 9:34:44 PM"), KeyID = 3},
                                              new Post { Title = "stubTitle4" , Body = "stubBody4", Author = "stubAuthor4", Created = DateTime.Parse("5/8/2024 9:34:45 PM"), KeyID = 4},
                                              new Post { Title = "stubTitle5" , Body = "stubBody5", Author = "stubAuthor5", Created = DateTime.Parse("5/8/2024 9:34:46 PM"), KeyID = 5} };
        mockConsole.AddToReadLineQueue("1");

        // Act
        read.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to read: ", mockConsole.GetOutput());
        Assert.Equal("\nstubTitle1\n\nstubAuthor1", mockConsole.GetOutput());
        Assert.Equal("5/8/2024 9:34:42 PM\n\n\nstubBody1", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

}