using EditorV4.Controls.PropertyGridModel;
using EditorV4.EditorObjects;
using EditorV4.Models.V2;
using EditorV4.UndoRedo.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo
{
    public interface IUndoRedoEvent
    {
        void OnAction();
    }
    [Serializable]
    public class UndoRedoManager
    {
        IUndoRedoEvent @interface;
        public Stack<BaseAction> UndoList { get; set; }
        public Stack<BaseAction> RedoList { get; set; }

        public UndoRedoManager(IUndoRedoEvent @interface)
        {
            UndoList = new Stack<BaseAction>();
            RedoList = new Stack<BaseAction>();
            this.@interface = @interface;
        }

        private void HandlePushAction(BaseAction action, bool perform = true)
        {
            if (perform)
            {
                action.PerformAction();
            }
            UndoList.Push(action);
            RedoList.Clear();
            this.@interface.OnAction();
        }

        public void AddObjectCategory(GameObjectCategory objectCategory, IObjectsManager objectManager)
        {
            var action = new AddObjectCategoryAction(objectCategory, objectManager);
            HandlePushAction(action);
        }
        public void AddGameObject(GameObject gameObject, IObjectsManager objectManager)
        {
            var action = new AddObjectAction(gameObject, objectManager);
            HandlePushAction(action);
        }

        public void AddRectangleObject(GameObject gameObject, IObjectsManager objectManager)
        {
            var action = new AddObjectAction(gameObject, objectManager);
            HandlePushAction(action, false);
        }
        public void RemoveObjectCategory(GameObjectCategory objectCategory, IObjectsManager objectManager)
        {
            var action = new RemoveObjectCategoryAction(objectCategory, objectManager);
            HandlePushAction(action);
        }
        public void RemoveGameObject(GameObject gameObject, IObjectsManager objectManager)
        {
            var action = new RemoveObjectAction(gameObject, objectManager);
            HandlePushAction(action);
        }
        public void ModifiedTile(int newTileIndex, int rIndex, int cIndex, TilesModel matrixObject)
        {
            var action = new ModifiledTileAction(newTileIndex, rIndex, cIndex, matrixObject);
            HandlePushAction(action);
        }

        public void SizingGameObject(Point ptBegin, Point ptEnd, int sizingValue, ISelectableObject shape)
        {
            if (ptBegin == ptEnd)
                return;
            var action = new GameObjectSizingAction(ptBegin, ptEnd, sizingValue, shape);
            HandlePushAction(action, false);
        }

        public void MovingGameObject(int moveX, int moveY, ISelectableObject shape)
        {
            if (moveX == moveY && moveX == 0)
                return;
            var action = new GameObjectMovingAction(moveX, moveY, shape);
            HandlePushAction(action, false);
        }

        public void PropertyChange(CustomClass currentObject, object oldValue, string propertyName)
        {
            var action = new PropertyChangeAction(currentObject, oldValue, propertyName);
            HandlePushAction(action, false);
        }

        public void AddProperty(CustomClass obj, string propertyName)
        {
            var action = new AddPropertyAction(obj, propertyName);
            HandlePushAction(action, false);
        }

        public void RemoveProperty(CustomClass obj, string propertyName)
        {
            var action = new RemovePropertyAction(obj, propertyName);
            HandlePushAction(action, false);
        }

        public void GroupObject(List<ISelectableObject> objects)
        {
            var action = new GroupObjectAction(objects);
            HandlePushAction(action);
        }
        public void UnGroupObject(GameObject @object)
        {
            var action = new UnGroupAction(@object);
            HandlePushAction(action);
        }

        public void MultiAction(List<BaseAction> actions)
        {
            var action = new GroupAction(actions);
            HandlePushAction(action);
        }

        public int UndoSize
        {
            get { return UndoList.Count; }
        }

        public int RedoSize
        {
            get { return RedoList.Count; }
        }

        public bool Undo()
        {
            if (UndoSize == 0)
                return false;
            var action = UndoList.Pop();
            action.PerformRevertAction();
            RedoList.Push(action);
            return true;
        }


        public bool Redo()
        {
            if (RedoSize == 0)
                return false;

            var action = RedoList.Pop();
            action.PerformAction();
            UndoList.Push(action);
            return true;
        }
    }
}
