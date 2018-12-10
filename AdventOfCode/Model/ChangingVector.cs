namespace AdventOfCode.Model {
  public class ChangingVector {
    public Vector location;
    public Vector change;


    public ChangingVector(int x, int y, int changeX, int changeY)
    {
      this.location = new Vector(x, y);
      this.change = new Vector(changeX, changeY);
    }

    public void goStep()
    {
      this.location.x += this.change.x;
      this.location.y += this.change.y;
    }

    public void goNSteps(int n)
    {
      this.location.x += this.change.x * n;
      this.location.y += this.change.y * n;
    }

    public override string ToString()
    {

      return this.location.x + " " + this.location.y + " " + this.change.x + " " + this.change.y;
    }
  }
}
