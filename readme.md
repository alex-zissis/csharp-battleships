## C-Sharp Battleships

This is an implementation of the game battleships on the command line in C#.

### How to run
This was written in VS Code - not Visual Studio but it can be easily be run with the `dotnet` cli.

1. `git clone https://github.com/alex-zissis/csharp-battleships.git`
2. `cd csharp-battleships`
3.  `dotnet run`

### Sample Output
```
Alex, it's your turn 

Opponent's board: 

  |  A  B  C  D  E  F  G  H  I  J 
1 |  X  0  -  -  -  -  -  -  -  - 
2 |  X  -  -  -  -  -  -  X  -  - 
3 |  -  -  -  -  -  -  -  0  0  - 
4 |  -  -  -  -  -  -  -  -  -  - 
5 |  -  -  -  -  -  -  -  -  -  - 
6 |  -  -  -  -  -  -  -  -  -  - 
7 |  -  -  -  -  -  -  -  -  -  - 
8 |  -  -  -  -  -  -  -  -  -  - 
9 |  -  -  -  -  -  -  -  -  -  - 
10|  -  -  -  -  -  -  -  -  -  - 


 Make a guess in the format "A1":
I3
That coordinate has already been guessed, try again

 Make a guess in the format "A1":
I2
HIT: A ship was hit at I2


James, it's your turn 

Opponent's board: 

  |  A  B  C  D  E  F  G  H  I  J 
1 |  -  -  -  -  -  -  -  0  0  - 
2 |  -  -  -  0  -  -  -  0  -  - 
3 |  0  -  -  -  -  -  -  -  -  - 
4 |  -  -  -  -  -  -  0  -  -  - 
5 |  -  -  -  -  -  -  -  -  -  - 
6 |  -  -  -  -  -  -  -  -  -  - 
7 |  -  -  -  -  -  -  -  -  -  - 
8 |  -  -  -  -  -  -  -  -  -  - 
9 |  -  -  -  -  -  -  -  -  -  - 
10|  -  -  -  -  -  -  -  -  -  - 


 Make a guess in the format "A1":
```

Written by Alex Zissis