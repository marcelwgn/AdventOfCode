namespace AdventOfCode2018.Model
{
    public class ChangingVector
    {
        public Vector location;
        public Vector change;


        public ChangingVector(int x, int y, int changeX, int changeY)
        {
            location = new Vector(x, y);
            change = new Vector(changeX, changeY);
        }

        public void goStep()
        {
            location.x += change.x;
            location.y += change.y;
        }

        public void goNSteps(int n)
        {
            location.x += change.x * n;
            location.y += change.y * n;
        }

        public override string ToString()
        {

            return location.x + " " + location.y + " " + change.x + " " + change.y;
        }
    }
}
