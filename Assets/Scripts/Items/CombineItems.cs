using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using static UnityEditor.Progress;

public class CombineItems : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private ItemListSO itemListSO = default;

    [SerializeField] CombineItemsList combineRecipes = default;
    [SerializeField] CombineMode combineMode;

    [SerializeField] private GameObject player;
    private PlayerInteraction playerInteraction;
    private ItemBase playerLeftHandItem;
    private ItemBase playerRightHandItem;
    private ICombineChecker combineChecker;

    public event UnityAction<string[]> onCombined;
    public event UnityAction<GameObject> onCombineChoice;
    public event UnityAction onFinishCombine;

    private const int minRecipes = 0;

    private void OnEnable()
    {
        inputReader.combineEvent += Combine;
        combineMode.onFinishCombine += FinishCombine;
    }
    private void OnDisable()
    {
        inputReader.combineEvent -= Combine;
        combineMode.onFinishCombine -= FinishCombine;
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
        EnableCombineMode(recipes);
        return recipes.ToArray();
    }
    private void EnableCombineMode(List<string> recipes)
    {
        if (recipes.Count <= minRecipes) return;
        inputReader.EnableCombineMode();
    }

    private void GetCombineProductItem(CombineCloud combineCloud)
    {
        string itemName = combineCloud.GetName();
        GameObject item = itemListSO.GetItem(itemName);
        if (item == null) return;
        SendEventMessagesEndCombine(item);
    }
    private void SendEventMessagesEndCombine(GameObject item)
    {
        onCombineChoice?.Invoke(item);
        onFinishCombine?.Invoke();
    }

    //Event method
    public void Combine()
    {
        GetPlayerItems();
        if (!CheckItems()) return;
        onCombined?.Invoke(CheckRecipes());
    }
    public void FinishCombine(CombineCloud combineCloud)
    {
        if (combineCloud == null) return;
        GetCombineProductItem(combineCloud);
    }
}