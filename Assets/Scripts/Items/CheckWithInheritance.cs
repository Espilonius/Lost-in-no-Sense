using UnityEngine;

public class CheckWithInheritance : MonoBehaviour, ICombineChecker
{
    public bool CanCombine(ItemBase ingredient1, ItemBase ingredient2, ItemBase leftHandItem, ItemBase rightHandItem)
    {
        if (CheckHand(leftHandItem, ingredient1) && CheckHand(rightHandItem, ingredient2))
        {
            return true;
        }
        else if (CheckHand(leftHandItem, ingredient2) && CheckHand(rightHandItem, ingredient1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckHand(ItemBase hand, ItemBase ingredient)
    {
        return ingredient.GetType().Equals(hand.GetType());
    }
}
