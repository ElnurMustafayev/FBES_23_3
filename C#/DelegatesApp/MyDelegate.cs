namespace DelegatesApp;

public delegate void MyDelegate(int num);

public delegate bool CheckNumbersDelegate(int num1, int num2);

public delegate bool CheckWordDelegate(string word);

public delegate T PrintSomethingDelegate<T>(T obj);

//class User<T>
//{
//    public string Fullname { get; set; }
//}