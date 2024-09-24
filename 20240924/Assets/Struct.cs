using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struct : MonoBehaviour
{
    struct HumanData
    {
        public string name;
        public float weight;
        public float height;
        public float footSize;

        public HumanData(string name, float weight, float height, float footsize)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            this.footSize = height;
        }
    }

    void Start()
    {
        HumanData[] humanDatas = new HumanData[5];

        HumanData charles = new HumanData("Ã¶¼ö", 100f, 180f, 280f);
        charles.name = "Ã¶¼ö";
        charles.weight = 100f;
        charles.height = 180f;
        charles.footSize = 280f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
