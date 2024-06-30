namespace IndexersApp;

public class NamesCollection
{
    private string[] names;

    public string this[string nameToChange]
    {
        set
        {
            int index = 0;
            for (index = 0; index < names.Length; index++)
            {
                if(names[index].ToLower() == nameToChange)
                    break;
            }

            if(index == names.Length)
                return;

            names[index] = value;
        }
    }

    public string? this[uint index] => this.GetCapitalizedName(index);

    public NamesCollection(string[] names)
    {
        this.names = names;
    }

    public string? GetCapitalizedName(uint index)
    {
        if(index >= this.names.Length)
            return null;

        string foundName = this.names[index];

        if(foundName.Length <= 1)
            return null;

        return char.ToUpper(foundName[0]) + foundName.ToLower()[1..];
    }
}