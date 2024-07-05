namespace InterfacesApp.Interfaces;

interface ISecondInterface
{
    string Name { get; set; }
    void Method();
    public int MyMethodWithBody()
    {
        return 200;
    }
}