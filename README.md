# tic-tac-toe
Tic-Tac-Toe game.

## Instructions
- Implement a single-player version of the game Tic-Tac-Toe against any kind of AI or
random moves.
- Spec: https://www.thesprucecrafts.com/tic-tac-toe-game-rules-412170
- Visualization: Text or ASCII art is fine, bonus points for graphics in Unity3D.













## TODO:
- Draw board
- Allow to click buttons
- Buttons selected will create an `x`
- Create random move mode
- Check if game is complete (3 in a row or if no more moves can be played)
- Unit tests
- Always start with `x`.
- Switch to `o` on next turn
- Create simple player
- Create ability to expand board based on selection (meaning, default to `3x3`, but select more `4x4`, `5x5`, etc.)
- Create impossible AI
- Make sure to review the requirements and spec before turning in
- Beef up the README.md












todo:
check against current rules
need to be able to switch the pieces used between the players
one thing for sure is the board size bug
rethink the structure
loop the entire thing, randomly assign the x and o's
allow only the x to go first
create abstract player
     human
     computer random and smarter, only implement the random for now
create board object
     init board
     GetBoardSize
     DrawBoard
     move
     ComputerTurn
	 OpenPositions - possible moves left
	 MovesTaken
     is there a winner?
         horizontals
         verticals
         diagonals (primary and secondary)
     any more turns?
create a smarter computer









 //Testing...
                _moves = new string[3, 3] {
                    { "", "", "x" },
                    { "", "x", "" },
                    { "x", "", "" }
                };

                _moves = new string[3, 3] {
                    { "x", "", "" },
                    { "", "x", "" },
                    { "", "", "x" }
                };
