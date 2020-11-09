using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
using EditorV4.Models.V2;
using EditorV4.UndoRedo;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EditorV4.Services.SaveModels
{
    [Serializable]
    public class SaveModel
    {
        public Image Tilesheet { get; set; }
        public int[,] Matrix { get; set; }
        public int TileRows { get; set; }
        public int TileColumns { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TilesheetColumns { get; set; }
        public UndoRedoManager UndoRedoManager { get; set; }
        public GroupSelectable Objects { get; set; }
        public List<GameObjectCategory> GameObjectCategories { get; set; }
        public List<String> CollisionTypes { get; set; }
        public List<CollisionTypeCollide> CollisionTypeCollides { get; set; }
        public Color CurrentTileColor { get; set; }
        public Color QuadtreeBorderColor { get; set; }
        public Color SelectedTileColor { get; set; }
        public Color SelectedTileInWorldColor { get; set; }
        public Color SelectingBackColor { get; set; }
        public Color SelectingColorBorder { get; set; }
        public Color TileObjectColor { get; set; }
        public TreeViewSave TreeViewObject { get; set; }
        public TreeViewSave CollisionTypeTree { get; set; }
        public TreeViewSave TreeViewCollisionTypeCollide { get; set; }

    }
}
