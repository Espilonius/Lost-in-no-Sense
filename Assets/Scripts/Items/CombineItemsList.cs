using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineItemsList : MonoBehaviour
{
    [SerializeField] private CombineRecipe[] combineRecipes;
    
    public CombineRecipe[] GetCombineRecipes()
    {
        return combineRecipes;
    }
}

[System.Serializable]
public class CombineRecipe
{
    public GUIContent item;
    public ItemBase ingredient1;
    public ItemBase ingredient2;
    public ItemBase product;
}
