using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Employee
{
    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public virtual int Money()
    {
        return 100;
    }
}
public class FullTime : Employee
{
    public FullTime(string name) : base(name) { }

    public override int Money()
    {
        return base.Money();
    }
}

public class PartTime : Employee
{
    int time;
    public PartTime(string name, int time) : base(name)
    {
        this.time = time;
    }

    public override int Money()
    {
        return time * 10;
    }
}


public class Problem3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FullTime minsoo = new FullTime("¹Î¼ö");
        PartTime somin = new PartTime("¼Ò¹Î", 20);

        Debug.Log(minsoo.Money());
        Debug.Log(somin.Money());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
