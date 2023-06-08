using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IngameObject
{
    private string name { get; set; }

    public IngameObject(string name)
    {
        this.name = name;
    }

    public void PrintName()
    {
          Debug.Log("Object's name: " + name);
    }
}
