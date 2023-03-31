using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombineItems : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    [SerializeField] CombineItemsList combineRecipes = default;

    [SerializeField] private GameObject player;
    private PlayerInteraction playerInteraction;
    private ItemBase playerLeftHandItem;
    private ItemBase playerRightHandItem;
    private ICombineChecker combineChecker;

    public event UnityAction<string[]> onCombined;

    private void OnEnable()
    {
        inputReader.combineEvent += Combine;
    }
    private void OnDisable()
    {
        inputReader.combineEvent -= Combine;
    }
    private void Start()
    {
        combineChecker = GetComponent<ICombineChecker>();
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    private void GetPlayerItems()
    {
        playerLeftHandItem = playerInteraction.GetLeftHandItem();
        playerRightHandItem = playerInteraction.GetRightHandItem();
    }
    private bool CheckItems()
    {
        if (!playerLeftHandItem || !playerRightHandItem) return false;
        return true;
    }
    private string[] CheckRecipes()
    {
        List<string> recipes = new List<string>();

        foreach (CombineRecipe r in combineRecipes.CombineRecipes)
        {
            if (combineChecker.CanCombine(r.Ingredient1, r.Ingredient2, playerLeftHandItem, playerRightHandItem))
            {
                recipes.Add(r.Product.GetName());
            }
        }
        return recipes.ToArray();
    }

    //Event method
    public void Combine()
    {
        GetPlayerItems();
        if (!CheckItems()) return;
        onCombined?.Invoke(CheckRecipes());
    }
}