using StructsApp;

MyStruct obj1 = new MyStruct()
{
    Num = 100,
    Obj = new MyClass()
    {
        Num = 777,
    },
};

MyStruct obj2 = obj1;
obj2.Num = obj1.Num;
obj2.Obj = obj1.Obj;

obj2.Obj.Num = 999;

Console.WriteLine(obj1.Obj.Num);



/*
var obj1 = new MyStruct();
obj1.Num = 100;

var obj2 = obj1;
obj2.Num = 777;

Console.WriteLine(obj1.Num);
*/

/*
var obj1 = new MyClass();
obj1.Num = 100;

var obj2 = obj1;
obj2.Num = 777;

Console.WriteLine(obj1.Num);
Console.WriteLine(obj2.Num);
*/