using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackClass
{
    Stack<int> stack;
    
    public StackClass() 
    { 
        stack = new Stack<int>();
    }

    public void Add(int data)
    {
        stack.Push(data);
    }

    public int Pop()
    {
        return stack.Pop();
    }
}

public class Problem12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StackClass stackClass = new StackClass();
        stackClass.Add(0);
        stackClass.Add(1);
        stackClass.Add(21);

        Debug.Log(stackClass.Pop());
        Debug.Log(stackClass.Pop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
