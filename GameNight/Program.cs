/*
* Name: Alex White
* Course: CSCI 1250, Section 002
* Assignment: Lab 08, Game Night
* Date: November 18, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

// Sets constant variables to outside files and also set up MAX_POINTS to 20 

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

// Movies the current directory in bin up to where the program.cs is and where the .txt files are
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

//Reads all lines from players file and the points file
string [] players = File.ReadAllLines(PLAYERS_FILE);
string [] pointsPerPerson = File.ReadAllLines(POINTS_FILE);

// Created headers 
Console.Write("PLAYER");
Console.WriteLine("POINTS".PadLeft(11));

// The for loop uses i to run thogh the players length-1 and print the index value for both players ponts array based on i
int i;
for(i =0; i <= players.Length-1; i++)
{
    Console.WriteLine ($"{players[i].PadRight(11)}{pointsPerPerson[i]}");
}

// using the method LeaderIndex to get the index of the Leader before setting it as a variable and using it as a indes value to print the game and score of 1st place
int leaderOfGame= LeaderIndex(pointsPerPerson);
Console.WriteLine($"Leader: {players[leaderOfGame]} with {pointsPerPerson[leaderOfGame]}");

//sets the totalNumber variable to the output of the TotalPoints method and prints it to console with lable
int totalNumber =TotalPoints(pointsPerPerson);
Console.WriteLine($"Season total: {totalNumber}");

//this method give the index value of the highest score
static int LeaderIndex(string[] points)
{
    //set variables up to be used later
    int leader = 0;
    int i;

    //This loop runs though each value in the array 
    for (i=0; i<= points.Length-1; i++)
    {

        //compares the index value to the leader variable if higher the leader value is updated to show index value 
        if(Convert.ToInt32(points[i])> Convert.ToInt32(points[leader]))
        {
            leader = i;
        }
    }

    //returns the leader value
    return leader;
}

// This method adds up all the points to get a total
static int TotalPoints(string[] points)
{
    // set variable up to be used later
    int total = 0;

    //This foreach loop take the array of points and runs through all of them to be added up and put in a total variable
    foreach (string point in points)
    {
        total += Convert.ToInt32(point);
    }

    // returns the total value
    return total;
}