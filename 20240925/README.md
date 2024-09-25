# 2024-09-25 유니티 학습

**##아는 문법은 생략##**

## 1. C# 기초 문법

- **문자열**

```csharp
string str1 = "   dddd     ";

Debug.Log(str1.Trim()); //앞 뒤 공백 제거

string str2 = "ABA";

Debug.Log(str2.Replace("A", "B")); //문자열 대체
```

- **오버라이딩**

```csharp
public class Character
{
    public int Hp;
    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }
    //오버라이드(덮어쓰기)를 위해서 virtual 키워드를 써준다
    public virtual void Hit(int damage)
    {
        Hp -= damage;
    }
}

public class Wizard : Character
{
    public int Mp;
    public Wizard(string name, int hp, int mp) : base(name, hp)
    {
        Mp = mp;
    }
    public override void Hit(int damage) //오버라이드
    {
        //base.Hit(damage); <-이건 부모함수도 실행함

        //이러면 클래스에 따라서 부르는 함수가 다름
        Debug.Log("물리 면역 입니다");
    }
    //virtual을 쓰지않아도 new키워드를 override대신 사용하여 비슷한 효과를 낼 수 있다.
    //new는 기존에 있던 것을 지우고 새롭게 함수를 정의한다는 뜻
}

void Start()
{
    Wizard wiz = new Wizard("법사", 10, 5);
    wiz.Hit(5); //오버라이드된 함수 실행

    Character minsoo = wiz as Character;
    minsoo.Hit(5);//이래도 오버라이드된 함수 실행 
                  //하지만 new를 사용시 그냥 Character클래스 함수 사용
                  //new는 타입을 보고 virtual은 본질을 본다
}
```

- **오버로딩**

```csharp
public class Character
{
    public string Name;
    protected int Hp; //상속관계에 있는 객체만 사용가능
    
    public Character()
    {

    }

    public Character(string name, int hp)
    {
        Name = name;
        Hp = hp;
        N = 5;
    }
    //오버로드는 인자의 타입, 개수에 따라서 같은 함수명으로 사용가능하다
    public void Hit(int damage, int n)
    {
        Hp -= (damage*n);
    }
		//위의 함수와 함수명은 같지만 인자의 개수가 다른 경우
    public void Hit(int damage)
    {
        Hp -= damage);
    }
}

```

- **추상클래스**

```csharp
public abstract class Animal
{
    //추상클래스 : 큰 틀을 만들고 세부내용을 자식들이 구현하는 경우 사용한다
    //인스턴스화는 불가능

    public abstract void Fly(); //이름만 있는 추상 메소드

    public void introduce()
    {
        Debug.Log("안녕하세요 짐승입니다");
    }
}

public class Bird : Animal
{
    public override void Fly()
    {
        Debug.Log("퍼덕퍼덕");
    }
}

public class Bug : Animal
{
    public override void Fly()
    {
        Debug.Log("위잉위잉");
    }
}

```

- **인터페이스**

```csharp
//인터페이스는 어떠한 메소드가 있기로 했다는 약속
public interface ITurnOnable
{
    //인터페이스는 멤버 변수, 메소드 구현 안해도됨
    public void TurnOn();
    public void TurnOff();
}

public class TV : ITurnOnable //인터페이스 상속 시 약속한 메소드를 반드시 구현해야함
{
    public void TurnOff()
    {
        Debug.Log("리모컨 버튼끄기");
    }

    public void TurnOn()
    {
        Debug.Log("리모컨 버튼켜기");
    }
}

public class Car : ITurnOnable
{
    public void TurnOff()
    {
        Debug.Log("차 키를 넣어");
    }

    public void TurnOn()
    {
        Debug.Log("차 키를 돌려");
    }
}

void Start()
{
    //C#에서는 다중 상속이 불가능 하지만, 인터페이스는 다중으로 받을 수 있음
    Car car = new Car();
    car.TurnOn();//Car클래스의 TurnOn 실행

    ITurnOnable anObject = car;

    anObject.TurnOff();//Car클래스의 TurnOff 실행
}
```

- **static**

```csharp
public class Character
{
    //static의 경우 모든 CHaracter객체가 공유하는 값이다.
    //인스턴스 함수에서는 접근가능하다.
    static int num = 0;

    public string Name;
    protected int Hp; //상속관계에 있는 객체만 사용가능
    private int N;

    //static함수 및 변수는 객체 생성전에도 호출 가능하다.
    public static void abc()
    {
        num++;
        //Name = "응애"; <- static함수에서는 멤버변수를 부를 수 없다.
    }
}

```

- **getter, setter**

```csharp
public class Character
{
    private int Hp;

    public int HP
    { 
        get { return HP; } 
        set { Hp = value; }
    }
}

void Start()
{
    Character charles = new Character("철수", 10);

    charles.HP = 10; //setter
    Debug.Log(charles.HP); //getter
}
```

## 2. C# 기초 문법 응용 문제

![image](https://github.com/user-attachments/assets/d9403398-87f7-4797-8af9-c5d85ba80d97)


```csharp

```

![image](https://github.com/user-attachments/assets/0ffb9136-9b8d-4f9b-9e4a-b5509707acb8)


```csharp

```

![image](https://github.com/user-attachments/assets/a15cd7eb-4a98-4e96-8079-57bd46373354)


```csharp

```

![image](https://github.com/user-attachments/assets/7173a62a-322d-411c-a1fb-ec5d6a281366)


```csharp

```
