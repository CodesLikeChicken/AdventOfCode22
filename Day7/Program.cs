using AdventOfCode;

var day = 7;

Console.WriteLine($"Hello, Day {day}");

// Do part 1 here;
var inputLines = InputParser.ParseLines("./Inputs/Input.txt").ToList();

var rootFileSystem = new FileSystem("/", null);
var currentFileSytem = rootFileSystem;

for (int i = 0; i < inputLines.Count();)
{
    string currentLine;
    List<string> tokens = null;

    var nextLine = () =>
    {
        currentLine = inputLines[i];
        tokens = currentLine.Split(' ').ToList();
        ++i;
    };

    nextLine();

    if (tokens == null)
        break;

    switch(tokens[1])
    {
        case "cd":
            // Navigate to a directory;
            switch(tokens[2])
            {
                case "/":
                    currentFileSytem = rootFileSystem;
                    break;
                case "..":
                    currentFileSytem = currentFileSytem.Parent;
                    break;
                default:
                    currentFileSytem = currentFileSytem.Find(tokens[2]);
                    break;
            }
            break;
        case "ls":
            // Don't need to infer anything.
            break;
        default:
            var newFile = new FileSystem(tokens[1], currentFileSytem);
            currentFileSytem.AddFileSystem(newFile);

            // this is a listing of a file system
            switch (tokens[0])
            {
                case "dir":
                    // Do nothing more for a directory
                    break;
                default:
                    newFile.Size = int.Parse(tokens[0]);
                    break;
            }
            break;
    }
}

var totalSize = 0;

rootFileSystem.Search((file) =>
{
    if (file.IsDirectory() && file.Size <= 100000)
    {
        totalSize += file.Size;
    }
});

Console.WriteLine($"Part 1 answer = {totalSize}");

// Do part 2 here:

var totalSpace = 70000000;
var spaceNeeded = 30000000 - (totalSpace - rootFileSystem.Size);
var smallestValid = rootFileSystem;

rootFileSystem.Search((file) =>
{
    if (file.IsDirectory() && file.Size >= spaceNeeded && file.Size < smallestValid.Size)
    {
        smallestValid = file;
    }
});

Console.WriteLine($"Part 2 answer = {smallestValid.Size}");

class FileSystem
{
    public string Name;
    public FileSystem Parent;

    protected List<FileSystem> Files = new List<FileSystem>();

    protected int size = 0;
    public int Size
    {
        set => size = value;
        get
        {
            if(Files.Any())
            {
                size = 0;
                foreach(var file in Files)
                {
                    size += file.Size;
                }
            }

            return size;
        }
    }

    public FileSystem(string name, FileSystem parent)
    {
        Name = name;
        Parent = parent;
    }

    public void AddFileSystem(FileSystem child)
    {
        Files.Add(child);
    }

    public FileSystem Find(string name)
    {
        return Files.First(fileSystem => fileSystem.Name == name);
    }

    public bool IsDirectory()
    {
        return Files.Any();
    }

    public void Search(Action<FileSystem> FileAaction)
    {
        FileAaction(this);

        foreach (var file in Files)
        {
            if(file.IsDirectory())
            {
                file.Search(FileAaction);
            }
            else
            {
                FileAaction(file);
            }
        }
    }
}