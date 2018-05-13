<Query Kind="Program" />

void Main()
{
	var rectangle = new Rectangle
	{
		Height = 5,
		Width = 10
	};
	rectangle.Grow(10, 10);
	
	rectangle.Dump("rectangle");
	
	var iRectangle = new ImmutableRectangle(5, 10);

	var iRectangle2 = iRectangle.Grow(10, 10);
	iRectangle.Dump("iRectangle");
	iRectangle2.Dump("iRectangle2");
}

public class Rectangle
{
	public int Height { get; set; }
	public int Width { get; set; }
	
	public void Grow(int height, int width)
	{
		Height += height;
		Width += width;
	}
}

public class ImmutableRectangle
{
	public ImmutableRectangle(int height, int width)
	{
		Height = height;
		Width = width;
	}

	public int Height { get; }
	public int Width { get; }

//	public ImmutableRectangle Grow(int height, int width) => 
//		new ImmutableRectangle(Height + height, Width + width);
}

public static class ImmutableRectangleExt
{
	public static ImmutableRectangle Grow(this ImmutableRectangle rectangle, int height, int width)
	{
		return new ImmutableRectangle(rectangle.Height + height, rectangle.Width + width);
	}
}
