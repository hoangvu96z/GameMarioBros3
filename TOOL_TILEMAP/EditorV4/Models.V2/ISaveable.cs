using EditorV4.EditorObjects;
using EditorV4.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Models.V2
{
    public static class ObjectExt
    {
        public static T1 CopyFrom<T1, T2>(this T1 obj, T2 otherObject,Type type = null)
            where T1 : class
            where T2 : class
        {
            if(type==null)
            {
                type = otherObject.GetType();
            }

            PropertyInfo[] srcFields = otherObject.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            PropertyInfo[] destFields = obj.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            PropertyInfo[] copyFields = type.GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);



            foreach (var property in copyFields)
            {
                var dest = destFields.FirstOrDefault(x => x.Name == property.Name);
                var src = srcFields.FirstOrDefault(x => x.Name == property.Name);
                if (dest != null && dest.CanWrite)
                    dest.SetValue(obj, src.GetValue(otherObject, null), null);
            }

            return obj;
        }
    }
    public interface ISaveable
    {
        bool ActiveSelectTileFromWorld { get; set; }
        bool CanAddTile { get; set; }
        bool CanSelectObject { get; set; }
        List<CollisionTypeCollide> CollisionTypeCollides { get; set; }
        DataTable CollisionTypeTable { get; set; }
        GroupSelectable CurrentObject { get; set; }
        Color CurrentTileColor { get; set; }
        GameObjectCategory FocusedObjectCategory { get; set; }
        PointF FocusedObjectCategoryLocation { get; set; }
        GroupSelectable Objects { get; set; }
        Color QuadtreeBorderColor { get; set; }
        Color SelectedTileColor { get; set; }
        Color SelectedTileInWorldColor { get; set; }
        Color SelectingBackColor { get; set; }
        Color SelectingColorBorder { get; set; }
        int TileHeight { get; set; }
        Color TileObjectColor { get; set; }
        List<int> TilesIndex { get; set; }
        TilesModel TilesModel { get; }
        int TileWidth { get; set; }
        Unit Unit { get; }
    }
    [Serializable]
    public class ISaveableImpl : ISaveable
    {
        public bool ActiveSelectTileFromWorld { get; set; }
        public bool CanAddTile { get; set; }
        public bool CanSelectObject { get; set; }
        public List<CollisionTypeCollide> CollisionTypeCollides { get; set; }
        public DataTable CollisionTypeTable { get; set; }
        public GroupSelectable CurrentObject { get; set; }
        public Color CurrentTileColor { get; set; }
        public GameObjectCategory FocusedObjectCategory { get; set; }
        public PointF FocusedObjectCategoryLocation { get; set; }
        public GroupSelectable Objects { get; set; }
        public Color QuadtreeBorderColor { get; set; }
        public Color SelectedTileColor { get; set; }
        public Color SelectedTileInWorldColor { get; set; }
        public Color SelectingBackColor { get; set; }
        public Color SelectingColorBorder { get; set; }
        public int TileHeight { get; set; }
        public Color TileObjectColor { get; set; }
        public List<int> TilesIndex { get; set; }
        public TilesModel TilesModel { get; }
        public int TileWidth { get; set; }
        public Unit Unit { get; }
    }

}
