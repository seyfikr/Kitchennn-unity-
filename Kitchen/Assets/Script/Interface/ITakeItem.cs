public enum ItemType
{
    TOMATO,LETTUCE,CHEESE,BREAD,MEAT,PLATE,NONE
}
public interface ITakeItem 
{
    public ItemType GetItem();
}
