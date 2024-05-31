using BlogProject;

namespace BlogPostTests;

public class DeleteCommandTests
{
    private readonly MockPostService mockService;
    private readonly MockConsole mockConsole;
    private readonly DeleteCommand delete;

    public DeleteCommandTests()
    {
        mockService = new MockPostService();
        mockConsole = new MockConsole();
        delete = new DeleteCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle", KeyID = 1 } };
    }

    [Fact]
    public void HappyPath()
    {
        // Arrange
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void OutOfRangeIndex()
    {
        // Arrange
        mockConsole.AddToReadLineQueue("2");
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please select one of the listed numbers: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void RepeatedOutOfRangeIndex()
    {
        // Arrange
        for (int i = -100; i < 100; i++) {
            if (i == 1 || i == 0) {
                continue;
            } else {
                mockConsole.AddToReadLineQueue(i.ToString());
            }
        }
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        for (int i = 0; i < 198; i++) {
            Assert.Equal("ERROR -- Please select one of the listed numbers: ", mockConsole.GetOutput());
        }
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void EmptyStringInput()
    {
        // Arrange
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid number: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void NullInput()
    {
        // Arrange
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid number: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void NonNumberInput()
    {
        // Arrange
        mockConsole.AddToReadLineQueue("Hello World");
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid number: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }

    [Fact]
    public void WhiteSpaceInput()
    {
        // Arrange
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue("1");

        // Act
        delete.DisplayLogic();

        // Assert
        Assert.Equal(1, mockService.DeleteId);
        Assert.Equal("Please select the number of the post you'd like to delete: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid number: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle\" was deleted.", mockConsole.GetOutput());
        mockConsole.AssertQueuesAreEmpty();
    }
}