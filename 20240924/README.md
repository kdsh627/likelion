# 2024-09-24 유니티 학습

**##아는 문법은 생략##**

## **1. C# 기초 문법**

- **List (컬렉션)**

```csharp
using System.Collections.Generic;

List<string> names = new List<string>(10); //선언

names.Add("Teeno");
names.Add("Ari");
names.Add("스웨인");
names.Add("제드");

names.Remove("제드"); //데이터로 제거
names.RemoveAt(1); //인덱스로 제거

names.Insert(0, "그라가스"); //원하는 인덱스에 삽입

Debug.Log(names.IndexOf("Ari")); //없으면 -1, 있으면 인덱스가 출력
Debug.Log(names.Count); //컬렉션에서는 Length가 아닌 Count를 사용

//해당 데이터가 존재하는가 반환
if (names.Contains("스웨인"))
{
    Debug.Log("있다");
}

//모든 값 출력
foreach (string name in names)
{
    Debug.Log(name);
}
```

- **Dictionary (컬렉션)**

```csharp
using System.Collections.Generic;

//선언
Dictionary<string, string> cities = new Dictionary<string, string>();

cities.Add("한국", "서울");
cities.Add("쿠바", "하바나");
cities["한국"] = "부산"; //인덱스로 접근 시 대체되지만 Add로는 중복 불가

Debug.Log(cities.Count); //컬렉션은 Length대신 Count

//해당 키가 존재하는가
if (!cities.ContainsKey("한국"))
{
    Debug.Log("있다");
}

//꺼내는 방식
foreach (string key in cities.Keys)
{
    Debug.Log(cities[key]);
}

//꺼내는 방식2
foreach (KeyValuePair<string, string> pair in cities)
{
    Debug.Log(pair.Key + " : " + pair.Value);
}
```

- **함수**

```csharp
//함수
void Like()
{
    Debug.Log("좋아요 눌러주세요");
}

//인자는 왼쪽부터 받아오므로 디폴트 값은 오른쪽부터 채워야한다.
//명시해주던 말던 오른쪽부터 안채우면 오류가 난다.
float Area(float width, float height = 10)
{
    return width * height;
}

//ref를 통해 매개변수를 복사가 아닌 참조로 넘길 수 있음
//꼭 값을 바꿀 필요는 없음
float AreaRef(ref float width, float height)
{
    width = 15f;
    return width * height;
}

//ref와 다른 점은 여러 리턴 값을 받을 때 사용한다는 점
//그리고 초기화를 안해줘도 됨
//대신 out은 꼭 값을 바꿔줘야한다. 값을 돌려받기 위해 사용하는 것이기 때문(리턴의 개념)
void AreaOut(float width, float height, out float around)
{
    around = width * height;
}

void Start()
{
    float x = 10f;
    float y = 20f;
    float area = Area(x, y);
    float area2 = Area(height: y, width: x); //C#에서는 인자와 매개변수를 명시할 수 있다.

    //ref를 명시해주면 x는 바꿀 수 있음
    //ref는 초기화가 된 변수를 넘겨줘야 함
    float area3 = AreaRef(ref x, y);

    float around;
    //out은 초기화가 안되어도 넘길 수 있음
    AreaOut(x, y, out around);


    Debug.Log(area);

    Like();
}
```

- **구조체**

```csharp
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

    HumanData charles = new HumanData("철수", 100f, 180f, 280f);
    charles.name = "철수";
    charles.weight = 100f;
    charles.height = 180f;
    charles.footSize = 280f;

}
```

- **클래스**

```csharp
public class Character
{
    //멤버변수
    public string Name;
    public int Hp;

    //생성자
    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }


    //메소드
    public void Hit(int damage)
    {
        Hp -= damage;
    }

    public void Heal(int heal)
    {
        Hp += heal;
    }

    public bool isAlive()
    {
        return Hp > 0;
    }

    public void Eat(Food food)
    {
        if(isAlive())
        {
            Hp += food.Hp;
        }
    }
}
```

```csharp
public class Food
{
    public string Name;
    public int Hp;
}
```

```csharp
public class Wizard : Character
{
    public int Mp;
    
    public Wizard(string name, int hp, int mp) : base(name, hp)//부모의 생성자를 가져다 쓴다는 뜻
    {
        Mp = mp;
    }

    public void UseMagic()
    {
        if(Mp >= 5)
        {
            Mp -= 5;
            Debug.Log("마법 뿅뿅");
        }
    }
}
```
```csharp
void Start()
{
    Character character = new Character("철수", 10);
    Food food1 = new Food();
    food1.Name = "Protein";
    food1.Hp = 10;

    character.Hit(5);
    character.Heal(3);
    character.Eat(food1);

    Debug.Log(character.isAlive());


    Wizard wizard = new Wizard("영희", 10, 10);
    wizard.UseMagic();
    wizard.Hit(3);
    wizard.Heal(3);
    wizard.Hit(20);
    Debug.Log(wizard.isAlive());


    Character tmp = wizard as Character; //Wizard 클래스가 Character의 일종이기에 이게 가능함
                                         //하지만 Wizard관련 함수는 못씀

    Debug.Log(tmp); //캐릭터에 집어넣어도 위저드라고 출력된다.

    ((Wizard)tmp).UseMagic(); //캐릭터 클래스지만 위자드로 타입캐스팅을 하여 관련 함수를 
                              //사용할 수 있게 한 모습

    Character char1 = new Character("누구", 10);

    ((Wizard)char1).UseMagic(); //코드 상으로는 에러가 없지만 실행 시 에러가 난다
                                //타입 캐스팅이 실패하기 때문
                                //유니티에서는 에러 발생 시 함수 실행을 중단하고 리턴한다.

    Debug.Log(char1 is Wizard); //캐스팅이 가능하면 true, 불가능하면 false를 리턴한다.
    Wizard wizard2 = char1 as Wizard; //좀 더 안전하게 캐스팅하는 방법
                                      //캐스팅 실패 시 NULL이 들어간다.

    //포함관계를 잘 보자.
    //상속관계에서 자식은 부모가 될 수 있지만 반대는 불가능하다.
    //고등어는 생선이라고 부를 수 있지만 생선은 고등어라고 부를 수 없다는 것
}
```

## 2. C# 기초 문법 응용 문제

![image](https://github.com/user-attachments/assets/eff03174-f31a-4a5f-a88c-50fbb553c95a)

```csharp

```

![image](https://github.com/user-attachments/assets/e012180b-548b-49cc-abf8-70b6236ecc7f)


```csharp

```

![image](https://github.com/user-attachments/assets/db03e4f2-97a5-4ee0-a2fd-8830f0d99c1a)


```csharp

```

![image](https://github.com/user-attachments/assets/0bc8ccee-5337-49e0-9315-0243149fb8ba)


```csharp

```

![image](https://github.com/user-attachments/assets/bbe42acb-e3aa-4d28-97d8-e78df068a707)


```csharp

```

![image](https://github.com/user-attachments/assets/c9582892-f754-4c35-ade2-9dfd2dd18a22)


```csharp

```

![image](https://github.com/user-attachments/assets/69edc406-553c-4eab-9ec2-bf2fc1d1e235)


```csharp

```
