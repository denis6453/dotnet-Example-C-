Console.Clear();

//Def Area Rectangle
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
int[] Get_Prize(int [] old_prize)
{
    int prize_x = old_prize[0];
    int prize_y = old_prize[1];
     
    Console.SetCursorPosition(prize_x, prize_y);//clear old prize
    Console.WriteLine(" ");

     int new_prize_x = new Random().Next(1, region_x); //generate place for prize
     int new_prize_y = new Random().Next(1, region_y);

    Console.SetCursorPosition(new_prize_x, new_prize_y); //set new prize
    Console.WriteLine("+");
    //System.Threading.Thread.Sleep(1000);
    int[] new_prize = new int[2];
    new_prize[0] = new_prize_x;
    new_prize[1] = new_prize_y;
    return new_prize;
}

int count = 0;
int[] prize = new int[2];
prize[0] = 1;
prize[1] = 1;
while (count < 15)
{
     prize = Get_Prize(prize);
    count++;
    System.Threading.Thread.Sleep(1000);
}

