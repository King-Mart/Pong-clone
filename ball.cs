using Raylib_cs;

class Ball {
    int positionX;
    int  positionY;
    int radius = 8;
    public Ball(int xPos, int ScreenHeight) {
        positionX = xPos;  
        positionY = ScreenHeight/2;
    }
    
    public void Draw() {
        Raylib.DrawRectangle(positionX - radius/2, positionY - radius/2, radius, radius, Color.RayWhite);
    }
}
