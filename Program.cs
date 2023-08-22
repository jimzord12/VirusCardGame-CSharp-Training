using GameRunner_NS;

Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
Console.WriteLine("  -= The Digital Version of 'Virus Board Game' =-");
Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
Console.WriteLine();

try
	{
	GameRunner.StartGame();
	}
catch (NotImplementedException e)
	{
    Console.WriteLine(e);

}