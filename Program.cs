using Microsoft.VisualBasic;
using Raylib_cs;

namespace HelloWorld;

class Program
{
    const int ScreenHeight = 400;
    const int ScreenWidth = 800;
    static string testMessage = "This is a test and it should be \n split on character so here :\nhello its me yay";
    static void DrawScore(int playerScore, int opponentScore) {
        drawMultilineTextCentered($"Score :\n{playerScore} : {opponentScore}", ScreenWidth /2, 20, 32, 4, Color.Black);
    }
    static string[] splitString(string inputString, char character) {
        //From a given string, return a list of strings split on the needed character last element is the lenght of the longest string (as a string)
        List<string> resultList = [];
        string currentString = "";
        int splitLenght = 1;
        // int currentLenght = 0;
        // int maxLenght = 0;
        foreach (char currentCharacter in inputString) {
            // Console.WriteLine($"Currently we are at the character {currentCharacter} and the target is {character} do they match : {currentCharacter == character}");
            if (currentCharacter == character) {
                resultList.Add(currentString);
                currentString = "";
                splitLenght +=1;
                // if (currentLenght > maxLenght) {
                //     maxLenght = currentLenght;

                // }
                // currentLenght = 0;
            } 
            else {
                currentString += currentCharacter;
                // currentLenght += 1;

            }

        }
        resultList.Add(currentString);
        // if (currentLenght > maxLenght) {
        //     maxLenght = currentLenght;
        // }
        // resultList.Add(maxLenght.ToString());
        resultList.Add(splitLenght.ToString());
        return resultList.ToArray();
    }
    static void drawMultilineTextCentered(string  textToDraw, int xPos, int yPos, int textSize, int spacing, Color color) {
        string[] splitText = splitString(textToDraw, '\n');
        for (int i = 0; i < int.Parse(splitText[^1]); i++) {
            Raylib.DrawText(splitText[i], xPos - Raylib.MeasureText(splitText[i], textSize)/2, yPos + i * textSize + i* spacing, textSize, color);
        }

    }
    static void draw() {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Red);

            Raylib.DrawText($"({Raylib.GetMousePosition().ToString()})", 12, 12, 20, Color.White);
            DrawScore(3, 4);

            Raylib.EndDrawing();
    }
    static void update() {

    }

    public static void Main()
    {
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            update();
            draw();
        }
        foreach (string phrase in splitString(testMessage, '\n')) {
            Console.WriteLine(phrase);
        }

        Raylib.CloseWindow();
    }
}