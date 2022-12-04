namespace AdventOfCode.Year2018.Model
{
    public class ChangingVector
    {
        public Vector Location { get; private set; }
        public Vector Change { get; private set; }

        public ChangingVector(int x, int y, int changeX, int changeY)
        {
            Location = new Vector(x, y);
            Change = new Vector(changeX, changeY);
        }

        public void GoStep()
        {
            Location.X += Change.X;
            Location.Y += Change.Y;
        }

        public void GoNSteps(int n)
        {
            Location.X += Change.X * n;
            Location.Y += Change.Y * n;
        }

        public override string ToString()
        {

            return Location.X + " " + Location.Y + " " + Change.X + " " + Change.Y;
        }
    }
}
