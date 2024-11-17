using Microsoft.VisualBasic;
using Raylib_cs;

namespace HelloWorld;

class Program
{
    const int ScreenHeight = 400;
    const int ScreenWidth = 800;
    static Paddle player = new Paddle(40, ScreenHeight);
    static Paddle computer = new Paddle(760, ScreenHeight);
    static Ball ball = new Ball(ScreenWidth/2, ScreenHeight);
    static int[] scores = [0, 0];
    static int frame = 0;


    static string testMessage = "This is a test and it should be \n split on character so here :\nhello its me yay";
    static void DrawScore(int playerScore, int opponentScore) {
        drawMultilineTextCentered($"Score :\n{playerScore} : {opponentScore}", ScreenWidth /2, 20, 32, 4, Color.RayWhite);
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
        //It draws a muliline text in a more appealing manner ( avoids overlapping)
        string[] splitText = splitString(textToDraw, '\n');
        for (int i = 0; i < int.Parse(splitText[^1]); i++) {
            Raylib.DrawText(splitText[i], xPos - Raylib.MeasureText(splitText[i], textSize)/2, yPos + i * textSize + i* spacing, textSize, color);
        }

    }
    static void draw() {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText($"({Raylib.GetMousePosition().ToString()})", 12, 12, 20, Color.White);
            Raylib.DrawText($"({Raylib.GetFPS().ToString()})", 160, 12, 20, Color.White);
            player.Draw();
            computer.Draw();
            ball.Draw();
            DrawScore(scores[0], scores[1]);

            Raylib.EndDrawing();
    }
    static void update() {
        // if (frame == 60) {
        //     frame = 0;
        // }
        // if (frame % 3 == 0) {

        // }
        if (Raylib.IsKeyDown(KeyboardKey.Down)) {
            player.Move(1);
        }
        if (Raylib.IsKeyDown(KeyboardKey.Up)) {
            player.Move(-1);
        }

        // frame += 1;
    }

    public static void Main()
    {
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Hello World");
        Raylib.SetTargetFPS(120);

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