using System;
using System.Threading;

namespace finalfinalsudoku
{
    class Program
    {
        static void Main(string[] args)

        {
            bool enter_flag = true;
            string[,] dots = new string[18, 18];
            double point = 0;
            int Piece_Show = -1;
            int combo = 0;
            double roundpoint;
            string[] CalcBinComb = new string[9];
            double Score_2x_color;
            double caLculation_score = 0;
            string[] Calculation_Binary_2 = new string[9];
            double comboinc = 0;
            string[] Calculation_Binary = new string[9];

            int cursorx;
            int cursory = 4;

            for (int i = 0; i < dots.GetLength(0); i++) // This for loop is for creating dots and  these dots are array
            {

                cursorx = 4;
                for (int j = 0; j < dots.GetLength(1); j++)
                {
                    if (i == 5 || i == 11 || i == 17)
                    {
                        if (j == 5 || j == 11 || j == 17)
                            dots[i, j] = "+";
                        else
                            dots[i, j] = "-";
                        cursorx++;
                    }
                    else
                    {
                        if (cursory % 2 == 0)
                        {
                            if (cursorx % 2 == 0)
                                dots[i, j] = ".";
                            else if (cursorx % 2 != 0)
                            {
                                if (j == 5 || j == 11 || j == 17)
                                    dots[i, j] = "|";
                                else
                                    dots[i, j] = " ";
                            }
                            cursorx++;
                        }
                        else if (cursory % 2 != 0)
                        {
                            if (j == 5 || j == 11 || j == 17)
                                dots[i, j] = "|";
                            else
                                dots[i, j] = " ";
                            cursorx++;
                        }

                    }
                }
                cursory += 1;
            }
            do
            {
                Console.CursorVisible = false;

                Piece_Show++;
                int count1 = 0;
                roundpoint = 0;
                Console.SetCursorPosition(41, 5);//Clears the "New Piece" text.
                Console.Write("      ");
                Console.SetCursorPosition(41, 7);
                Console.Write("      ");
                Console.SetCursorPosition(41, 9);
                Console.Write("      ");

                for (int k = 0; k < Calculation_Binary.Length; k++)//Resets binary calculation display.
                {
                    Calculation_Binary[k] = null;
                }
                for (int k = 0; k < Calculation_Binary.Length; k++)////Clears the binary calculation on the screen.
                {

                    if (Calculation_Binary_2[k] == Calculation_Binary[k])
                        count1++;
                    if (count1 == 9)
                    {
                        Console.SetCursorPosition(74, 15);
                        Console.Write("                                    ");
                        Console.SetCursorPosition(74, 16);
                        Console.Write("                                    ");
                        Console.SetCursorPosition(74, 14);
                        Console.Write("                            ");

                    }


                }


                if (combo >= 2)//Combo part
                {
                    point += ((caLculation_score + comboinc));
                    Console.SetCursorPosition(74, 17);
                    Console.Write(caLculation_score + " + " + comboinc + " = " + (caLculation_score + comboinc));
                    Console.SetCursorPosition(74, 18);
                    Console.Write(caLculation_score + comboinc + " * 2  = " + (caLculation_score + comboinc) * 2);
                    Console.SetCursorPosition(86, 16);
                    Console.Write(" = " + "(" + comboinc + ")10");
                    Score_2x_color = 0;
                    Console.CursorVisible = false;
                    while (Score_2x_color < 10)//Animated combo effect
                    {

                        Console.SetCursorPosition(74, 19);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Score 2X!");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(74, 19);
                        Console.Write("Score 2X!");
                        Thread.Sleep(100);
                        Console.ResetColor();

                        Score_2x_color++;
                    }
                    Console.SetCursorPosition(74, 19);
                    Console.Write("          ");
                    Console.CursorVisible = true;

                }
                else //Resets combo display on non-combo rounds.
                {
                    Console.SetCursorPosition(90, 10);
                    Console.Write("                                        ");
                    Console.SetCursorPosition(74, 17);
                    Console.Write("                                        ");
                    Console.SetCursorPosition(74, 18);
                    Console.Write("                                        ");
                }
                Console.SetCursorPosition(86, 15);
                if (caLculation_score != 0)//Display of filled blocks/rows/columns score calculation.
                    Console.Write(" = " + "(" + caLculation_score + ")10");
                Console.SetCursorPosition(90, 6);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Piece :  ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Piece_Show);
                Console.SetCursorPosition(90, 3);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Score :  ");
                Console.SetCursorPosition(99, 3);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(point);

                combo = 0;
                comboinc = 0;
                Console.ResetColor();
                cursory = 4;

                for (int i = 0; i < dots.GetLength(0); i++) // This for loop is for creating dots and  these dots are array(The page is updated every time the enter key is pressed)
                {

                    cursorx = 4;
                    for (int j = 0; j < dots.GetLength(1); j++)
                    {
                        if (i == 5 || i == 11 || i == 17)
                        {
                            if (j == 5 || j == 11 || j == 17)//Game board parts (++++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.SetCursorPosition(cursorx, cursory);
                                Console.Write(dots[i, j]);
                                cursorx += 1;

                            }
                            else//Game board parts (----)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.SetCursorPosition(cursorx, cursory);
                                Console.Write(dots[i, j]);
                                cursorx += 1;
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            if (cursory % 2 == 0)
                            {
                                if (cursorx % 2 == 0)
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    Console.Write(dots[i, j]);
                                    cursorx += 1;
                                }
                                else if (cursorx % 2 != 0)
                                {
                                    if (j == 5 || j == 11 || j == 17)//Game board parts (||||)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.SetCursorPosition(cursorx, cursory);
                                        Console.Write(dots[i, j]);
                                        cursorx += 1;
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(cursorx, cursory);
                                        dots[i, j] = " ";
                                        cursorx += 1;
                                    }
                                }
                            }
                            else if (cursory % 2 != 0)
                            {

                                if (j == 5 || j == 11 || j == 17)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.SetCursorPosition(cursorx, cursory);//Game board parts (||||)
                                    Console.Write(dots[i, j]);
                                    cursorx += 1;
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.SetCursorPosition(cursorx, cursory);
                                    dots[i, j] = " ";
                                    cursorx += 1;
                                }

                            }

                        }
                    }
                    cursory += 1;
                }
                Console.SetCursorPosition(3, 3);//Game board parts
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("+—————+—————+—————+");
                Console.SetCursorPosition(3, 4);//Game board parts      
                Console.Write("|\n   |\n   |\n   |\n   |\n   +\n   |\n   |\n   |\n   |\n   |\n   +\n   |\n   |\n   |\n   |\n   |\n   +\n    ");
                Console.SetCursorPosition(1, 4);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("1\n\n 2\n\n 3\n\n 4\n\n 5\n\n 6\n\n 7\n\n 8\n\n 9\n\n");//Game board parts (Left Numbers)
                Console.SetCursorPosition(4, 2);
                Console.WriteLine("1 2 3 4 5 6 7 8 9 ");//Game board parts (Top numbers)          
                cursorx = 41;
                cursory = 3;
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("New piece");
                Console.ResetColor();
                ConsoleKeyInfo ck;
                bool check_pieceplace = true;



                Random zerone = new Random();//This lines for cleaning new piece area
                string[,] piece = new string[3, 3] { { null, null, null }, { null, null, null }, { null, null, null } };
                Random R = new Random();//These codes for creating random piece
                R.Next(0, 10);
                int luck = R.Next(0, 10);
                R.Next(0, 10);
                if (luck == 0)//Piece 1-1
                {
                    piece[0, 0] = "X";
                }
                else if (luck == 1)//Piece 1-2
                {
                    piece[0, 0] = "X";
                    piece[0, 1] = "X";
                }
                else if (luck == 2)//Piece 1-3
                {
                    piece[0, 0] = "X";
                    piece[0, 1] = "X";
                    piece[0, 2] = "X";
                }
                else if (luck == 3)//Piece 1-4
                {
                    piece[0, 0] = "X";
                    piece[0, 1] = "X";
                    piece[1, 0] = "X";
                    piece[1, 1] = "X";
                }
                else if (luck == 4)//Piece 2-2
                {
                    piece[0, 0] = "X";
                    piece[1, 0] = "X";
                }
                else if (luck == 5)//Piece 2-3
                {
                    piece[0, 0] = "X";
                    piece[1, 0] = "X";
                    piece[2, 0] = "X";
                }
                else if (luck == 6)//Piece 3-3
                {
                    piece[0, 0] = "X";
                    piece[0, 1] = "X";
                    piece[1, 0] = "X";
                }
                else if (luck == 7)//Piece 4-3
                {
                    piece[0, 0] = "X";
                    piece[0, 1] = "X";
                    piece[1, 0] = " ";
                    piece[1, 1] = "X";
                }
                else if (luck == 8)//Piece 5-3
                {
                    piece[0, 0] = "X";
                    piece[1, 0] = "X";
                    piece[1, 1] = "X";
                }
                else if (luck == 9)//Piece 6-3
                {
                    piece[0, 0] = " ";
                    piece[0, 1] = "X";
                    piece[1, 0] = "X";
                    piece[1, 1] = "X";
                }

                for (int i = 0; i < piece.GetLength(0); i++)  //Where random numbers are assigned to the "piece" array

                {
                    for (int j = 0; j < piece.GetLength(1); j++)
                    {

                        int piece_num = zerone.Next(0, 2);//Generating 0 or 1 on the pieces.
                        if (piece_num == 0)
                        {
                            if (piece[i, j] == "X")

                                piece[i, j] = "0";
                        }
                        else
                        {
                            if (piece[i, j] == "X")
                                piece[i, j] = "1";
                        }
                    }
                }


                for (int i = 0; i < piece.GetLength(1); i++)// The purpose of the code here is to print the parts on the screen.
                {


                    for (int j = 0; j < piece.GetLength(0); j++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(cursorx, cursory + 2);
                            Console.Write(piece[i, j]);
                            cursorx += 2;
                        }
                        else if (i == 1)
                        {

                            Console.SetCursorPosition(cursorx, cursory + 4);
                            Console.Write(piece[i, j]);
                            cursorx += 2;
                        }
                        else
                        {

                            Console.SetCursorPosition(cursorx, cursory + 6);
                            Console.Write(piece[i, j]);
                            cursorx += 2;
                        }

                    }
                    Console.SetCursorPosition(12, 12);//Cursor location fix
                    cursorx = 41;

                }
                cursorx = 12;
                cursory = 12;

                int end1count = 0;//DETERMINING END OF THE GAME
                if (luck == 1)//Controlling the array for X X piece
                {
                    for (int i = 0; i <= 16; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i, j + 2] == ".")
                            {

                            }
                            else
                                end1count++;

                        }
                    }
                    if (end1count == 72)
                    {
                        break;
                    }

                }
                int end2count = 0;
                if (luck == 2) //Controlling the array for X X X piece
                {
                    for (int i = 0; i <= 16; i += 2)
                    {
                        for (int j = 0; j <= 12; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i, j + 2] == "." && dots[i, j + 4] == ".")
                            {

                            }
                            else
                                end2count++;
                        }
                    }
                    if (end2count == 63)
                    {
                        break;
                    }
                }
                int end3count = 0;
                if (luck == 3) //Controlling the array for X X piece
                               //                                     X X
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i, j + 2] == "." && dots[i + 2, j] == "." && dots[i + 2, j + 2] == ".")
                            {

                            }
                            else
                                end3count++;
                        }
                    }
                    if (end3count == 64)
                    {
                        break;

                    }
                }
                int end4count = 0;
                if (luck == 4) //Controlling the array for X piece 
                               //                                     X
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 16; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i + 2, j] == ".")
                            {

                            }
                            else
                                end4count++;
                        }
                    }
                    if (end4count == 72)
                    {
                        break;

                    }
                }
                int end5count = 0;
                if (luck == 5) // Controlling the array for X piece
                               //                                      X
                               //                                      X
                {
                    for (int i = 0; i <= 12; i += 2)
                    {
                        for (int j = 0; j <= 16; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i + 2, j] == "." && dots[i + 4, j] == ".")
                            {

                            }
                            else
                                end5count++;
                        }
                    }
                    if (end5count == 63)
                    {
                        break;

                    }
                }
                int end6count = 0;
                if (luck == 6) // Controlling the array for X X piece
                               //                                      X
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i, j + 2] == "." && dots[i + 2, j] == ".")
                            {

                            }
                            else
                                end6count++;
                        }
                    }
                    if (end6count == 64)
                    {
                        break;

                    }
                }
                int end7count = 0;
                if (luck == 7) // Controlling the array for X X piece
                               //                                        X
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i, j + 2] == "." && dots[i + 2, j + 2] == ".")
                            {

                            }
                            else
                                end7count++;
                        }
                    }
                    if (end7count == 64)
                    {
                        break;

                    }
                }
                int end8count = 0;
                if (luck == 8) // Controlling the array for X   piece
                               //                                      X X
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j] == "." && dots[i + 2, j] == "." && dots[i + 2, j + 2] == ".")
                            {

                            }
                            else
                                end8count++;
                        }
                    }
                    if (end8count == 64)
                    {
                        break;
                    }
                }
                int end9count = 0;
                if (luck == 9) // Controlling the array for   X piece
                               //                                      X X 
                {
                    for (int i = 0; i <= 14; i += 2)
                    {
                        for (int j = 0; j <= 14; j += 2)
                        {
                            if (dots[i, j + 2] == "." && dots[i + 2, j] == "." && dots[i + 2, j + 2] == ".")
                            {


                            }
                            else
                                end9count++;
                        }
                    }
                    if (end9count == 64)
                    {
                        break;

                    }
                }

                do// If the user tries to enter numbers in spaces by mistake, the program does not crash thanks to this command.
                {



                    enter_flag = true;//This bool exists for the continuity of the game
                    while (enter_flag == true)
                    {


                        if (Console.KeyAvailable)
                        {
                            bool X_check = true, Y_Check = true;
                            for (int i = 9; i <= 15; i += 6)//Prevents the color change while piece is moving.
                            {
                                for (int j = 4; j <= 20; j++)
                                {
                                    Console.SetCursorPosition(i, j);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(dots[j - 4, i - 4]);

                                    Console.ResetColor();
                                }
                            }
                            for (int i = 4; i <= 20; i++)
                            {
                                for (int j = 9; j <= 15; j += 6)
                                {
                                    Console.SetCursorPosition(i, j);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(dots[j - 4, i - 4]);

                                    Console.ResetColor();
                                }
                            }


                            ck = Console.ReadKey(true);

                            if (ck.Key == ConsoleKey.RightArrow && cursorx < 20)//Fix for the pieces do not erase the screen as they pass
                            {
                                
                                    Console.SetCursorPosition(cursorx, cursory);//Row 1
                                    Console.Write(dots[cursory - 4, cursorx - 4]);
                                
                              


                                if ((luck == 1 || luck == 2 || luck == 3 || luck == 6  || luck == 7 || luck == 9 ))
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory);//Row 2
                                    Console.Write(dots[cursory - 4, cursorx - 2]);
                                    if (cursorx >= 18)
                                        X_check = false;
                                }

                                if (luck == 2)
                                {
                                    Console.SetCursorPosition(cursorx + 4, cursory);//Row 3
                                    Console.Write(dots[cursory - 4, cursorx]);
                                    if (cursorx >= 16)
                                        X_check = false;
                                }

                                if (luck == 3 || luck == 4 || luck == 5 || luck == 6  || luck == 9 ||  luck ==8)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 2);//Column 2 Row 1
                                    Console.Write(dots[cursory - 2, cursorx - 4]);


                                }

                                if (luck == 3 || luck == 7 || luck == 8 || luck == 9 )
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory + 2);//Column 2 Row 2
                                    Console.Write(dots[cursory - 2, cursorx - 2]);
                                    if (cursorx >= 18)
                                        X_check = false;
                                }

                                if (luck == 5)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 4);//Column 3 Row 1
                                    Console.Write(dots[cursory, cursorx - 4]);
                                }



                                if (X_check == true)
                                    cursorx++;
                            }


                            if (ck.Key == ConsoleKey.LeftArrow && cursorx > 4)
                            {

                               
                                    Console.SetCursorPosition(cursorx, cursory);//Row 1
                                    Console.Write(dots[cursory - 4, cursorx - 4]);
                                
                                    


                                if ((luck == 1 || luck == 2 || luck == 3 || luck == 6  || luck == 9 ||luck == 7 ))
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory);//Row 2
                                    Console.Write(dots[cursory - 4, cursorx - 2]);

                                }

                                if (luck == 2)
                                {
                                    Console.SetCursorPosition(cursorx + 4, cursory);//Row 3
                                    Console.Write(dots[cursory - 4, cursorx]);
                                }

                                if (luck == 3 || luck == 4 || luck == 5 || luck == 6 || luck == 9 || luck ==8)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 2);//Column 2 Row 1
                                    Console.Write(dots[cursory - 2, cursorx - 4]);
                                }

                                if (luck == 3 || luck == 7 || luck == 8 || luck == 9 )
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory + 2);//Column 2 Row 2
                                    Console.Write(dots[cursory - 2, cursorx - 2]);
                                }



                                if (luck == 5)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 4);//Column 3 Row 1
                                    Console.Write(dots[cursory, cursorx - 4]);
                                }




                                cursorx--;
                            }

                            if (ck.Key == ConsoleKey.UpArrow && cursory > 4)
                            {
                               
                                    Console.SetCursorPosition(cursorx, cursory);//Row 1
                                    Console.Write(dots[cursory - 4, cursorx - 4]);
                                
                                    

                                if ((luck == 1 || luck == 2 || luck == 3 || luck == 6 || luck == 9||luck == 7  ))
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory);//Row 2
                                    Console.Write(dots[cursory - 4, cursorx - 2]);
                                    //if (cursorx >= 20)
                                    //    cursorx--;
                                }

                                if (luck == 2)
                                {
                                    Console.SetCursorPosition(cursorx + 4, cursory);//Column 3
                                    Console.Write(dots[cursory - 4, cursorx]);
                                }

                                if (luck == 3 || luck == 4 || luck == 5 || luck == 6 ||  luck == 9 ||luck==8)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 2);//Column 2 Row 1
                                    Console.Write(dots[cursory - 2, cursorx - 4]);
                                }

                                if (luck == 3 || luck == 7 || luck == 8 || luck == 9 )
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory + 2);//Column 2 Row 2
                                    Console.Write(dots[cursory - 2, cursorx - 2]);
                                    if (cursory >= 20)
                                        Y_Check = false;
                                }



                                if (luck == 5)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 4);//Column 3 Row 1
                                    Console.Write(dots[cursory, cursorx - 4]);
                                }



                                if (X_check == true&& Y_Check==true)
                                cursory--;
                            }

                            if (ck.Key == ConsoleKey.DownArrow && cursory < 20)
                            {

                               
                                    Console.SetCursorPosition(cursorx, cursory);//Row 1
                                    Console.Write(dots[cursory - 4, cursorx - 4]);
                                
                                


                                if ((luck == 1 || luck == 2 || luck == 3 || luck == 6 || luck ==7||  luck == 9 ))
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory);//Row 2
                                    Console.Write(dots[cursory - 4, cursorx - 2]);
                                    if (cursorx >= 20)
                                        cursorx--;
                                }

                                if (luck == 2)
                                {
                                    Console.SetCursorPosition(cursorx + 4, cursory);//Row 3
                                    Console.Write(dots[cursory - 4, cursorx]);
                                }

                                if (luck == 3 || luck == 4 || luck == 5 || luck == 6 ||  luck == 9 || luck==8)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 2);//Column 2 Row 1
                                    Console.Write(dots[cursory - 2, cursorx - 4]);
                                    if (cursory >= 18)
                                        Y_Check = false;
                                }

                                if (luck == 3 || luck == 7 || luck == 8 || luck == 9 )
                                {
                                    Console.SetCursorPosition(cursorx + 2, cursory + 2);//Column 2 Row 2
                                    Console.Write(dots[cursory - 2, cursorx - 2]);
                                    if (cursory >= 18)
                                        Y_Check = false;
                                }



                                if (luck == 5)
                                {
                                    Console.SetCursorPosition(cursorx, cursory + 4);//Column 3 Row 1
                                    Console.Write(dots[cursory, cursorx - 4]);
                                    if (cursory >= 16)
                                        Y_Check = false;
                                }



                                if (Y_Check == true && X_check==true)
                                    cursory++;
                            }


                            Console.ForegroundColor = ConsoleColor.Yellow;//This part is for displaying the random piece at the cursor.

                            if (luck != 9)
                            {
                                Console.SetCursorPosition(cursorx, cursory);
                                Console.Write(piece[0, 0]);
                            }
                           
                            Console.SetCursorPosition(cursorx + 2, cursory);
                            Console.Write(piece[0, 1]);
                            Console.SetCursorPosition(cursorx + 4, cursory);
                            Console.Write(piece[0, 2]);
                            if (luck != 7)
                            {
                                Console.SetCursorPosition(cursorx, cursory + 2);
                                Console.Write(piece[1, 0]);
                            }
                         
                            Console.SetCursorPosition(cursorx + 2, cursory + 2);
                            Console.Write(piece[1, 1]);
                            Console.SetCursorPosition(cursorx + 4, cursory + 2);
                            Console.Write(piece[1, 2]);
                            Console.SetCursorPosition(cursorx, cursory + 4);
                            Console.Write(piece[2, 0]);
                            Console.SetCursorPosition(cursorx + 2, cursory + 4);
                            Console.Write(piece[2, 1]);
                            Console.SetCursorPosition(cursorx + 4, cursory + 4);
                            Console.Write(piece[2, 2]);
                            Console.ResetColor();


                            if (ck.Key == ConsoleKey.Enter)
                            {
                                check_pieceplace = true;
                                if (!(cursory % 2 == 0 && cursorx % 2 == 0))//Gives a warning when cursor is in a wrong place.
                                {
                                    check_pieceplace = false;
                                    Console.SetCursorPosition(4, 22);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("Wrong Place   ");
                                    Console.ResetColor();
                                }

                                if (check_pieceplace == true)//If the cursor is in a placeable position it writes "Binary Sudoku"
                                {
                                    Console.SetCursorPosition(4, 22);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write("BINARY SUDOKU");
                                    Console.ResetColor();
                                    switch (luck)//Here we place the pieces in the table.
                                    {
                                        case 0:
                                            if (dots[(cursory - 4), cursorx - 4] == ".")//Checks the cursor position if piece is placeable or not.
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                enter_flag = false;//This is for game continuity.
                                            }
                                            else
                                            {
                                                check_pieceplace = false;//This part is for not to generate new piece.
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!   "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }

                                            break;

                                        case 1:
                                            if (cursorx == 20)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    ");
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[cursory - 4, cursorx - 2] == ".")
                                            {

                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!   "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }

                                            break;
                                        case 2:
                                            if (cursorx == 20 || cursorx == 18)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!   "); // Wrong place warning
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[(cursory - 4), cursorx - 2] == "." && dots[cursory - 4, cursorx] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 2];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!   "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }

                                            break;
                                        case 3:
                                            if (cursorx == 20 || cursory == 20)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!   "); // Wrong place warning
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[cursory - 4, cursorx - 2] == "." &&
                                                            dots[cursory - 2, cursorx - 4] == "." && dots[cursory - 2, cursorx - 2] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 1];
                                                cursorx -= 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }


                                            break;
                                        case 4:
                                            if (cursory == 20)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[cursory - 2, cursorx - 4] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }

                                            break;
                                        case 5:
                                            if (cursory == 20 || cursory == 18)
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[cursory - 2, cursorx - 4] == "." && dots[cursory, cursorx - 4] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[2, 0];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            break;
                                        case 6:
                                            if (cursorx == 20 || cursory == 20)
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[(cursory - 4), cursorx - 2] == "." &&
                                                dots[cursory - 2, cursorx - 4] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                cursory -= 2;
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!  "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            break;
                                        case 7:
                                            if (cursorx == 20 || cursory == 20)
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!  "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[(cursory - 4), cursorx - 2] == "." &&
                                                dots[cursory - 2, cursorx - 2] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 1];
                                                enter_flag = false;

                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!  "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            break;
                                        case 8:
                                            if (cursory == 20 || cursorx == 20)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!  "); // Wrong place warning
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                break;
                                            }
                                            if (dots[cursory - 4, cursorx - 4] == "." && dots[cursory - 2, cursorx - 4] == "." && dots[cursory - 2, cursorx - 2] == ".")
                                            {
                                                dots[cursory - 4, cursorx - 4] = piece[0, 0];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 1];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!     "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            break;
                                        case 9:
                                            if (cursory == 20 || cursorx == 20)
                                            {
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!    "); // Wrong place warning
                                                Console.ResetColor();
                                                check_pieceplace = false;
                                                break;
                                            }
                                            if (dots[(cursory - 4), cursorx - 2] == "." && dots[cursory - 2, cursorx - 4] == "." && dots[cursory - 2, cursorx - 2] == ".")
                                            {
                                                cursorx += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[0, 1];
                                                cursory += 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 1];
                                                cursorx -= 2;
                                                dots[cursory - 4, cursorx - 4] = piece[1, 0];
                                                enter_flag = false;
                                            }
                                            else
                                            {
                                                check_pieceplace = false;
                                                Console.SetCursorPosition(4, 22);
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Wrong Place!     "); // Wrong place warning
                                                Console.ResetColor();
                                                break;
                                            }
                                            break;
                                    }
                                    for (int j = 0; j <= 16; j += 2) // Checks if there is a row that is filled.
                                    {
                                        if (dots[j, 0] != "." && dots[j, 2] != "." && dots[j, 4] != "." && dots[j, 6] != "." && dots[j, 8] != "." && dots[j, 10] != "." && dots[j, 12] != "." && dots[j, 14] != "." && dots[j, 16] != ".")
                                        {
                                            combo++;
                                            string[] register = { dots[j, 16], dots[j, 14], dots[j, 12], dots[j, 10], dots[j, 8], dots[j, 6], dots[j, 4], dots[j, 2], dots[j, 0] };
                                            for (int i = 0; i <= 16; i += 2)
                                                dots[j, i] = ".";
                                            for (int m = 0; m < 9; m++)
                                            {
                                                string s = register[m];
                                                double b = Convert.ToInt32(s);// Converts binary to decimal 
                                                if (b == 1)
                                                    b = Math.Pow(2, m);
                                                if (combo >= 2)
                                                {
                                                    comboinc += b;
                                                }
                                                else
                                                {
                                                    roundpoint += b;

                                                }
                                                point += b;
                                                if (combo >= 2)//We defined a new array so it does not appear on the screen.
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        CalcBinComb[k] = register[k];
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        Calculation_Binary[k] = register[k];
                                                }

                                            }



                                        }




                                    }
                                    for (int j = 0; j <= 16; j += 2) // Checks if there is a column that is filled.
                                    {
                                        if (dots[0, j] != "." && dots[2, j] != "." && dots[4, j] != "." && dots[6, j] != "." && dots[8, j] != "." && dots[10, j] != "." && dots[12, j] != "." && dots[14, j] != "." && dots[16, j] != ".")
                                        {
                                            combo++;
                                            string[] register = { dots[16, j], dots[14, j], dots[12, j], dots[10, j], dots[8, j], dots[6, j], dots[4, j], dots[2, j], dots[0, j] };
                                            for (int i = 0; i <= 16; i += 2)
                                                dots[i, j] = ".";
                                            for (int m = 0; m < 9; m++)
                                            {
                                                string s = register[m];
                                                double b = Convert.ToInt32(s);
                                                if (b == 1)
                                                    b = Math.Pow(2, m);
                                                if (combo >= 2)
                                                {
                                                    comboinc += b;
                                                }
                                                else
                                                {
                                                    roundpoint += b;

                                                }
                                                point += b;
                                                if (combo >= 2)
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        CalcBinComb[k] = register[k];
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        Calculation_Binary[k] = register[k];
                                                }

                                            }



                                        }
                                    }
                                    for (int j = 0; j < 18; j += 6) // Checks if there is a block that is filled. (First 3 blocks)
                                    {
                                        if (dots[0, j] != "." && dots[0, j + 2] != "." && dots[0, j + 4] != "." && dots[2, j] != "." && dots[2, j + 2] != "." && dots[2, j + 4] != "." && dots[4, j] != "." && dots[4, j + 2] != "." && dots[4, j + 4] != ".")
                                        {
                                            combo++;
                                            string[] register = { dots[4, j + 4], dots[4, j + 2], dots[4, j], dots[2, j + 4], dots[2, j + 2], dots[2, j], dots[0, j + 4], dots[0, j + 2], dots[0, j] };
                                            for (int i = 0; i <= 4; i += 2)
                                            {
                                                for (int plus = 0; plus <= 4; plus++)
                                                    dots[i, j + plus] = ".";
                                            }
                                            for (int m = 0; m < 9; m++)
                                            {
                                                string s = register[m];
                                                double b = Convert.ToInt32(s);
                                                if (b == 1)
                                                    b = Math.Pow(2, m);
                                                if (combo >= 2)
                                                {
                                                    comboinc += b;
                                                }
                                                else
                                                {
                                                    roundpoint += b;

                                                }
                                                point += b;
                                                if (combo >= 2)
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        CalcBinComb[k] = register[k];
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        Calculation_Binary[k] = register[k];
                                                }

                                            }


                                        }
                                    }
                                    for (int j = 0; j < 18; j += 6) // Checks if there is a block that is filled. (Middle blocks)
                                    {
                                        if (dots[6, j] != "." && dots[6, j + 2] != "." && dots[6, j + 4] != "." && dots[8, j] != "." && dots[8, j + 2] != "." && dots[8, j + 4] != "." && dots[10, j] != "." && dots[10, j + 2] != "." && dots[10, j + 4] != ".")
                                        {
                                            combo++;
                                            string[] register = { dots[10, j + 4], dots[10, j + 2], dots[10, j], dots[8, j + 4], dots[8, j + 2], dots[8, j], dots[6, j + 4], dots[6, j + 2], dots[6, j] };
                                            for (int i = 6; i <= 10; i += 2)
                                            {
                                                for (int plus = 0; plus <= 4; plus++)
                                                    dots[i, j + plus] = ".";
                                            }
                                            for (int m = 0; m < 9; m++)
                                            {
                                                string s = register[m];
                                                double b = Convert.ToInt32(s);
                                                if (b == 1)
                                                    b = Math.Pow(2, m);
                                                if (combo >= 2)
                                                {
                                                    comboinc += b;
                                                }
                                                else
                                                {
                                                    roundpoint += b;

                                                }
                                                point += b;

                                                if (combo >= 2)
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        CalcBinComb[k] = register[k];
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        Calculation_Binary[k] = register[k];
                                                }
                                            }


                                        }
                                    }
                                    for (int j = 0; j < 18; j += 6) // Checks if there is a block that is filled.(Bottom blocks)
                                    {
                                        if (dots[12, j] != "." && dots[12, j + 2] != "." && dots[12, j + 4] != "." && dots[14, j] != "." && dots[14, j + 2] != "." && dots[14, j + 4] != "." && dots[16, j] != "." && dots[16, j + 2] != "." && dots[16, j + 4] != ".")
                                        {
                                            combo++;
                                            string[] register = { dots[16, j + 4], dots[16, j + 2], dots[16, j], dots[14, j + 4], dots[14, j + 2], dots[14, j], dots[12, j + 4], dots[12, j + 2], dots[12, j] };
                                            for (int i = 12; i <= 16; i += 2)
                                            {
                                                for (int plus = 0; plus <= 4; plus++)
                                                    dots[i, j + plus] = ".";
                                            }
                                            for (int m = 0; m < 9; m++)
                                            {
                                                string s = register[m];
                                                double b = Convert.ToInt32(s);
                                                if (b == 1)
                                                    b = Math.Pow(2, m);
                                                if (combo >= 2)
                                                {
                                                    comboinc += b;
                                                }
                                                else
                                                {
                                                    roundpoint += b;

                                                }
                                                point += b;
                                                if (combo >= 2)
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        CalcBinComb[k] = register[k];
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < register.Length; k++)
                                                        Calculation_Binary[k] = register[k];
                                                }

                                            }


                                        }

                                    }
                                    caLculation_score = roundpoint;
                                    if (check_pieceplace == true)
                                    {
                                        Console.SetCursorPosition(74, 14);
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.Write("Calculations:");//Calculation display
                                        Console.ResetColor();
                                        Console.SetCursorPosition(74, 15);
                                        Console.Write("(" + "         )2");
                                        Console.SetCursorPosition(88, 15);
                                        Console.Write("(" + "   )10");

                                        if (combo >= 2)
                                        {
                                            Console.SetCursorPosition(74, 16);//Display fix if there is a 2x combo.
                                            Console.Write("(" + "         )2");
                                            Console.SetCursorPosition(88, 16);
                                            Console.Write("(" + "   )10");
                                        }
                                    }

                                    Console.SetCursorPosition(75, 15);
                                    for (int k = Calculation_Binary.Length - 1; k >= 0; k--)//Displaying the filled row column or block.
                                    {


                                        Console.Write(Calculation_Binary[k]);
                                        Calculation_Binary_2[k] = Calculation_Binary[k];

                                    }
                                    if (combo >= 2)//YENİ KOYDUM
                                    {
                                        Console.SetCursorPosition(75, 16);
                                        for (int k = Calculation_Binary.Length - 1; k >= 0; k--)////Displaying the filled row column or block.
                                        {


                                            Console.Write(CalcBinComb[k]);
                                            Calculation_Binary_2[k] = CalcBinComb[k];

                                        }
                                    }


                                }
                            }
                            Console.SetCursorPosition(cursorx, cursory);
                        }
                    }

                } while (check_pieceplace == false);

            } while (enter_flag == false);

            int a = 0;

            while (enter_flag == false)//Animated game over text.
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(83, 3);
                Console.Write("Total Point : ");

                if (a % 2 == 0)
                {

                    Console.SetCursorPosition(60, 13);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER!");
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(60, 13);
                    Console.WriteLine("GAME OVER!");
                    Thread.Sleep(50);
                }
                else
                {
                    Console.SetCursorPosition(60, 13);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("GAME OVER!");
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(60, 13);
                    Console.Write("GAME OVER!");
                    Thread.Sleep(50);
                }
                a++;
            }
            Console.ReadLine();
        }
    }
}

