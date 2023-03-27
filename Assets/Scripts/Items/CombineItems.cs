using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineItems : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private CombineRecipe[] combineRecipes;

    [SerializeField] private GameObject player;
    private Rigidbody playerLeftHandItem;
    private Rigidbody playerRightHandItem;

    private void OnEnable()
    {
        inputReader.combineEvent += Combine;
    }
    private void OnDisable()
    {
        inputReader.combineEvent -= Combine;
    }
    private void Awake()
    {
        combineRecipes = this.GetComponent<CombineItemsList>().GetCombineRecipes();
    }

    private void GetPlayerItems()
    {
        playerLeftHandItem = player.GetComponent<PlayerInteraction>().GetLeftHandItem();
        playerRightHandItem = player.GetComponent<PlayerInteraction>().GetRightHandItem();
    }
    private bool CheckItems()
    {
        if (!playerLeftHandItem || !playerRightHandItem) return false;
        return true;
    }
    private List<string> CheckRecipes()
    {
        List<string> recipes = new List<string>();

        foreach (CombineRecipe combineRecipe in combineRecipes)
        {
            if (combineRecipe.ingredient1.gameObject == playerLeftHandItem.gameObject)
            {
                if (combineRecipe.ingredient2.gameObject == playerRightHandItem.gameObject)
                {
                    recipes.Add(combineRecipe.product.GetName());
                }
            }
            else if (combineRecipe.ingredient2.gameObject == playerLeftHandItem.gameObject)
            {
                if (combineRecipe.ingredient1.gameObject == playerRightHandItem.gameObject)
                {
                    recipes.Add(combineRecipe.product.GetName());
                }
            }
        }

        return recipes;
    }

    private void ActivateClouds()
    {
        player.GetComponent<CombineIdeaCloudsActivate>().ActivateClouds(CheckRecipes());
    }

    //Event method
    public void Combine()
    {
        GetPlayerItems();
        if (!CheckItems()) return;
        ActivateClouds();
    }

    
}
