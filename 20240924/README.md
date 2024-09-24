# 2024-09-23 유니티 학습

**##아는 문법은 생략##**

## 1. C# 기초 문법

- **간단한 자료형 (int, int?, float, long, bool, string 등)**

```csharp
  int? n = null; //널러블 타입
```

- **간단한 연산자 ( ??, ||, &&, &, | 등)**

```csharp
 Debug.Log(s1 ?? s2); //s1이 NULL이면 s2를, 반대면 s1을 반환한다.
```

- **조건 제어문**

```csharp
foreach(int i in arr)
{
    Debug.Log(i);
}
```

- **배열, 다차원 배열, 가변 배열**

```csharp
 //배열 선언
 int[] arr = new int[5];
 int[] arr = {1, 2, 3, 4, 5};
 
 //다차원 배열 선언
 int[,] arr = new int[2, 2];
 int[,] arr = {{1, 2}, {1, 2}};
 Debug.Log(arr[0, 0]);
 
 //가변 배열 선언
 int[][] arr = new int[4][]; //각 배열의 크기가 다를 수 있다는 뜻
 arr[0] = new int[2];
 arr[1] = new int[3];
 arr[2] = new int[4];
 arr[3] = new int[5]; //각각 다시 초기화 시켜줘야함
 Debug.Log(arr[0][0]);
```

## 2. C# 기초 문법 응용 문제

![image](https://github.com/user-attachments/assets/45a424db-b9ec-4a7d-8ea0-781700eed245)


```csharp
//problem 1
int a = 1;
int b = 2;

for (int i = 0; i < 10; i++)
{
    Debug.Log(a);
    a *= b;
}
```

![image](https://github.com/user-attachments/assets/7b7b8b6e-ec50-4224-aec8-6fa791bfe4c1)


```csharp
using System;
//problem 3
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Array.Reverse(arr);

foreach(int i in arr)
{
    Debug.Log(i);
}
```

![image](https://github.com/user-attachments/assets/61e30c32-7b14-446e-9808-b1e9cd6b31a7)


```csharp
//problem 4
bool[, ] isBig = new bool[5, 5];
for (int i = 0; i < isBig.GetLength(0); i++)
{
    for (int j = 0; j < isBig.GetLength(1); j++)
    {
        isBig[i, j] = i > j;
        Debug.Log(isBig[i, j]);
    }
}
```

![image](https://github.com/user-attachments/assets/8bd22a39-1452-4ae4-af9d-718800cfb36c)


```csharp
//problem 8
int[, ] arrA = { { 1, 2 }, { 3, 4 } };
int[, ] arrB = { { 1, 2 }, { 3, 4 } };

int[, ] arrC = new int[2, 2];
int[, ] arrD = new int[2, 2];

for (int i = 0; i < arrC.GetLength(0); i++)
{
    for (int j = 0; j < arrC.GetLength(1); j++)
    {
        arrC[i, j] = arrA[i, j] + arrB[i, j];
        Debug.Log(arrC[i, j]);
    }
}

for (int i = 0; i < arrC.GetLength(0); i++)
{
    for (int j = 0; j < arrC.GetLength(1); j++)
    {
        for (int k = 0; k < arrC.GetLength(1); k++)
        {
            arrD[i, j] += arrA[i, k] * arrB[k, j];
        }
        Debug.Log(arrC[i, j]);
    }
}
```

![image](https://github.com/user-attachments/assets/f4bb5310-9372-4c3d-8020-a0ff21d883ee)


```csharp
//problem 9
int[, ] arrE = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
int[, ] arrF = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

int[, ] arrG = new int[3, 3];
int[, ] arrH = new int[3, 3];

for (int i = 0; i < arrG.GetLength(0); i++)
{
    for (int j = 0; j < arrG.GetLength(1); j++)
    {
        arrG[i, j] = arrE[i, j] + arrF[i, j];
        Debug.Log(arrG[i, j]);
    }
}

for (int i = 0; i < arrH.GetLength(0); i++)
{
    for (int j = 0; j < arrH.GetLength(1); j++)
    {
        for (int k = 0; k < arrH.GetLength(1); k++)
        {
            arrH[i, j] += arrE[i, k] * arrF[k, j];
        }
        Debug.Log(arrH[i, j]);
    }
}
```

![image](https://github.com/user-attachments/assets/0265c127-ce1d-4b0f-9585-e753213d3821)


```csharp
using System;
//problem 10
int[] arrSort = { 4, 5, 1, 2, 6, 3 };
Array.Sort(arrSort);
foreach (int i in arrSort)
{
    Debug.Log(i);
}
```
