using EditorV4.EditorObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorV4.UndoRedo.Model
{
    public class GameObjectHorComparer : IComparer<ISelectableObject>
    {
        public int Compare(ISelectableObject x1, ISelectableObject y1)
        {
            GameObject x = (GameObject)x1;
            GameObject y = (GameObject)y1;
            return (x.X + 10000 * x.Y) - (y.X + 10000 * y.Y);
        }
    }
    [Serializable]
    public class GroupObjectAction : BaseAction
    {
        List<ISelectableObject> objects;
        List<ISelectableObject> sortedObject;

        public GroupObjectAction(List<ISelectableObject> objects)
        {
            this.objects = objects.ToList();
        }

        public override void PerformAction()
        {
            sortedObject = objects.ToList();
            sortedObject.Sort(new GameObjectHorComparer());

            for (int baseIndex = 0; baseIndex < sortedObject.Count; baseIndex++)
            {
                GameObject baseObject = (GameObject)sortedObject[baseIndex];
                baseObject.Resizeable = true;
                List<GameObject> undoObjects = null;
                if(baseObject.IsGrouped==false)
                {
                    baseObject.ObjectsGrouped = new Stack<List<GameObject>>();
                }
                int groupCount = baseObject.ObjectsGrouped.Count;
                for (int nextIndex = baseIndex + 1; nextIndex < sortedObject.Count; nextIndex++)
                {
                    GameObject nextObject = (GameObject)sortedObject[nextIndex];
                    if (baseObject.ObjectCategory.Id == nextObject.ObjectCategory.Id)
                    {
                        if (baseObject.Y == nextObject.Y && baseObject.Height == nextObject.Height && baseObject.X + baseObject.Width == nextObject.X)
                        {
                            if (groupCount == baseObject.ObjectsGrouped.Count)
                            {
                                baseObject.IsGrouped = true;
                                undoObjects = new List<GameObject>();
                                baseObject.ObjectsGrouped.Push(undoObjects);
                            }
                            undoObjects.Add(nextObject);
                            baseObject.Width += nextObject.Width;
                            nextObject.Active = false;
                            sortedObject.Remove(nextObject);
                            nextIndex--;
                        }
                    }
                }
                baseObject.Resizeable = false;
            }
        }

        public override void PerformRevertAction()
        {
            foreach (GameObject obj in sortedObject)
            {
                if (obj.IsGrouped)
                {
                    obj.Resizeable = true;
                    var undoObjects = obj.ObjectsGrouped.Pop();
                    foreach (var groupedObj in undoObjects)
                    {
                        obj.Width -= groupedObj.Width;
                        groupedObj.Active = true;
                    }
                    obj.Resizeable = false;
                    if (obj.ObjectsGrouped.Count == 0)
                        obj.IsGrouped = false;
                }
            }
        }
    }
}
