#region

using UnityEngine;
using Zenject;

#endregion

public class MonoBehaviourForInterface : MonoBehaviour
{
#region Private Variables

    [Inject]
    private I_A a = I_A.Default;

#endregion

#region Unity events

    private void Start()
    {
        a = new Class_A();
        a.Log();
        a = new Class_B();
        a.Log();
        Remove_A();
        a.Log();
    }

#endregion

#region Private Methods

    private void Remove_A()
    {
        a = I_A.Default;
    }

#endregion
}

class Class_A : I_A
{
#region Public Methods

    public void Log()
    {
        Debug.Log($"Class_A");
    }

#endregion
}

internal interface I_A
{
#region Public Variables

    static I_A Default => new Default_I_A();

#endregion

#region Private Variables

    private class Default_I_A : I_A
    {
    #region Public Methods

        public void Log() { }

    #endregion
    }

#endregion

#region Public Methods

    void Log()
    {
        Debug.Log($"I_A");
    }

#endregion
}

class Class_B : I_A
{
#region Public Methods

    public void Log()
    {
        Debug.Log($"Class_B");
    }

#endregion
}