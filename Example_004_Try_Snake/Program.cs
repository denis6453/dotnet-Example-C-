using static System.Math;


Console.Clear();

int check = 0;
// //Def Area Rectangle
int region_x = 60;
int region_y = 15;

for (int i = 0; i < region_x; i++) //high level
{
    Console.SetCursorPosition(i, 0);
    Console.WriteLine("-");
}

for (int i = 0; i < region_y; i++) //left and right level
{
    Console.SetCursorPosition(0, i);
    Console.WriteLine("-");
    Console.SetCursorPosition(region_x, i);
    Console.WriteLine("-");
}

for (int i = 0; i <= region_x; i++) //low level
{
    Console.SetCursorPosition(i, region_y);
    Console.WriteLine("-");
}

// Def Random place for Prize and set prize
int[] Get_Prize(int[] old_prize)
{

    // Console.SetCursorPosition(old_prize[0], old_prize[1]);//clear old prize
    // Console.WriteLine(" ");

    old_prize[0] = new Random().Next(1, region_x); //generate place for prize
    old_prize[1] = new Random().Next(1, region_y);

    Console.SetCursorPosition(old_prize[0], old_prize[1]); //set new prize
    Console.WriteLine("$");
    //System.Threading.Thread.Sleep(1000);
    return old_prize;
}

//Def Head Snake
int[] move_snake(int[] temp_head, int[] temp_prize)
{

    Console.SetCursorPosition(temp_head[0], temp_head[1]);//clear old prize
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

    if (min == distance1)
    {
        temp_head[1] = temp_head[1] - 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance2)
    {
        temp_head[1] = temp_head[1] + 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance3)
    {
        temp_head[0] = temp_head[0] + 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    if (min == distance4)
    {
        temp_head[0] = temp_head[0] - 1;
        Console.SetCursorPosition(temp_head[0], temp_head[1]); //set new head
        Console.WriteLine("+");
        return temp_head;
    }
    else
    {
        check = 1;
        return temp_head;
    }
}

double distance(int x1, int y1, int x2, int y2)
{
    double distance = Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
    return distance;
}



//MAIN
int count = 0;
// int head_x = 2;
// int head_y = 1;
int[] head = new int[2];
head[0] = 2;
head[1] = 1;

Console.SetCursorPosition(head[0], head[1]); //set first head
Console.WriteLine("+");

// int prize_x = 1;
// int prize_y = 1;
int[] prize = new int[2];
prize[0] = 1;
prize[1] = 1;

prize = Get_Prize(prize);
while (count < 1000)
{
if (distance(head[0], head[1], prize[0], prize[1]) != 0)
{
    head = move_snake(head, prize);
}
else 
{
    prize = Get_Prize(prize);
    //head = move_snake(head, prize);
}   
count++;
System.Threading.Thread.Sleep(80);
}

