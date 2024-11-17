using System.Reflection.Metadata;
using Raylib_cs;

class Paddle {
    int positionX;
    int  positionY;
    int height = 60;
    public Paddle(int xPos, int ScreenHeight) {
        positionX = xPos;  
        positionY = ScreenHeight / 2 ;
    }
    public void Draw() {
        Raylib.DrawRectangle(positionX, positionY - height/2, 8, height, Color.RayWhite);
    }
    public void Move(int delta) {
        positionY += delta;
    }
}