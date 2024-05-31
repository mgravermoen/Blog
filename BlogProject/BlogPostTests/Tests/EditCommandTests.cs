using BlogProject;

namespace BlogPostTests;

public class EditCommandTests
{

    [Fact]
    public void EditTitle()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , KeyID = 1},
                                              new Post { Title = "stubTitle2" , KeyID = 2},
                                              new Post { Title = "stubTitle3" , KeyID = 3},
                                              new Post { Title = "stubTitle4" , KeyID = 4},
                                              new Post { Title = "stubTitle5" , KeyID = 5} };
        mockConsole.AddToReadLineQueue("3");
        mockConsole.AddToReadLineQueue("t");
        mockConsole.AddToReadLineQueue("NEW stubTitle3");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter your new title: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"NEW stubTitle3\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubTitle3", mockService._list[2].Title);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void EditBody()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , Body = "stubBody1", KeyID = 1},
                                              new Post { Title = "stubTitle2" , Body = "stubBody2", KeyID = 2},
                                              new Post { Title = "stubTitle3" , Body = "stubBody3", KeyID = 3},
                                              new Post { Title = "stubTitle4" , Body = "stubBody4", KeyID = 4},
                                              new Post { Title = "stubTitle5" , Body = "stubBody5", KeyID = 5} };
        mockConsole.AddToReadLineQueue("1");
        mockConsole.AddToReadLineQueue("b");
        mockConsole.AddToReadLineQueue("NEW stubBody1");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your edited post. Newlines may be denoted with \"!!\": ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle1\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubBody1", mockService._list[0].Body);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void EditAuthor()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , Author = "stubAuthor1", KeyID = 1},
                                              new Post { Title = "stubTitle2" , Author = "stubAuthor2", KeyID = 2},
                                              new Post { Title = "stubTitle3" , Author = "stubAuthor3", KeyID = 3},
                                              new Post { Title = "stubTitle4" , Author = "stubAuthor4", KeyID = 4},
                                              new Post { Title = "stubTitle5" , Author = "stubAuthor5", KeyID = 5} };
        mockConsole.AddToReadLineQueue("5");
        mockConsole.AddToReadLineQueue("a");
        mockConsole.AddToReadLineQueue("NEW stubAuthor5");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter your new author: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle5\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubAuthor5", mockService._list[4].Author);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void InvalidPostSelection()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , KeyID = 1},
                                              new Post { Title = "stubTitle2" , KeyID = 2},
                                              new Post { Title = "stubTitle3" , KeyID = 3},
                                              new Post { Title = "stubTitle4" , KeyID = 4},
                                              new Post { Title = "stubTitle5" , KeyID = 5} };
        mockConsole.AddToReadLineQueue("6");
        mockConsole.AddToReadLineQueue("z");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue("3");
        mockConsole.AddToReadLineQueue("t");
        mockConsole.AddToReadLineQueue("NEW stubTitle3");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        for (int i = 0; i < 1; i++) {
            Assert.Equal("ERROR -- Please select one of the listed numbers: ", mockConsole.GetOutput());
        }
        for (int i = 0; i < 4; i++) {
            Assert.Equal("ERROR -- Please enter a valid number: ", mockConsole.GetOutput());
        }
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter your new title: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"NEW stubTitle3\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubTitle3", mockService._list[2].Title);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void InvalidEditSelection()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , KeyID = 1},
                                              new Post { Title = "stubTitle2" , KeyID = 2},
                                              new Post { Title = "stubTitle3" , KeyID = 3},
                                              new Post { Title = "stubTitle4" , KeyID = 4},
                                              new Post { Title = "stubTitle5" , KeyID = 5} };
        mockConsole.AddToReadLineQueue("2");
        mockConsole.AddToReadLineQueue("z");
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("t");
        mockConsole.AddToReadLineQueue("NEW stubTitle2");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        for (int i = 0; i < 4; i++) {
            Assert.Equal("ERROR -- Please enter a valid option: ", mockConsole.GetOutput());
        }
        Assert.Equal("Please enter your new title: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"NEW stubTitle2\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubTitle2", mockService._list[1].Title);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void InvalidTitle()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , KeyID = 1},
                                              new Post { Title = "stubTitle2" , KeyID = 2},
                                              new Post { Title = "stubTitle3" , KeyID = 3},
                                              new Post { Title = "stubTitle4" , KeyID = 4},
                                              new Post { Title = "stubTitle5" , KeyID = 5} };
        mockConsole.AddToReadLineQueue("2");
        mockConsole.AddToReadLineQueue("z");
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("t");
        mockConsole.AddToReadLineQueue("NEW stubTitle2");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        for (int i = 0; i < 4; i++) {
            Assert.Equal("ERROR -- Please enter a valid option: ", mockConsole.GetOutput());
        }
        Assert.Equal("Please enter your new title: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"NEW stubTitle2\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubTitle2", mockService._list[1].Title);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Fact]
    public void InvalidBody()
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , Body = "stubBody1", KeyID = 1},
                                              new Post { Title = "stubTitle2" , Body = "stubBody2", KeyID = 2},
                                              new Post { Title = "stubTitle3" , Body = "stubBody3", KeyID = 3},
                                              new Post { Title = "stubTitle4" , Body = "stubBody4", KeyID = 4},
                                              new Post { Title = "stubTitle5" , Body = "stubBody5", KeyID = 5} };
        mockConsole.AddToReadLineQueue("4");
        mockConsole.AddToReadLineQueue("b");
        mockConsole.AddToReadLineQueue("");
        mockConsole.AddToReadLineQueue(" ");
        mockConsole.AddToReadLineQueue(null);
        mockConsole.AddToReadLineQueue("NEW stubBody4");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter the body of your edited post. Newlines may be denoted with \"!!\": ", mockConsole.GetOutput());
        for (int i = 0; i < 3; i++) {
            Assert.Equal("ERROR -- Please enter a valid body: ", mockConsole.GetOutput());
        }
        Assert.Equal("\nThe post titled \"stubTitle4\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubBody4", mockService._list[3].Body);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void InvalidAuthor(string input)
    {
        // Arrange
        MockPostService mockService = new MockPostService();
        MockConsole mockConsole = new MockConsole();
        EditCommand edit = new EditCommand(mockService, mockConsole);
        mockService._list = new List<Post>(){ new Post { Title = "stubTitle1" , Author = "stubAuthor1", KeyID = 1},
                                              new Post { Title = "stubTitle2" , Author = "stubAuthor2", KeyID = 2},
                                              new Post { Title = "stubTitle3" , Author = "stubAuthor3", KeyID = 3},
                                              new Post { Title = "stubTitle4" , Author = "stubAuthor4", KeyID = 4},
                                              new Post { Title = "stubTitle5" , Author = "stubAuthor5", KeyID = 5} };
        mockConsole.AddToReadLineQueue("1");
        mockConsole.AddToReadLineQueue("a");
        mockConsole.AddToReadLineQueue(input);
        mockConsole.AddToReadLineQueue("NEW stubAuthor1");

        // Act
        edit.DisplayLogic();

        // Assert
        Assert.Equal("Please select the number of the post you'd like to edit: ", mockConsole.GetOutput());
        Assert.Equal("Which would you like to edit - the title or the body?\nSelect \"t\" for title, \"b\" for body, or \"a\" for author: ", mockConsole.GetOutput());
        Assert.Equal("Please enter your new author: ", mockConsole.GetOutput());
        Assert.Equal("ERROR -- Please enter a valid author: ", mockConsole.GetOutput());
        Assert.Equal("\nThe post titled \"stubTitle1\" was edited.", mockConsole.GetOutput());
        Assert.Equal("NEW stubAuthor1", mockService._list[0].Author);
        Assert.Empty(mockConsole.readQueue);
        Assert.Empty(mockConsole.outputQueue);
    }
}