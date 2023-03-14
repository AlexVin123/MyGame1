using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataBase : ScriptableObject
{
    public abstract string GetParameter(TypeParameter parameter);
}
