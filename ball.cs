using System.Numerics;
using Raylib_cs;

class Ball {
    const int SPEED = 3;
    Vector2 position ;

    Vector2 speed = new Vector2(-SPEED,0);
    float initialX;
    float initialY;
    int radius = 8;
    public Ball(int xPos, int ScreenHeight) {
        initialX = (float)xPos;
        initialY = (float)(ScreenHeight/2);
        position = new Vector2(initialX, initialY);
    }
    public void Reset() {
        position = new Vector2(initialX, initialY);
        speed = new Vector2(-SPEED, 0);
    }
    
    public void Draw() {
        Raylib.DrawRectangle((int)position.X, ((int)position.Y) - radius / 2, radius, radius, Color.RayWhite);
    }
    public void Move() {
        position += speed;
    }
    public int checkCollision(Paddle paddleLeft, Paddle paddleRight) {
        //This method will check if the ball collided with the paddle, if it didn't, it'll reset and then well havethe score updated
        //Returns 0 if no score update, 1 if the left paddle scored and 2 if the right one did
        if ((position.X + speed.X ) <= 48 && position.X + speed.X >= (48-SPEED)) {
            if (position.Y > (paddleLeft.positionY - radius) && position.Y < (paddleLeft.positionY + paddleLeft.height)) {
                position.X = 48;
                speed = new Vector2(-speed.X, paddleLeft.speed.Y + speed.Y);
                // Console.WriteLine(speed.ToString());
                // Console.WriteLine($"left paddle speed : {paddleLeft.speed.ToString()}");
            }
            else {return 1;}
        }
        if ((position.X + speed.X) >= 760 && position.X + speed.X <= (760 + SPEED)) {
            if (position.Y > (paddleRight.positionY - radius) && position.Y < (paddleRight.positionY + paddleRight.height)) {
                position.X = 760;
                speed = new Vector2(-speed.X, paddleRight.speed.Y + speed.Y);
                // Console.WriteLine(speed.ToString());
                
                // Console.WriteLine($"right paddle speed : {paddleRight.speed.ToString()}");
            }
            else {return 2;}

        }

        //TOP COLLISION
        if ((position.Y + speed.Y ) < (0) ) {
            Console.WriteLine(speed.ToString());
            position.Y = 0;
            speed = new  Vector2(speed.X, -speed.Y);

        }
        if ((position.Y + speed.Y) > (400 - radius)) {
            Console.WriteLine(speed.ToString());
            position.Y = 400 - radius;
            speed = new  Vector2(speed.X, -speed.Y);
        }
        return 0;
    }
}
