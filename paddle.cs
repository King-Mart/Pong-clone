using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

class Paddle {
    int positionX;
    public int  positionY;
    int SPEED = 1;
    public Vector2 speed = new Vector2(0,0);
    public int height = 60;
    public Paddle(int xPos, int ScreenHeight) {
        positionX = xPos;  
        positionY = ScreenHeight / 2 - height/2;
    }
    public void Draw() {
        Raylib.DrawRectangle(positionX, positionY, 8, height, Color.RayWhite);
    }

    public void Move() {
        positionY += (int)speed.Y;
        
    }
    public void MoveKey(int upDownConstant) {
        speed = Vector2.Zero;
        speed.Y = SPEED * upDownConstant;
    }
    public void checkOutOfbonds() {
        if ((positionY + speed.Y ) < (0-height + SPEED) ) {
            positionY = 400;
            // speed = Vector2.UnitY * SPEED;

        }
        if ((positionY + speed.Y) > (400+ SPEED)) {
            positionY = 0 - height;
            // speed = -Vector2.UnitY * SPEED;
        }
    }
}