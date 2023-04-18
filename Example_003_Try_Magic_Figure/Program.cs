Console.Clear();

// Console.SetCursorPosition(1, 3);
// Console.WriteLine("+");

int x1 = 1, y1 = 1,
    x2 = 1, y2 = 20,
    x3 = 20, y3 = 20,
    x4 = 20, y4 = 1;

Console.SetCursorPosition(x1, y1);
Console.WriteLine("+");

Console.SetCursorPosition(x2, y2);
Console.WriteLine("+");

Console.SetCursorPosition(x3, y3);
Console.WriteLine("+");

Console.SetCursorPosition(x4, y4);
Console.WriteLine("+");

int x = x1, y = y1, count = 0;

while (count < 10000)
{
    int what = new Random().Next(0, 4);

    if (what == 0)
    {
        x = (x + x1) / 2;
        y = (y + y1) / 2;
    }
    if (what == 1)
    {
        x = (x + x2) / 2;
        y = (y + y2) / 2;
    }
    if (what == 2)
    {
        x = (x + x3) / 2;
        y = (y + y3) / 2;
    }
    if (what == 3)
    {
        x = (x + x4) / 2;
        y = (y + y4) / 2;
    }
    Console.SetCursorPosition(x, y);
    Console.WriteLine("+");
    count++;
}