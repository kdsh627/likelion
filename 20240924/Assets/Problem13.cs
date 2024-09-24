using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueClass
{
    Queue<int> queue;

    public QueueClass()
    {
        queue = new Queue<int>();
    }

    public void Push(int data)
    {
        queue.Enqueue(data);
    }

    public int Pop() 
    { 
        return queue.Dequeue();
    }
}


public class Problem13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QueueClass queueClass = new QueueClass();
        queueClass.Push(9);
        queueClass.Push(7);
        queueClass.Push(5);
        queueClass.Push(1);

        Debug.Log(queueClass.Pop());
        Debug.Log(queueClass.Pop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
