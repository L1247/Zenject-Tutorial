using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MonoBehaviourForInterface : MonoBehaviour 
{
    [Inject]
    private I_A a = I_A.Default;

    private void Start()
    {
        a = new Class_A();
        a.Log();
        a = new Class_B();
        a.Log();
        Remove_A();
        a.Log();
    }

    private void Remove_A()
    {
        a = I_A.Default;
    }
}

class Class_A : I_A 
{
    public void Log()
    {
        Debug.Log($"Class_A");
    } 
}

internal interface I_A
{
    void Log()
    {
        Debug.Log($"I_A");
    }
    static I_A Default => new Default_I_A();

    internal class Default_I_A : I_A
    {
        public void Log() { }
    }
}


class Class_B : I_A
{
    public void Log()
    {
        Debug.Log($"Class_B");
    }
}