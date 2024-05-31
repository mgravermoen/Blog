# 5/31

Swap author field with already registered username

Allow ' in posts in app

Fix special characters, like , and \n, in console

Don't allow ... to interupt words

Make functionality invisible with different user roles instead of only showing the access denied page

Fix multiple a tags on different pages appearing clicked

Look into issue with claims and updating the username

add functionality so admins can do anything

# 5/30

Append salt to the end of the password instead of the beginning

Change password method names to hash

Swap author field with already registered username

Allow ' in posts in app

Allow , in posts in console

Don't allow words to chop off in app on home page

# 5/29

Continue working on cookie authentication.

# 5/28

Fully finish implementation of Blazor.

Complete wrappers for console app.

Review all code for presentation.

Create a user login page with cookie authentication. Hash the passwords into postgres with unique salt for each user.
Salt can be stored in the user table - they're not considered sensitive information.

# 5/23

Complete postgres implementation.

Re-work css.

# 5/22

Make text into a dark gray with varying sizes. 

Look into flex box

Design a database for my blog

How to get C# talk to postgreSQL server

Make a database repo and implement talking to my database

# 5/21
Continue working on finalizing CSS

Full size button with "New Post +".

Full size button with "Cancel X" at bottom left of page.

Ensure good contrast (try to pass AAA too)

Change font for readability

Add toast message



Escape quotation marks

# 5/15
Add support for commas and newlines in repo

# 5/13
1) Home page will open to the current list of post with all read data, with most recent loading first. Cap this at 20
2) New page for creating new posts
3) Create box that appears on hover over the specified post with edit and delete options. (Meatball and drop down)
4) Add functionality to delete button.
5) Add functionality to edit button.
6) Clicking post brings you to read post functionality within a new page.
7) Make everything pretty.

# 5/10
Continue working on Blazor

# 5/8
Finish implementing xunit tests.

# 5/6
Bring over all instances of Console into IConsole (specifically, have color as second parameter when writing)

Finish implementing xunit tests.

# 5/3
Save and load all posts to and from a CSV file

Add path name as a parameter from Program.cs. Perhaps looking into config files.

Create wrapper class for utilities such as writing out strings in color. Pass this in as another parameter for commands. Name it ConsoleWrapper

Create new getTitle command within ICommand

Create new getCommand within ICommand, then, new up all commands within options array.

Move listNeeded logic over to List command.

```cs
if (selection is QuitCommand) {}
```

Bring all UserInput into new ConsoleWrapper class to automatically support returning to main menu

xunit

# 5/1

Begin implementing ID system for dictionary

After erros are removed, look into throwing exceptions for invalid user input.

Multiple titles are now allowed.

List appears in all commands (except for write) ordered from newest to oldest with a numbering system that the user can use for selection.

Cleaned logic in Write Command

Created loops with commands for invalid inputs instead of returning to the main menu

TODO
Allow for exit within sub menus
Make "your post was deleted" red
GetUserSelection should return an object
Implement boolean method in commands
Look into $ formatting


# 4/29

Clean up logic for Reading a post stroy.

Implement methods in InMemoryPostRepo.

Implement list all titles story.

TODO
{
All methods must be 20 lines or less
Bring repeating logic over into Program.cs
Improve user experience 
Have a date created and an author field for each post and print the date whenever the post is listed
    Title
    newline
    Author
    Date (right alligned)
Allow multiple of the same titles
    Add an ID to store posts (incrememnting int)
List should go from:
    newest
    oldest

Save and load all posts to and from a CSV file
}

Finish implementing edit story

Convert all methods to be 20 lines of code or less

# 4/26

Write code to work with an in-memory database, but also to work with an SQL database later.

Controllers (Console App Commands) -> Service Layer (Business logic) -> Repository Layer -> Data Access Layer

Console App Command: GETPOST 1
Console Command -> IPostService (Business Logic)

CreatePost (Post object of some kind)
ReadPost (id)
ListPosts ()
UpdatePost (Post object, id)
DeletePost (id)

UserRepository
    GetUserFromPost (postId)

Example: `GETPOST 1` calls `ReadPost(1)`

IPostRepoisitory (Logic for storage)
    CreatePost (Post object of some kind)
    ReadPost (id)
    UpdatePost (Post object, id)
    DeletePost (id)


As a user, I want to be able to read a post in the blog app.
As a user, I want to be able to write a post in the blog app.
As a user, I want to be able to edit a post in the blog app.
As a user, I want to be able to get a list of all post titles in the blog app.
As a user, I want to be able to delete a post in the blog app.



Posts Folder
    - PostCommand (Display logic)
    - PostService (Business logic)
    - InMemoryPostRepo (Storage logic)

Services Folder
    - PostService
Repositories Folder
    - InMemoryPostRepo
Commands Folder
    - PostCommand


PostCommand(PostService service)

PostService(IPostRepo repo)

new PostServie in Program.cs