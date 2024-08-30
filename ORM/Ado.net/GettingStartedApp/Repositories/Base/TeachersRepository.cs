using GettingStartedApp.Entities;

namespace GettingStartedApp.Repositories.Base;

public abstract class TeachersRepository
{
    public abstract bool Insert(Teacher teacher);
    public abstract int Count();
    public abstract bool Delete(int id);
    public abstract IEnumerable<Teacher> Select();
}