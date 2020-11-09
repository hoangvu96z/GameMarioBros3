namespace EditorV4.EditorObjects
{
    public interface IObjectsManager
    {
        void AddObjectCategory(GameObjectCategory objectCategory);
        void RemoveObjectCategory(GameObjectCategory objectCategory);
        void AddGameObject(GameObject gameObject);
        void RemoveGameObject(GameObject gameObject);
    }
}
