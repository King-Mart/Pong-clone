using System.Numerics;
using Raylib_cs;

class Ball {
    const int SPEED = 3;
    Vector2 position ;

    Vector2 speed = new Vector2(-SPEED,0);
    int radius = 8;
    public Ball(int xPos, int ScreenHeight) {
        position = new Vector2((float)xPos, (float)(ScreenHeight/2));
    }
    
    public void Draw() {
        Raylib.DrawRectangle((int)position.X, ((int)position.Y) - radius / 2, radius, radius, Color.RayWhite);
    }
    public void Move() {
        position += speed;
    }
    public void checkCollision(Paddle paddleLeft, Paddle paddleRight) {
        if ((position.X + speed.X ) <= (48) ) {
            
            position.X = 48;
            speed = new Vector2(-speed.X, paddleLeft.speed.Y + speed.Y);
            Console.WriteLine(speed.ToString());
            Console.WriteLine($"left paddle speed : {paddleLeft.speed.ToString()}");

        }
        if ((position.X + speed.X) >= (760 + SPEED)) {
            if (position.Y > (paddleRight.positionY))
            position.X = 760;
            speed = new Vector2(-speed.X, paddleRight.speed.Y + speed.Y);
            Console.WriteLine(speed.ToString());
            
            Console.WriteLine($"right paddle speed : {paddleRight.speed.ToString()}");
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
    }
}
