/*
 * Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
 * На вход метод принимает URL директории, в ответ — размер в байтах.
 */


string dirPath = @"C:\Users\мвидео\Documents\Bethesda";

DirectoryInfo dirSpace = new DirectoryInfo(dirPath);
try
{
    long size = 0;
    if (dirSpace.Exists)
    {
        long totalsize = EvaluateSpace(size, dirSpace);
        Console.WriteLine($"Папка {dirSpace} занимает {totalsize} байт.");
    }
    else
    {
        Console.WriteLine("Такой папки не существует");
    }
}
catch (Exception ex)
{
    if(ex is UnauthorizedAccessException)
    {
        Console.WriteLine("Отказ в правах доступа.");
    }
}

static long EvaluateSpace(long size, DirectoryInfo dirSpace)
{
    foreach (FileInfo file in dirSpace.GetFiles())
    {
        size += file.Length;
    }

    foreach (DirectoryInfo folder in dirSpace.GetDirectories())
    {
        size += EvaluateSpace(0, folder);
    }

    return size;

}