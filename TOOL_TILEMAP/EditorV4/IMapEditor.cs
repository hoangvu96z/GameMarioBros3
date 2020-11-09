using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
using EditorV4.Models.V2;
using EditorV4.Services;

namespace EditorV4
{
    public interface IMapEditor
    {
        //bool ActiveSelectTileFromWorld { get; set; }
        //bool CanAddTile { get; set; }
        //bool CanRenderGrid { get; }
        //bool CanScroll { get; }
        //bool CanSelectObject { get; set; }
        //List<CollisionTypeCollide> CollisionTypeCollides { get; set; }
        //DataTable CollisionTypeTable { get; set; }
        //GroupSelectable CurrentObject { get; set; }
        //Color CurrentTileColor { get; set; }
        //Color QuadtreeBorderColor { get; set; }
        //Color SelectedTileColor { get; set; }
        //Color SelectedTileInWorldColor { get; set; }
        //Color SelectingBackColor { get; set; }
        //Color SelectingColorBorder { get; set; }
        //Color TileObjectColor { get; set; }
        //GameObjectCategory FocusedObjectCategory { get; set; }
        //PointF FocusedObjectCategoryLocation { get; set; }
        //bool IsControlDown { get; }
        //bool IsCreateRect { get; set; }
        //bool IsHorizontalScroll { get; }
        //GroupSelectable Objects { get; set; }
        //QuadNode RootNode { get; set; }
        //Cursor SelectCursor { get; set; }
        //int SelectedTileIndex { get; set; }
        //Rectangle SelectingRect { get; set; }
        //Point SelectTileFromWorldLocation { get; set; }
        //int TileHeight { get; set; }
        //Point TilePrepareAddLocation { get; set; }
        //int TilesheetColumns { get; }
        //float TilesheetZoomValue { get; }
        //List<int> TilesIndex { get; set; }
        //TilesModel TilesModel { get; }
        //int TileWidth { get; set; }
        //Unit Unit { get; }
        //float ZoomValue { get; }

        //void AddCollisionType(string collisionTypeName);
        //void AddGameObject(GameObject @object, bool isUndo = true);
        //void AddGameObjectCategory(GameObjectCategory gameObjectCategory, TreeViewObjectType treeViewObjectType = TreeViewObjectType.CategoryObjectFromTile);
        //void AddLayerObject(ISelectableObject @object);
        //void AddObjectCategory(GameObjectCategory objectCategory);
        //void AddTile(int rowIndex, int columnIndex, int tileIndex);
        //void DisableWaiting();
        //void EnableWaiting();
        //void GetObjectData(SerializationInfo info, StreamingContext context);
        //int IndexOfCollisionType(string collisionTypeName);
        //void OnAction();
        //void OnControlScroll(MouseEventArgs e);
        //void OnDelete(TreeViewObject obj, CustomTreeView treeView);
        //void OnDoubleClick(TreeViewObject obj, CustomTreeView treeView);
        //void OnFocus(TreeViewObject obj, CustomTreeView treeView);
        //void OnMoveEnd(ISelectableObject selectableObject, Point denta);
        //void OnProperty(TreeViewObject obj, CustomTreeView treeView);
        //void OnSelectTreeViewObject(TreeViewObject obj, CustomTreeView treeView);
        //void OnSizing(ISelectableObject @object);
        //void OnSizingEnd(ISelectableObject selectableObject, int sizingValue, MouseMovingBase mouseManager);
        //void RefreshCanvas();
        //void RefreshTileCanvas();
        //bool RemoveCollisionType(string collisionTypeName);
        //void RemoveLayerObject(ISelectableObject @object);
        //void RemoveObjectCategory(GameObjectCategory objectCategory);
        //void SelectTile(int rowIndex, int colIndex);
        //void SetVolumeWaiting(int volume);
    }
}