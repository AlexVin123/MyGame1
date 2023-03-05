using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parameter
{
    public int Lvl { get; private set; }
    public TypeParameter TypeParameter { get; private set; }

    public string Value { get; private set; }

    public Parameter(int lvl, TypeParameter type, string value)
    {
        TypeParameter = type;
        Lvl = lvl;
        Value = value;
    }
}
