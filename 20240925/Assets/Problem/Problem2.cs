using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    public abstract float Area();
}

public class Circle : Shape
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public override float Area()
    {
        return radius * radius * 3.14f;
    }
}

public class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override float Area()
    {
        return width * height;
    }
}

public class Problem2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Circle circle = new Circle(10);
        Rectangle rectangle = new Rectangle(5, 4);

        Debug.Log(circle.Area());
        Debug.Log(rectangle.Area());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
