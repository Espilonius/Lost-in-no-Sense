public interface ICombineChecker
{
    bool CanCombine(ItemBase ingredient1, ItemBase ingredient2, ItemBase leftHandItem, ItemBase rightHandItem);
}
