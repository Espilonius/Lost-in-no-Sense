using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item List", menuName = "Game/ItemList")]
public class CombineItemsList : ScriptableObject
{
    [SerializeField] private CombineRecipe[] combineRecipes;
    
    public CombineRecipe[] CombineRecipes { get => combineRecipes; }
}

[System.Serializable]
public class CombineRecipe
{
    public GUIContent item;
    public ItemBase Ingredient1 { get => ingredient1.GetComponent<ItemBase>();  }
    public ItemBase Ingredient2 { get => ingredient2.GetComponent<ItemBase>(); }
    public ItemBase Product { get => product.GetComponent<ItemBase>(); }

    [SerializeField] private GameObject ingredient1;
    [SerializeField] private GameObject ingredient2;
    [SerializeField] private GameObject product;
}
