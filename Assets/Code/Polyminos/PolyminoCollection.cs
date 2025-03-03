using System.Collections;
using System.Collections.Generic;

public abstract class PolyminoCollection
{   
    public Polymino[] polyminoes { get; protected set; }
    public Polymino this[int index] => polyminoes[index];

    //----------------------------------------------------------------
    abstract protected void InitializeCollection();
}