public enum ItemType
{
    TOMATO, LETTUCE, CHEESE, BREAD, MEAT, PLATE, NONE, SILICETOMATO, SILICELETTUCE, SILICECHEESE, SILICEBREAD, COOKEDMEAT
}
public interface ITakeItem
{
    public ItemType GetItem();
}
