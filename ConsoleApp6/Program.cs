
char[,] board = new char[3, 3]; 
InitializeBoard(board);   
char currentPlayer = 'X'; 

for (int turn = 0; turn < 9; turn++)   
{
	Console.Clear();  
	PrintBoard(board); 

	Console.WriteLine($"Gracz {currentPlayer}, wprowadź wiersz (0, 1, 2):");
	int row = int.Parse(Console.ReadLine());
	Console.WriteLine("Wprowadź kolumnę (0, 1, 2):");
	int col = int.Parse(Console.ReadLine());

	  
	if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
	{
		Console.WriteLine("Nieprawidłowy ruch, spróbuj ponownie.");
		turn--;   
		Console.ReadKey();  
		continue;
	}

	  
	board[row, col] = currentPlayer;

	  
	if (CheckWin(board, currentPlayer))
	{
		Console.Clear();
		PrintBoard(board);
		Console.WriteLine($"Gratulacje! Gracz {currentPlayer} wygrał!");
		return; 
	}

	  
	currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
}

Console.Clear();
PrintBoard(board);
Console.WriteLine("Remis! Nie ma więcej ruchów.");
    

    static void InitializeBoard(char[,] board)
{
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			board[i, j] = ' ';   
		}
	}
}

static void PrintBoard(char[,] board)
{
	for (int i = 0; i < 3; i++)
	{
		Console.WriteLine(" " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2]);
		if (i < 2)
		{
			Console.WriteLine("---|---|---");
		}
	}
}

static bool CheckWin(char[,] board, char player)
{

	for (int i = 0; i < 3; i++)
	{
		if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
			return true;
	}

	  
	for (int j = 0; j < 3; j++)
	{
		if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
			return true;
	}

	  
	if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
		return true;
	if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
		return true;

	return false;   
}
