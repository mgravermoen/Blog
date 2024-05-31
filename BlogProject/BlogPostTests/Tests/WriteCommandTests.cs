using BlogProject;

namespace BlogPostTests;

public class WriteCommandTests
{
    [Fact]
    public void HappyPath()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("stubBody");
        mockConsole.AddToReadLineQueue("stubAuthor");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("stubTitle", mockService._list[0].Title);
        Assert.Equal("stubBody", mockService._list[0].Body);
        Assert.Equal("stubAuthor", mockService._list[0].Author);
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Equal("\nPost created successfully", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void ReturnToMainMenuBeforeTitle()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("0");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Empty(mockService._list);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void ReturnToMainMenuBeforeBody()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("0");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Empty(mockService._list);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void ReturnToMainMenuBeforeAuthor()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("stubBody");
        mockConsole.AddToReadLineQueue("0");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Empty(mockService._list);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void EmptyInput()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue("stubBody");
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue("stubAuthor");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid title: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid body: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid author: ", mockConsole.GetOutput());
        Assert.Equal("stubTitle", mockService._list[0].Title);
        Assert.Equal("stubBody", mockService._list[0].Body);
        Assert.Equal("stubAuthor", mockService._list[0].Author);
        Assert.Equal("\nPost created successfully", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void WhiteSpaceInput()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("  ");
        mockConsole.AddToReadLineQueue("stubBody");
        mockConsole.AddToReadLineQueue("   ");
        mockConsole.AddToReadLineQueue("stubAuthor");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid title: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid body: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid author: ", mockConsole.GetOutput());
        Assert.Equal("stubTitle", mockService._list[0].Title);
        Assert.Equal("stubBody", mockService._list[0].Body);
        Assert.Equal("stubAuthor", mockService._list[0].Author);
        Assert.Equal("\nPost created successfully", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void NullInput()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("stubBody");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("stubAuthor");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid title: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid body: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid author: ", mockConsole.GetOutput());
        Assert.Equal("stubTitle", mockService._list[0].Title);
        Assert.Equal("stubBody", mockService._list[0].Body);
        Assert.Equal("stubAuthor", mockService._list[0].Author);
        Assert.Equal("\nPost created successfully", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void NewlineReplace()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        WriteCommand write = new WriteCommand(mockService, mockConsole);
        mockConsole.AddToReadLineQueue("stubTitle");
        mockConsole.AddToReadLineQueue("stubBody!!With!!Newlines!");
        mockConsole.AddToReadLineQueue("stubAuthor");
        
        // Act
        write.DisplayLogic();

        // Assert
        Assert.Equal("stubTitle", mockService._list[0].Title);
        Assert.Equal("stubBody\nWith\nNewlines!", mockService._list[0].Body);
        Assert.Equal("stubAuthor", mockService._list[0].Author);
        Assert.Equal("Please enter the title of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your post: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the author of your post: ", mockConsole.GetOutput());
        Assert.Equal("\nPost created successfully", mockConsole.GetOutput());
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }
}