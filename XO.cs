using System;

namespace XoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Iks Ygul Game You play ageinst the computer and you will allways play first :");
            Console.WriteLine("Enter raw number and column number to place the X: ");
            string table = " 3 - - - \n 2 - - - \n 1 - - - \n   1 2 3";
            string[] used = new string[9];
            int turnCount = 0;
            bool wincheck = false;
            string input;
            Console.WriteLine(table);

            while (true)
            {

                string massageRaw = "Enter raw number";
                int raw;
                string massageColumn = "Enter Column number";
                int column;


                // raw input + check 
                Console.WriteLine(massageRaw);
                input = Console.ReadLine();
                raw = inputCheck(input);
               


                // col ipnput + check
                Console.WriteLine(massageColumn);
                input = Console.ReadLine();
                column = inputCheck(input);

                if (!placementCheck(used, raw, column))
                    continue;

                table = xplacement(used, table, raw, column);
                Console.WriteLine(table);
                turnCount++;

                //first turn
                if (turnCount < 2) { 
                    table = firstOPlacement(used, table);
                Console.WriteLine(table);
                    turnCount++;
                    continue;
                }

                //second turn
                if (turnCount == 3) {
                    table = secondOcompPlacment(used, table);
                    Console.WriteLine(table);
                    turnCount++;
                    continue;
                }
               
                //third and forth turn
                if (turnCount < 9)
                {
                    wincheck = winCheck(used, table, wincheck);

                    if (wincheck)
                    {
                        table = thirdOcompPlacment(caseWin(used,table), table);
                        Console.WriteLine(table);
                        Console.WriteLine("You Lost!!! :P Let's play again");
                        table = " 3 - - - \n 2 - - - \n 1 - - - \n   1 2 3";
                        Console.WriteLine(table);
                        used = new string[9];
                        turnCount = 0;
                        continue;
                    }
                    else
                    {
                        table = secondOcompPlacment(used, table);
                        Console.WriteLine(table);
                        turnCount++;
                        continue;
                    }
                }
                
                //Summery
                if(turnCount > 8)
                Console.WriteLine("It's a draw :/ Let's play again");
                table = " 3 - - - \n 2 - - - \n 1 - - - \n   1 2 3";
                Console.WriteLine(table);
                used = new string[9];
                turnCount = 0;
                continue;


            }
        }

        //Done
        static int inputCheck(string input)
        {
            string check = "";
            int number = 0;


            while (number == 0)
            {
                for (int i = 0 ; i<input.Length ;i++ )
            {
                if (input[i] != ' ')
                    check += input[i];
            }

           
                switch (check)
                {
                    case "1":
                        number = 1;
                        break;
                    case "2":
                        number = 2;
                        break;
                    case "3":
                        number = 3;
                        break;
                }

                if (number == 0)
                {
                    Console.WriteLine("You Enterd an invalid number please Enter one of the folowing (1,2,3) and hit enter ");
                    input = Console.ReadLine();
                    check = "";
                }
            }

                return number;

        }

        //(Done)
        static bool placementCheck(string[] used, int raw, int col)
        {
            string place = "" + raw + col;

            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] != null)
                {
                    if (place+"X" == used[i] || place+"O" == used[i])
                    {
                        Console.WriteLine("this box is taken choose a legal box.");
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        //(Done)
        static string xplacement(string [] used ,String table ,int raw ,int col)
        {
            string place = "" + raw + col;

            for (int i = 0 ; i < used.Length ;i++ )
            {
                if (used[i] != null)
                { 
                        if (place == used[i])
                        {
                            Console.WriteLine("this box is taken choose a legal box.");
                            return table;
                        }  
                }
                else
                {
                    used[i] = place+"X";
                    break;
                }
            }

            string newTable = "";
            switch (place)
            {
                case "11":
                    for (int i = 0 ; i<table.Length ; i++ )
                    {
                        if (i == 23)
                            newTable += "X";
                        else
                        newTable += table[i];
                    }


                    break;
                case "12":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 25)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "13":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 27)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "21":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 13)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "22":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 15)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "23":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 17)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }

                    break;
                case "31":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 3)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "32":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 5)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;

                case "33":
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (i == 7)
                            newTable += "X";
                        else
                            newTable += table[i];
                    }
                    break;
            }
                return newTable;
        }

        //(Done)
        static string firstOPlacement(string[] used, string table)
        {
            int count = 0;
            string newTable = "";


            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] != null)
                    count++;
            }


            if (count == 1 && centerCheck(used))
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (i == 15)
                    {
                        newTable += "O";
                        for (int y = 0; y < used.Length; y++)
                        {
                            if (used[y] == null)
                            {
                                used[y] = "22O";
                                break;
                            }
                        }


                    }
                    else
                        newTable += table[i];
                }
            }
            else
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (i == 7)
                    {
                        newTable += "O";
                        for (int y = 0; y < used.Length; y++)
                        {
                            if (used[y] == null)
                            {
                                used[y] = "33O";
                                break;
                            }
                        }
                    }
                    else
                        newTable += table[i];
                }
            }

            return newTable;



        }

        //(Done)
        static string secondOcompPlacment(string[] used, string table)
        {
            
            string newTable = "";
           

            string raw = "";
            int rawcheck = 0;
            //first raw check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "11X" || used[i] == "12X" || used[i] == "13X") {
                    raw += used[i];
                    rawcheck++;
                }
            }

            if (rawcheck > 1 && (table[23] == '-' || table[25] == '-' || table[27] == '-')) { }
            else
                rawcheck = 0;
            


            if (rawcheck > 1)
            {
                switch (raw)
                {
                    case "11X12X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                            break;
                    case "11X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 25)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "12O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "12X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "12X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 25)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "12O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X12X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;

                        

                }
                return newTable;
            }


            raw = "";
            rawcheck = 0;
            //second raw check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "21X" || used[i] == "22X" || used[i] == "23X")
                {
                    raw += used[i];
                    rawcheck++;
                }
            }

            if (rawcheck > 1 && (table[13] == '-' || table[15] == '-' || table[17] == '-')) { }
            else
                rawcheck = 0;


            if (rawcheck > 1 )
            {
                switch (raw)
                {
                    case "21X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "21X23X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 15)
                            {
                                if (table[i] == '-') {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "22O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for(int y=0;y < table.Length ; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x=0;x<used.Length ;x++)
                                            {
                                                if(used[x] == null)
                                                {
                                                    used[x] = "13O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X21X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X23X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 13)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "21O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "23X21X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 15)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "22O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "13O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "23X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 13)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "21O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }


            raw = "";
            rawcheck = 0;
            //third raw check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31X" || used[i] == "32X" || used[i] == "33X")
                {
                    raw += used[i];
                    rawcheck++;
                }
            }

            if (rawcheck > 1 && (table[3] == '-' || table[5] == '-' || table[7] == '-')) { }
            else
                rawcheck = 0;

            if (rawcheck > 1)
            {
                switch (raw)
                {
                    case "31X32X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "33O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "31X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "32O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "32X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "33O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "32X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "33X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "32O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "33X32X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }
          
  

            string col = "";
            int colCheck = 0;
            //first col check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31X" || used[i] == "21X" || used[i] == "11X")
                {
                    col += used[i];
                    colCheck++;
                }
            }

            if (colCheck > 1 && (table[3] == '-' || table[13] == '-' || table[23] == '-')) { }
            else
                colCheck = 0;

            if (colCheck > 1)
            {
                switch (col)
                {
                    case "31X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 13)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "21O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "31X21X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "21X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "21X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "11X21X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "11X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 13)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "21O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }


            col = "";
            colCheck = 0;
            //second col check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "32X" || used[i] == "22X" || used[i] == "12X")
                {
                    col += used[i];
                    colCheck++;
                }
            }

            if (colCheck > 1 && (table[5] == '-' || table[15] == '-' || table[25] == '-')) { }
            else
                colCheck = 0;

            if (colCheck > 1)
            {
                switch (col)
                {
                    case "32X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 25)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "12O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "32X12X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 15)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "22O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "13O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X32X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 25)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "12O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X12X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "32O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "12X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "32O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "12X32X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 15)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "22O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "13O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }


            col = "";
            colCheck = 0;
            //third col check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "33X" || used[i] == "23X" || used[i] == "13X")
                {
                    col += used[i];
                    colCheck++;
                }
            }

            if (colCheck > 1 && (table[7] == '-' || table[17] == '-' || table[27] == '-')) { }
            else
                colCheck = 0;

            if (colCheck > 1)
            {
                switch (col)
                {
                    case "33X23X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "33X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "23X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "33O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "23X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X23X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "33O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }



            //ltr Slashcheck
            col = "";
            colCheck = 0;
            //third col check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31X" || used[i] == "22X" || used[i] == "13X")
                {
                    col += used[i];
                    colCheck++;
                }
            }

            if (colCheck > 1 && (table[3] == '-' || table[15] == '-' || table[27] == '-')) { }
            else
                colCheck = 0;

            if (colCheck > 1)
            {
                switch (col)
                {
                    case "31X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "31X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X13X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "13O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "31O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "13X31X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "23O";
                                        break;
                                    }
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;



                }
                return newTable;
            }



            //rtl Slashcheck
            col = "";
            colCheck = 0;
            //third col check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "33X" || used[i] == "22X" || used[i] == "11X" || used[i] == "12X" || used[i] == "13X" || used[i] == "21X" || used[i] == "23X" || used[i] == "31X" || used[i] == "32X")
                {
                    col += used[i];
                    colCheck++;
                }
            }

            /*if (colCheck > 1 && (table[7] == '-' || table[15] == '-' || table[23] == '-')) { }
            else
                colCheck = 0;*/

            if (colCheck > 1)
            {
                switch (col)
                {
                    case "11X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "33O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "11X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "23O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 25)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "12O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X33X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "22X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "33O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "13O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "33X22X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newTable += "O";
                                for (int y = 0; y < used.Length; y++)
                                {
                                    if (used[y] == null)
                                    {
                                        used[y] = "11O";
                                        break;
                                    }
                                }


                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    case "33X11X":
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                if (table[i] == '-')
                                {

                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "23O";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    newTable = "";
                                    for (int y = 0; y < table.Length; y++)
                                    {
                                        if (y == 27)
                                        {
                                            newTable += "O";
                                            for (int x = 0; x < used.Length; x++)
                                            {
                                                if (used[x] == null)
                                                {
                                                    used[x] = "32O";
                                                    break;
                                                }

                                            }


                                        }
                                        else
                                            newTable += table[y];
                                    }

                                    break;
                                }

                            }
                            else
                                newTable += table[i];
                        }
                        break;
                    default:
                        if (table[27] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 27)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "13O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];

                            }
                        }
                        else if(table[17] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 17)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "23O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];
                            }

                        }
                        else if (table[23] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 23)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "11O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];
                            }

                        }
                        else if (table[13] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 13)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "21O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];
                            }

                        }
                        else if (table[5] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 5)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "32O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];
                            }

                        }
                        else if (table[25] == '-')
                        {
                            for (int i = 0; i < table.Length; i++)
                            {
                                if (i == 25)
                                {
                                    newTable += "O";
                                    for (int y = 0; y < used.Length; y++)
                                    {
                                        if (used[y] == null)
                                        {
                                            used[y] = "12O";
                                            break;
                                        }
                                    }
                                }
                                else
                                    newTable += table[i];
                            }

                        }



                        break;



                }
                return newTable;
            }



            return newTable;
        }

        //(Done)
        static bool winCheck(string[] used, string table ,bool wincheck)
        {

            string winCheck = "";
            int count = 0;


            //check wining option

            //rtl slash check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "11O" || used[i] == "22O" || used[i] == "33O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
               wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }

            winCheck = "";
            count = 0;
            //ltr slash check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "22O" || used[i] == "13O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }

            winCheck = "";
            count = 0;
            //raw 1 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "11O" || used[i] == "12O" || used[i] == "13O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }


            winCheck = "";
            count = 0;
            //raw 2 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "21O" || used[i] == "22O" || used[i] == "23O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }


            winCheck = "";
            count = 0;
            //raw 3 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "32O" || used[i] == "33O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }


            winCheck = "";
            count = 0;
            //col 1 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "21O" || used[i] == "11O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }

            winCheck = "";
            count = 0;
            //col 2 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "12O" || used[i] == "22O" || used[i] == "32O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }


            winCheck = "";
            count = 0;
            //raw 3 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "33O" || used[i] == "23O" || used[i] == "13O")
                {
                    winCheck += used[i];
                    count++;
                    if (count == 2)
                        break;
                }
            }

            if (count == 2)
            {
                wincheck = winCaseCheck(winCheck, table);
                if (wincheck)
                    return wincheck;
            }

            return wincheck;
            }

        //(Done)
        static bool winCaseCheck (string winCheck,string table)
        {
            bool wincheck = false;



            switch (winCheck)
            {
                case "22O11O":
                    if (table[7] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O12O":
                    if (table[5] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O13O":
                    if (table[3] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O21O":
                    if (table[17] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O23O":
                    if (table[13] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O31O":
                    if (table[27] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O32O":
                    if (table[25] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "22O33O":
                    if (table[23] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O11O":
                    if (table[15] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O12O not a win":
                    if (table[7] == '-')
                    {
                        wincheck = false;
                    }
                    break;
                case "33O13O":
                    if (table[17] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O21O":
                    if (table[7] == '-')
                    {
                        wincheck = false;
                    }
                    break;
                case "33O22O":
                    if (table[23] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O23O":
                    if (table[27] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O31O":
                    if (table[5] == '-')
                    {
                        wincheck = true;
                    }
                    break;
                case "33O32O":
                    if (table[3] == '-')
                    {
                        wincheck = true;
                    }
                    break;


            }




            return wincheck;
        }

        //(Done)
        static string caseWin(string[] used, string table)
        {

            string win = "";
            int count = 0;


            //win pair 

            //rtl slash check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "11O" || used[i] == "22O" || used[i] == "33O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

          

            win = "";
            count = 0;
            //ltr slash check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "22O" || used[i] == "13O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

 

            win = "";
            count = 0;
            //raw 1 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "11O" || used[i] == "12O" || used[i] == "13O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

   


            win = "";
            count = 0;
            //raw 2 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "21O" || used[i] == "22O" || used[i] == "23O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

      


            win = "";
            count = 0;
            //raw 3 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "32O" || used[i] == "33O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }



            win = "";
            count = 0;
            //col 1 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "31O" || used[i] == "21O" || used[i] == "11O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

    

            win = "";
            count = 0;
            //col 2 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "12O" || used[i] == "22O" || used[i] == "32O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

     


            win = "";
            count = 0;
            //raw 3 check
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "33O" || used[i] == "23O" || used[i] == "13O")
                {
                    win += used[i];
                    count++;
                    if (count == 2)
                        return win;
                }
            }

       
            return win;
        }

        //(Done)
        static string thirdOcompPlacment(string winCheck, string table)
        {
            string newtable = "";
          
            switch (winCheck)
            {
                case "22O11O":
                    if(table[7] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 7)
                            {
                                newtable += "O";
     
                            }
                            else
                                newtable += table[i];
                        }
                    }   
                    break;
                case "22O12O":
                    if (table[5] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O13O":
                    if (table[3] == '-')
                    {
                        for(int i = 0;i < table.Length ;i++ ) {
                            if (i == 3)
                            {
                                newtable += "O";
                               
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O21O":
                    if (table[17] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newtable += "O";
                              
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O23O":
                    if (table[13] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 13)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O31O":
                    if (table[27] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O32O":
                    if (table[25] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 25)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "22O33O":
                    if (table[23] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O11O":
                    if (table[15] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 15)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O12Onot a win":
                    if (table[3] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newtable += "O";
                               
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O13O":
                    if (table[17] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 17)
                            {
                                newtable += "O";
                              
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O21O not a win":
                    if (table[3] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newtable += "O";
                              
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O22O":
                    if (table[23] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 23)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O23O":
                    if (table[27] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 27)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O31O":
                    if (table[5] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 5)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;
                case "33O32O":
                    if (table[3] == '-')
                    {
                        for (int i = 0; i < table.Length; i++)
                        {
                            if (i == 3)
                            {
                                newtable += "O";
                                
                            }
                            else
                                newtable += table[i];
                        }
                    }
                    break;


            }





            //else block


            return newtable;
        }

        //(Done)
        static bool centerCheck(string [] used)
        {
            bool avalable = true;

            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == "22X")
                    avalable = false;
            }

            return avalable;
        }



    }
}
