using static System.Math;



void AreaSnake(int[] regionSnake) //Def Area Rectangle
{
    Console.Clear();
    for (int i = 0; i < regionSnake[0]; i++) //high level
    {
        Console.SetCursorPosition(i, 0);
        Console.WriteLine("-");
    }

    for (int i = 0; i < regionSnake[1]; i++) //left and right level
    {
        Console.SetCursorPosition(0, i);
        Console.WriteLine("-");
        Console.SetCursorPosition(regionSnake[0], i);
        Console.WriteLine("-");
    }

    for (int i = 0; i <= regionSnake[0]; i++) //low level
    {
        Console.SetCursorPosition(i, regionSnake[1]);
        Console.WriteLine("-");
    }
}

int[] Get_Prize(int[] old_prize, int[] regionSnake) // Def Random place for Prize and set prize
{
    old_prize[0] = new Random().Next(1, regionSnake[0]); //generate place for prize
    old_prize[1] = new Random().Next(1, regionSnake[1]);

    Console.SetCursorPosition(old_prize[0], old_prize[1]); //set new prize
    Console.WriteLine("$");

    return old_prize;
}

int[] move_snake(int[] temp_head, int[] temp_prize)//Def Head Snake
{

    Console.SetCursorPosition(temp_head[0], temp_head[1]);//clear old head
    Console.WriteLine(" ");
    //calculating the nearest distance
    double distance1 = distance(temp_head[0], temp_head[1] - 1, temp_prize[0], temp_prize[1]); //наверх
    double distance2 = distance(temp_head[0], temp_head[1] + 1, temp_prize[0], temp_prize[1]); //вниз
    double distance3 = distance(temp_head[0] + 1, temp_head[1], temp_prize[0], temp_prize[1]); //вправо
    double distance4 = distance(temp_head[0] - 1, temp_head[1], temp_prize[0], temp_prize[1]); //влево
    double min = distance1;
    if (distance2 < min) min = distance2;
    if (distance3 < min) min = distance3;
    if (distance4 < min) min = distance4;

    if (min == distance1) // Step Up
    {
        temp_head[1] = temp_head[1] - 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance2) // Step down
    {
        temp_head[1] = temp_head[1] + 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance3) // Step right
    {
        temp_head[0] = temp_head[0] + 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance4) // Step left
    {
        temp_head[0] = temp_head[0] - 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    else
    {
        return temp_head;
    }
}

double distance(int x1, int y1, int x2, int y2)//Def calculating distance
{
    double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    return distance;
}

//MAIN

int[] region = { 60, 15 };
AreaSnake(region);
int count = 0;
int[] head = { 2, 1 };
Console.SetCursorPosition(head[0], head[1]); //set first head
Console.WriteLine("+");

int[] prize = { 1, 1 };
prize = Get_Prize(prize, region);

while (count < 1000)
{
    if (distance(head[0], head[1], prize[0], prize[1]) != 0)
    {
        head = move_snake(head, prize);
    }
    else
    {
        prize = Get_Prize(prize, region);
    }
    count++;
    System.Threading.Thread.Sleep(30);
}

