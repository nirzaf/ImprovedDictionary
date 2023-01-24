// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

var myExistingClass = new MyClass();

var dictionary = new Dictionary<Guid, MyClass>()
{
    { myExistingClass.Id, myExistingClass }
};

var myNewClass = new MyClass();

/*
if(!dictionary.ContainsKey(myNewClass.Id))
{
    dictionary[myNewClass.Id] = myNewClass;
    // dictionary.Add(myNewClass.Id, myNewClass);
}

if(dictionary.TryGetValue(myNewClass.Id, out var val))
{
    val.Id = Guid.NewGuid();
}
*/

ref var valOrNew = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, myNewClass.Id, out var existed);

if(!existed)
{
    valOrNew = myNewClass;
}


if(!Unsafe.AreSame(ref valOrNew, ref myNewClass))
{
    valOrNew.Id = Guid.NewGuid();
}

if(!Unsafe.IsNullRef(ref valOrNew))
{
    valOrNew.Id = Guid.NewGuid();
}


public class MyClass
{
    public Guid Id { get; set; } = Guid.NewGuid();
}