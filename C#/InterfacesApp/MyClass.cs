namespace InterfacesApp;

using InterfacesApp.Interfaces;

class A // : IFirstInterface
{
    public void Method()
    {
        throw new NotImplementedException();
    }
}

class B : A, ISecondInterface
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public new void Method()
    {
        throw new NotImplementedException();
    }
}



class MyClass : IFirstInterface, ISecondInterface
{
    public string Name
    {
        get
        {
            return "Test";
        }
        set
        {

        }
    }

    public void Method()
    {
        IFirstInterface.MyMethodWithBody();
        Console.WriteLine("Method");
    }
}

struct MyStruct : IFirstInterface
{
    public void Method()
    {
        throw new NotImplementedException();
    }
}