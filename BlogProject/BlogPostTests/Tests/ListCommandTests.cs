using BlogProject;

namespace BlogPostTests;

public class ListCommandTests
{

    [Fact]
    public void HappyPath()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        ListCommand list = new ListCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle" } };

        // Act
        list.DisplayLogic();

        // Assert
        Assert.Equal("1 -- stubTitle\n", mockConsole.GetOutput());
        Assert.Single(mockService._list);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void EmptyList()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        ListCommand list = new ListCommand(mockService, mockConsole);

        // Act
        list.DisplayLogic();

        // Assert
        Assert.Empty(mockService._list);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void MultiplePosts()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        ListCommand list = new ListCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" }, 
                                              new Post { Title = "stubTitle2" },
                                              new Post { Title = "stubTitle3" },
                                              new Post { Title = "stubTitle4" },
                                              new Post { Title = "stubTitle5" } };

        // Act
        list.DisplayLogic();

        // Assert
        Assert.Equal("1 -- stubTitle1\n", mockConsole.GetOutput());
        Assert.Equal("2 -- stubTitle2\n", mockConsole.GetOutput());
        Assert.Equal("3 -- stubTitle3\n", mockConsole.GetOutput());
        Assert.Equal("4 -- stubTitle4\n", mockConsole.GetOutput());
        Assert.Equal("5 -- stubTitle5\n", mockConsole.GetOutput());
        Assert.Equal(5, mockService._list.Count);
        Assert.Empty(mockConsole.outputQueue);
    }

}