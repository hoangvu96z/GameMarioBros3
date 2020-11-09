using EditorV4.Controls;
using EditorV4.Controls.PropertyGridModel;
using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
using EditorV4.Forms;
using EditorV4.Models.V2;
using EditorV4.Services;
using EditorV4.Services.SaveModels;
using EditorV4.Ultils;
using EditorV4.UndoRedo;
using EditorV4.UndoRedo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace EditorV4
{
    [Serializable]
    public partial class MapEditor :
        Form, IControlScrollInterface,
        ICanvasScrollParent,
        IPaddingCanvasGroupParent,
        ILoaderInterface,
        TilesheetCanvasInterface,
        ICreateObject,
        IUndoRedoEvent,
        IObjectsManager,
        IModifiledObjectInterface,
        ITreeViewContainer,
        TileObjectLayerInterface,
        ChooseObjectTypeFormInterface,
        FocusedObjectLayerInterface,
        BoudingSelectingLayerInterface,
        SelectedTileInWorldLayerInterface,
        AddTileInterface,
        QuadTreeLayerInterface,
        SelectTileFromWorldLayerInterface,
        SelectTileFromWorldServiceInterface,
        SettingFormInterface,
        SaveInterface,
        IMapEditor,
        ISaveable,
        ISerializable
    {
        protected MapEditor(SerializationInfo info, StreamingContext context) :
            this()
        {

        }
        public MapEditor()
        {
            InitializeComponent();
            canvasScrollControl1.WorldWidth = 1000;

            canvasScrollControl1.Init(this);
            canvasScrollTile.Init(this);

            canvasScrollControl1.WorldHeight = 1000;
            canvasScrollControl1.canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            controlScrollService = new ControlScrollService(this);
            canvasScrollControl1.CanvasScrollParent = this;
            canvasScrollTile.CanvasScrollParent = this;
            cmbUnit.Text = "Pixel";
            TileWidth = 16;
            TileHeight = 16;
            Objects = new GroupSelectable();
            createObjectService = new CreateObjectService(this, canvasScrollControl1.canvasWorldViewGroup);
            selectTileFromWorldService = new SelectTileFromWorldService(canvasScrollControl1.canvasWorldViewGroup, this);
            modifiedObjectService = new ModifiedObjectService(this, canvasScrollControl1.canvasWorldViewGroup);
            addTileService = new AddTileService(this, canvasScrollControl1.canvasWorldViewGroup);
            UndoRedoManager = new UndoRedoManager(this);
            TilesIndex = new List<int>();
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(Objects);
            FocusedObjectLayer focusedObjectLayer = new FocusedObjectLayer(this);
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(focusedObjectLayer);

            BoudingSelectingLayer selectingLayer = new BoudingSelectingLayer(this);
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(selectingLayer);

            SelectedTileInWorldLayer selectedTileInWorldLayer = new SelectedTileInWorldLayer(this);
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(selectedTileInWorldLayer);

            SelectTileFromWorldLayer selectTileFromWorldLayer = new SelectTileFromWorldLayer(this);
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(selectTileFromWorldLayer);

            QuadtreeLayer quadtreeLayer = new QuadtreeLayer(this);
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(quadtreeLayer);

            canvasScrollControl1.ConvertWorldView = canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup;
            canvasScrollTile.ConvertWorldView = canvasScrollTile.canvasWorldViewGroup;
            SelectedTileColor = Color.Yellow;
            GameObjectCategories = new List<GameObjectCategory>();
            treeViewObject.AddImage("Root", EditorV4.Properties.Resources._object);
            treeViewObject.RootObject = new TreeViewObject(null, treeViewObject, this, "Objects", "Root");
            TileObjectColor = Color.LightYellow;
            InitCollisionTypeTable();
            collisionTypeTree.TreeViewContainer = this;
            treeViewObject.TreeViewContainer = this;

            SelectingColorBorder = Color.Blue;
            SelectingBackColor = Color.FromArgb(50, 0, 0, 200);
            SelectedTileInWorldColor = Color.White;
            SelectedTileIndex = -1;
            CanAddTile = false;

            QuadtreeBorderColor = Color.Green;
            CurrentTileColor = Color.Red;

            CollisionTypeCollides = new List<CollisionTypeCollide>();
            treeViewCollisionTypeCollide.AddImage("Collision", EditorV4.Properties.Resources.collision);
            treeViewCollisionTypeCollide.TreeViewContainer = this;
        }

        //private void BackgroundWorkerCreateObjectNode_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (_prepareCreateNewTreeNodeObjects == null)
        //        return;
        //    string imageKey = _prepareCreateNewTreeNodeObjectCategory.Index.ToString();
        //    foreach (var gameObject in _prepareCreateNewTreeNodeObjects)
        //    {
        //        gameObject.TreeViewObject = new TreeViewObject(_prepareCreateNewTreeNodeObjectCategory.TreeViewObject,
        //                    treeViewObject, gameObject,
        //                    gameObject.Display, imageKey);
        //        gameObject.TreeViewObject.TreeViewObjectType = TreeViewObjectType.GameObject;
        //    }
        //}

        private void BackgroundWorkerCreateObjectNode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void InitCollisionTypeTable()
        {
            currentCollisionTypeId = 0;
            CollisionTypeTable = new DataTable();
            CollisionTypeTable.Columns.Add("Id");
            CollisionTypeTable.Columns.Add("Name");
            addCollisionTypeForm = new AddCollisionTypeForm();
            addCollisionTypeForm.ComboboxDataSource = CollisionTypeTable;
            var r = CollisionTypeTable.NewRow();
            collisionTypeTree.RootObject = new EditorV4.Controls.TreeViewControl.TreeViewObject(null,
                collisionTypeTree, this, "Root", "Collision");
            TreeViewCollisionTypeCollide.RootObject = new EditorV4.Controls.TreeViewControl.TreeViewObject(null,
                TreeViewCollisionTypeCollide, this, "Root", "Collision");
            AddCollisionType("Ground");
            AddCollisionType("Enemy");

            collisionTypeTree.AddImage("Collision", EditorV4.Properties.Resources.collision);
            treeViewObjectsMap = new Dictionary<string, TreeViewObject>();
        }

        public int IndexOfCollisionType(string collisionTypeName)
        {
            foreach (DataRow r in CollisionTypeTable.Rows)
            {
                if (r["Name"].ToString().ToLower().Equals(collisionTypeName.ToLower()))
                {
                    return CollisionTypeTable.Rows.IndexOf(r);
                }
            }
            return -1;
        }

        public List<string> GetCollisionTypes()
        {
            List<string> results = new List<string>();
            foreach (DataRow r in CollisionTypeTable.Rows)
            {
                results.Add(r["Name"].ToString());
            }

            return results;
        }

        public bool RemoveCollisionType(string collisionTypeName)
        {
            foreach (var objCat in GameObjectCategories)
            {
                if (objCat.CollisionType.ToLower().Equals(collisionTypeName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        public void AddCollisionType(string collisionTypeName)
        {
            foreach (DataRow r in CollisionTypeTable.Rows)
            {
                if (r["Name"].ToString().ToLower().Equals(collisionTypeName.ToLower()))
                {
                    return;
                }
            }
            var row = CollisionTypeTable.NewRow();
            row["Id"] = currentCollisionTypeId++;
            row["Name"] = collisionTypeName;
            CollisionTypeTable.Rows.Add(row);
            TreeViewObject treeViewObject = new TreeViewObject(collisionTypeTree.RootObject, collisionTypeTree, collisionTypeTree, collisionTypeName, "Collision");
            treeViewObjectsMap = new Dictionary<string, TreeViewObject>();
            treeViewObjectsMap.Add(collisionTypeName, treeViewObject);
        }

        #region PRIVATE MEMBER

        private SelectTileFromWorldService selectTileFromWorldService;
        private CreateObjectService createObjectService;
        private ControlScrollService controlScrollService;
        private AddTileService addTileService;
        private ModifiedObjectService modifiedObjectService;
        public UndoRedoManager UndoRedoManager { get; set; }
        private TilesheetCanvas tilesheetCanvas;
        private AddCollisionTypeForm addCollisionTypeForm;
        private int currentCollisionTypeId;
        private Dictionary<string, TreeViewObject> treeViewObjectsMap;
        private BackgroundWorker backgroundWorkerCreateObjectNode;

        #endregion

        #region PUBLIC MEMBER

        #region COMMON

        public List<CollisionTypeCollide> CollisionTypeCollides { get; set; }

        public bool IsHorizontalScroll
        {
            get
            {
                return btnHorizontalScroll.Checked;
            }
        }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public float TilesheetZoomValue
        {
            get
            {
                if (trackBarTilesheetZoom.Value == 10)
                {
                    return 1.0f;
                }
                if (trackBarTilesheetZoom.Value < 10)
                {
                    return trackBarTilesheetZoom.Value * 0.1f;
                }
                return (trackBarTilesheetZoom.Value - 9);
            }
        }
        public float ZoomValue
        {
            get
            {
                if (trackBarZoom.Value == 10)
                {
                    return 1.0f;
                }
                if (trackBarZoom.Value < 10)
                {
                    return trackBarZoom.Value * 0.1f;
                }
                return (trackBarZoom.Value - 9);
            }
        }
        private GroupSelectable _currentObject;
        public Cursor SelectCursor { get; set; }
        public List<GameObjectCategory> GameObjectCategories { get; set; }
        public DataTable CollisionTypeTable { get; set; }
        public PointF FocusedObjectCategoryLocation { get; set; }
        #endregion

        #region BoudingSelectingLayer

        public Rectangle SelectingRect { get; set; }
        public Color SelectingColorBorder { get; set; }
        public Color SelectingBackColor { get; set; }

        #endregion

        #region SelectedTileInWorldLayer

        public Point TilePrepareAddLocation { get; set; }
        public bool CanAddTile { get; set; }

        public TilesModel TilesModel { get; set; }
        //{
        //    get
        //    {
        //        return canvasScrollControl1.canvasWorldViewGroup.TilesModel;
        //    }
        //    set
        //    {
        //        canvasScrollControl1.canvasWorldViewGroup.TilesModel = value;
        //    }
        //}
        public int SelectedTileIndex { get; set; }

        public Color SelectedTileInWorldColor { get; set; }

        #endregion

        #region ICanvasScrollParent

        public bool CanScroll
        {
            get
            {
                return !controlScrollService.IsControlDown;
            }
        }

        #endregion

        #region ICreateObject CreateObjectService

        public bool IsCreateRect { get; set; }

        public GroupSelectable Objects { get; set; }
        public GameObjectCategory FocusedObjectCategory { get; set; }

        public GroupSelectable CurrentObject
        {
            get { return _currentObject; }
            set
            {
                _currentObject = value;
                if (_currentObject != null)
                {
                    _currentObject.Selected = true;
                }
            }
        }

        public Unit Unit
        {
            get
            {
                if (cmbUnit.Text == "Pixel")
                    return Unit.Pixel;
                return Unit.Tile;
            }
            set
            {
                cmbUnit.Text = value.ToString();
            }
        }

        #endregion

        #region IPaddingCanvasGroupParent

        public bool IsControlDown
        {
            get
            {
                return controlScrollService.IsControlDown;
            }
        }

        #endregion

        #region TilesheetCanvasInterface

        public Color CurrentTileColor { get; set; }


        public Color SelectedTileColor { get; set; }

        public bool CanSelectObject
        {
            get
            {
                return createObjectService.CreateObjectState == CreateObjectState.None;
            }
            set
            {
                IsCreateRect = !value;
            }
        }

        public List<int> TilesIndex { get; set; }

        public Color TileObjectColor { get; set; }

        public int TilesheetColumns { get { return tilesheetCanvas.TileColumns; } }

        public QuadNode RootNode { get; set; }

        public Color QuadtreeBorderColor { get; set; }

        #endregion

        #endregion

        #region SelectTileFromWorld

        public Point SelectTileFromWorldLocation { get; set; }

        public bool ActiveSelectTileFromWorld
        {
            get { return btnSelectTile.Checked; }
            set { btnSelectTile.Checked = value; }
        }

        public bool CanRenderGrid { get { return btnGrid.Checked; } }

        #endregion

        #region METHOD


        #region ICreateObject CreateObjectService

        public void AddLayerObject(ISelectableObject @object)
        {
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(@object);
        }

        public void RemoveLayerObject(ISelectableObject @object)
        {
            canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.RemoveObject(@object);
        }


        public void AddGameObject(GameObject @object, bool isUndo = true)
        {
            if (isUndo)
            {
                List<BaseAction> multiActions = new List<BaseAction>();

                multiActions.Add(new AddObjectAction(@object, this));
                var customProperties = @object.ObjectCategory.GetCustomProperties();
                foreach (var p in customProperties)
                {
                    multiActions.Add(new AddPropertyAction(@object, p));
                }
                UndoRedoManager.MultiAction(multiActions);
            }
            else
            {
                Objects.AddObject(@object);
            }
        }

        #endregion

        #region IUndoRedoManager

        void IObjectsManager.AddGameObject(GameObject @object)
        {
            if (@object.Active == false)
            {
                @object.TreeViewObject.Parent.Node.Nodes.Insert(@object.TreeViewObject.NodeIndex, @object.TreeViewObject.Node);
                @object.Active = true;
                return;
            }
            string imageKey = @object.ObjectCategory.Index.ToString();
            Objects.AddObject(@object);
            @object.TreeViewObject = new TreeViewObject(@object.ObjectCategory.TreeViewObject, treeViewObject,
                    @object, @object.Display, imageKey
                    );
            @object.TreeViewObject.TreeViewObjectType = TreeViewObjectType.GameObject;
            if (@object.TreeViewObject.Parent != null && !@object.TreeViewObject.Parent.Node.Nodes.Contains(@object.TreeViewObject.Node))
                @object.TreeViewObject.Parent.Node.Nodes.Add(@object.TreeViewObject.Node);
        }

        void IObjectsManager.RemoveGameObject(GameObject @object)
        {
            @object.TreeViewObject.Node.Remove();
            @object.Active = false;
        }

        #endregion

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            switch (keyData)
            {
                case Keys.Up:
                    modifiedObjectService.OnKeyUpDown();
                    propertyGrid1.Refresh();
                    return true;
                case Keys.Down:
                    modifiedObjectService.OnKeyDownDown();
                    propertyGrid1.Refresh();
                    return true;
                case Keys.Left:
                    modifiedObjectService.OnKeyLeftDown();
                    propertyGrid1.Refresh();
                    return true;
                case Keys.Right:
                    modifiedObjectService.OnKeyRightDown();
                    propertyGrid1.Refresh();
                    return true;
                case Keys.Escape:
                    createObjectService.CreateObjectState = CreateObjectState.None;
                    CanAddTile = false;
                    return true;
                case Keys.Enter:
                    tilesheetCanvas.CreateObjectCategoryFromSelectedTile();
                    return true;
                case Keys.Delete:
                    if (CurrentObject != null)
                    {
                        List<BaseAction> actions = new List<BaseAction>();
                        foreach (GameObject obj in CurrentObject.Objects)
                        {
                            actions.Add(new RemoveObjectAction(obj, this));
                        }
                        UndoRedoManager.MultiAction(actions);
                        RemoveLayerObject(CurrentObject);
                        CurrentObject = null;
                        RefreshCanvas();
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }

        public bool CanMultiSelect
        {
            get
            {
                return controlScrollService.IsControlDown;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);
            controlScrollService.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            canvasScrollControl1.canvasWorldViewGroup.IsControlEnter = false;
            controlScrollService.OnKeyUp(e);
            base.OnKeyUp(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            controlScrollService.OnMouseWheel(e);
            base.OnMouseWheel(e);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            canvasScrollControl1.OnZoom(ZoomValue, canvasScrollControl1.CurrentMovePoint);
            canvasScrollControl1.UpdateScroll();
            canvasScrollControl1.Refresh();
        }

        public void OnControlScroll(MouseEventArgs e)
        {
            TrackBar currentTrackbar = trackBarZoom;
            if (canvasScrollTile.Focused)
            {
                currentTrackbar = trackBarTilesheetZoom;
            }
            if (e.Delta > 0)
            {
                currentTrackbar.Value = (currentTrackbar.Value + 1).SmallerOrEqualThan(currentTrackbar.Maximum);
            }
            else
            {
                currentTrackbar.Value = (currentTrackbar.Value - 1).GreaterOrEqualThan(currentTrackbar.Minimum);
            }
            if (currentTrackbar == trackBarZoom)
            {
                trackBar1_Scroll(null, null);
            }
            else
            {
                trackBarTilesheetZoom_Scroll(null, null);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openTileExisting.ShowDialog() == DialogResult.OK)
            {
                canvasScrollControl1.LoadTileMapFromExisitingFile(openTileExisting.FileName, this);
                InitShowTile();
                canvasScrollControl1.Refresh();
                canvasScrollTile.Refresh();

            }
        }

        private void InitShowTile()
        {
            canvasScrollControl1.canvasWorldViewGroup.LoadTileRender();
            tilesheetCanvas = new TilesheetCanvas();
            tilesheetCanvas.@interface = this;
            tilesheetCanvas.Tilesheet = canvasScrollControl1.canvasWorldViewGroup.TilesModel.Tilesheet;
            canvasScrollTile.WorldWidth = tilesheetCanvas.Tilesheet.Width;
            canvasScrollTile.WorldHeight = tilesheetCanvas.Tilesheet.Height;
            canvasScrollTile.canvasWorldViewGroup.PaddingLeft = canvasScrollTile.canvasWorldViewGroup.PaddingRight = canvasScrollTile.canvasWorldViewGroup.PaddingTop = canvasScrollTile.canvasWorldViewGroup.PaddingBottom = 20;
            canvasScrollTile.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.CanvasState = CanvasState.DRAWABLE;
            canvasScrollTile.canvasWorldViewGroup.PaddingCanvasGroupParent = this;
            canvasScrollTile.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(tilesheetCanvas);
            canvasScrollTile.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(new TileObjectLayer(this));
            canvasScrollTile.canvasWorldViewGroup.InvalidateCanvasSize();
            canvasScrollTile.canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            canvasScrollControl1.canvasWorldViewGroup.InvalidateCanvasSize();
            canvasScrollControl1.canvasWorldViewGroup.EditorCanvasScrollHandling.InvalidateScrollMaxValue();
            btnSave.Enabled = btnImportObject.Enabled = btnDrawRectangle.Enabled =
                    btnGroup.Enabled = btnQuadtree.Enabled = btnSelectTile.Enabled =
                    btnGrid.Enabled = btnHorizontalScroll.Enabled = true;
            btnGrid.Checked = true;
            cmbTileWidth.Enabled = cmbTileHeight.Enabled = false;
            cmbRows.Enabled = cmbColumns.Enabled = true;
        }

        public void EnableWaiting()
        {
            progressWaiting.Visible = true;
        }

        public void DisableWaiting()
        {
            progressWaiting.Visible = false;
        }

        public void SetVolumeWaiting(int volume)
        {
            progressWaiting.Value = volume;
        }

        private void trackBarTilesheetZoom_Scroll(object sender, EventArgs e)
        {
            canvasScrollTile.OnZoom(TilesheetZoomValue, canvasScrollTile.CurrentMovePoint);
            canvasScrollTile.UpdateScroll();
            canvasScrollTile.Refresh();
        }

        private void canvasScrollTile_MouseMove(object sender, MouseEventArgs e)
        {
            canvasScrollTile.Focus();
            if (tilesheetCanvas == null)
                return;
            var pt = canvasScrollTile.canvasWorldViewGroup.GetWorldPointFromPaddingCanvasViewPoint(e.Location);
            tilesheetCanvas.OnMouseMove(new Point((int)pt.X, (int)pt.Y));
            canvasScrollTile.Refresh();
        }

        private void canvasScrollControl1_MouseMove(object sender, MouseEventArgs e)
        {
            canvasScrollControl1.Focus();

            if (ActiveSelectTileFromWorld)
            {
                selectTileFromWorldService.OnMouseMove(e.Location);
                return;
            }

            if (CanAddTile)
            {
                addTileService.OnMouseMove(e);
                return;
            }
            SelectCursor = Cursors.Arrow;
            createObjectService.OnMouseMove(e.Location);
            modifiedObjectService.OnMouseMove(e.Location);
            canvasScrollControl1.Cursor = SelectCursor;
        }

        private void cmbTileWidth_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(cmbTileWidth.Text, out n);
            if (!isNumeric || (isNumeric && n < 4 || n > 100))
            {
                MessageBox.Show("Tile width invalid!");
                cmbTileWidth.Text = TileWidth.ToString();
            }
            else
            {
                TileWidth = n;
            }
        }

        private void cmbTileHeight_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(cmbTileHeight.Text, out n);
            if (!isNumeric || (isNumeric && n < 4 || n > 100))
            {
                MessageBox.Show("Tile width invalid!");
                cmbTileHeight.Text = TileHeight.ToString();
            }
            else
            {
                TileHeight = n;
            }
        }

        public void RefreshCanvas()
        {
            canvasScrollControl1.Refresh();
        }

        public void OnSizing(ISelectableObject @object)
        {

        }

        private void canvasScrollControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FocusedObjectCategory = null;
                RemoveLayerObject(CurrentObject);
                CurrentObject = null;
                createObjectService.CreateObjectState = CreateObjectState.None;
                CanAddTile = false;
                ActiveSelectTileFromWorld = false;
                RefreshCanvas();
                return;
            }

            if (ActiveSelectTileFromWorld)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectTileFromWorldService.OnMouseDown(e.Location);
                    ActiveSelectTileFromWorld = false;
                    canvasScrollTile.Refresh();
                    SelectedTileIndex = tilesheetCanvas.SelectedTilePoint.Y * TilesModel.TilesheetColumns + tilesheetCanvas.SelectedTilePoint.X;
                    CanAddTile = true;
                    RefreshCanvas();
                }
                return;
            }


            if (CanAddTile)
            {
                if (e.Button == MouseButtons.Left)
                {
                    addTileService.OnMouseDown(e);
                }
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                createObjectService.OnMouseDown(e.Location);
                modifiedObjectService.OnMouseDown(e.Location);

            }

        }

        private void canvasScrollControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (CanAddTile)
            {
                return;
            }

            createObjectService.OnMouseUp();
            modifiedObjectService.OnMouseUp();

            btnGroup.IsCheckBox = false;

            if (CurrentObject != null)
            {
                btnGroup.IsCheckBox = true;
                if (CurrentObject.Objects.Count == 1)
                {
                    GameObject o = (GameObject)CurrentObject.Objects[0];
                    propertyGrid1.SelectedObject = o;
                    btnGroup.Checked = (o.IsGrouped);
                }
                else
                {
                    btnGroup.Checked = false;
                }
            }
            else
            {
                propertyGrid1.SelectedObject = null;
            }
            propertyGrid1.Refresh();
        }

        void RefreshUndoRedoEnable()
        {
            btnUndo.Enabled = UndoRedoManager.UndoList.Count > 0;
            btnRedo.Enabled = UndoRedoManager.RedoList.Count > 0;
        }

        public void OnAction()
        {
            RefreshUndoRedoEnable();
        }

        public void AddObjectCategory(GameObjectCategory objectCategory)
        {
            GameObjectCategories.Add(objectCategory);
            string imageKey = objectCategory.Index.ToString();
            if (objectCategory.TreeViewObject == null)
            {
                treeViewObject.AddImage(imageKey, objectCategory.ObjectCategoryImage);
                objectCategory.TreeViewObject = new TreeViewObject(treeViewObject.RootObject,
                    treeViewObject, objectCategory,
                    objectCategory.Display, imageKey);
            }
            else
            {
                treeViewObject.RootObject.Node.Nodes.Insert(objectCategory.TreeViewObject.NodeIndex, objectCategory.TreeViewObject.Node);
            }
            objectCategory.TreeViewObject.Owner = objectCategory;
        }

        public void RemoveObjectCategory(GameObjectCategory objectCategory)
        {
            foreach (GameObject obj in Objects.Objects)
            {
                if (obj.ObjectCategory == objectCategory)
                {
                    obj.Active = false;
                }
            }
            if (FocusedObjectCategory == objectCategory)
            {
                createObjectService.CreateObjectState = CreateObjectState.None;
                FocusedObjectCategory = null;
            }
            objectCategory.TreeViewObject.Node.Remove();
            GameObjectCategories.Remove(objectCategory);
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            RemoveLayerObject(CurrentObject);
            CurrentObject = null;
            UndoRedoManager.Undo();
            RefreshCanvas();
            RefreshUndoRedoEnable();
            propertyGrid1.Refresh();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            CurrentObject = null;
            UndoRedoManager.Redo();
            RefreshCanvas();
            RefreshUndoRedoEnable();
            propertyGrid1.Refresh();
        }

        public void OnMoveEnd(ISelectableObject selectableObject, Point denta)
        {
            UndoRedoManager.MovingGameObject(denta.X, denta.Y, selectableObject);
        }

        public void OnSizingEnd(ISelectableObject selectableObject, int sizingValue, MouseMovingBase mouseManager)
        {
            Point denta = mouseManager.Delta;
            UndoRedoManager.SizingGameObject(mouseManager.FirstCorner.ToPoint(), mouseManager.SecondCorner.ToPoint(), sizingValue, selectableObject);
        }

        private void MapEditor_KeyUp(object sender, KeyEventArgs e)
        {
            modifiedObjectService.OnKeyUp();
        }


        private void MapEditor_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void canvasScrollTile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pt = canvasScrollTile.canvasWorldViewGroup.GetWorldPointFromPaddingCanvasViewPoint(e.Location);
            tilesheetCanvas.CreateObjectCategoryFromSelectedTile();
            canvasScrollTile.Refresh();
            treeViewObject.RootObject.Node.Expand();
        }
        public void RefreshTileCanvas()
        {
            canvasScrollTile.Refresh();
        }
        private void canvasScrollTile_MouseDown(object sender, MouseEventArgs e)
        {
            var pt = canvasScrollTile.canvasWorldViewGroup.GetWorldPointFromPaddingCanvasViewPoint(e.Location);
            tilesheetCanvas.OnMouseDown(pt.ToPoint());
            canvasScrollTile.Refresh();
            SelectedTileIndex = tilesheetCanvas.CurrentIndex;
            CanAddTile = true;
            RefreshCanvas();
        }
        private GameObjectCategory _prepareCreateNewTreeNodeObjectCategory;

        public void AddTileObjectFromAvailableObjectCategory(int tileIndex, GameObjectCategory gameObjectCategory)
        {
            var tilesModel = canvasScrollControl1.canvasWorldViewGroup.TilesModel;
            List<BaseAction> actions = new List<BaseAction>();
            for (int rIndex = 0; rIndex < tilesModel.TileRows; rIndex++)
            {
                for (int cIndex = 0; cIndex < tilesModel.TileColumns; cIndex++)
                {
                    if (tilesModel.Matrix[rIndex, cIndex] == gameObjectCategory.TileIndex)
                    {
                        bool canAdd = true;
                        foreach (GameObject obj in Objects.Objects)
                        {
                            //if (!obj.Active)
                            //    continue;

                            if (obj.X == cIndex * TileWidth && obj.Y == rIndex * TileHeight
                                && obj.Width == TileWidth && obj.Height == TileHeight
                                )
                            {
                                canAdd = false;
                                break;
                            }
                        }

                        if (canAdd)
                        {
                            GameObject gameObject = new GameObject();
                            gameObject.ObjectCategory = gameObjectCategory;
                            gameObject.X = cIndex * TileWidth;
                            gameObject.Y = rIndex * TileHeight;
                            gameObject.Index = Objects.Objects.Count;
                            actions.Add(new AddObjectAction(gameObject, this));
                        }
                    }
                }
            }
            UndoRedoManager.MultiAction(actions);
        }

        public void AddGameObjectCategory(GameObjectCategory gameObjectCategory, TreeViewObjectType treeViewObjectType = TreeViewObjectType.CategoryObjectFromTile)
        {
            List<BaseAction> actions = new List<BaseAction>();
            actions.Add(new AddObjectCategoryAction(gameObjectCategory, this));
            if (treeViewObjectType == TreeViewObjectType.CategoryObjectFromTile)
            {
                var tilesModel = canvasScrollControl1.canvasWorldViewGroup.TilesModel;
                TilesIndex.Add(gameObjectCategory.TileIndex);
                for (int rIndex = 0; rIndex < tilesModel.TileRows; rIndex++)
                {
                    for (int cIndex = 0; cIndex < tilesModel.TileColumns; cIndex++)
                    {
                        if (tilesModel.Matrix[rIndex, cIndex] == gameObjectCategory.TileIndex)
                        {
                            GameObject gameObject = new GameObject();
                            gameObject.ObjectCategory = gameObjectCategory;
                            gameObject.X = cIndex * TileWidth;
                            gameObject.Y = rIndex * TileHeight;
                            gameObject.Index = Objects.Objects.Count;
                            actions.Add(new AddObjectAction(gameObject, this));
                        }
                    }
                }
            }
            else if (treeViewObjectType == TreeViewObjectType.CategoryObjectFromFile)
            {
                gameObjectCategory.TileIndex = -1;
            }

            UndoRedoManager.MultiAction(actions);
            gameObjectCategory.TreeViewObject.TreeViewObjectType = treeViewObjectType;
            RefreshCanvas();
        }

        public void OnSelectTreeViewObject(TreeViewObject obj, CustomTreeView treeView)
        {

        }

        public void OnDelete(TreeViewObject obj, CustomTreeView treeView)
        {
            if (treeView == collisionTypeTree)
            {
                if (!RemoveCollisionType(obj.Node.Text))
                {
                    MessageBox.Show("Can't Remove");
                    return;
                }
                else
                {
                    obj.NodeIndex = obj.Node.Parent.Nodes.IndexOf(obj.Node);
                }
            }
            else if (treeView == treeViewObject)
            {
                obj.NodeIndex = obj.Node.Parent.Nodes.IndexOf(obj.Node);
                switch (obj.TreeViewObjectType)
                {
                    case TreeViewObjectType.Root:
                        return;
                    case TreeViewObjectType.CategoryRectangle:
                    case TreeViewObjectType.CategoryObjectFromFile:
                    case TreeViewObjectType.CategoryObjectFromTile:
                        UndoRedoManager.RemoveObjectCategory((GameObjectCategory)obj.Owner, this);
                        break;
                    case TreeViewObjectType.GameObject:
                        UndoRedoManager.RemoveGameObject((GameObject)obj.Owner, this);
                        RemoveLayerObject(CurrentObject);
                        CurrentObject = null;
                        RefreshCanvas();
                        break;
                }
            }
            else if (treeView == treeViewCollisionTypeCollide)
            {
                CollisionTypeCollides.Remove((CollisionTypeCollide)obj.Owner);
            }
            obj.Node.Remove();
        }



        public void OnProperty(TreeViewObject obj, CustomTreeView treeView)
        {

        }


        public void OnFocus(TreeViewObject obj, CustomTreeView treeView)
        {
            if (treeView == treeViewObject)
            {
                tilesheetCanvas.SelectedTilePoint = new Point(-1, -1);
                switch (obj.TreeViewObjectType)
                {
                    case TreeViewObjectType.CategoryRectangle:
                        IsCreateRect = true;
                        FocusedObjectCategory = null;
                        createObjectService.CreateObjectState = CreateObjectState.CreateRectangle;
                        FocusedObjectCategory = (GameObjectCategory)obj.Owner;
                        CanAddTile = false;
                        propertyGrid1.SelectedObject = FocusedObjectCategory;
                        btnAddProperty.Enabled = true;
                        btnRemoveProperty.Enabled = true;
                        SetCollisionTyleList(FocusedObjectCategory);
                        break;
                    case TreeViewObjectType.CategoryObjectFromFile:
                    case TreeViewObjectType.CategoryObjectFromTile:
                        FocusedObjectCategory = (GameObjectCategory)obj.Owner;
                        IsCreateRect = false;
                        createObjectService.CreateObjectState = CreateObjectState.CreateObjectFocused;
                        CanAddTile = false;
                        propertyGrid1.SelectedObject = FocusedObjectCategory;
                        btnAddProperty.Enabled = true;
                        btnRemoveProperty.Enabled = true;
                        SetCollisionTyleList(FocusedObjectCategory);
                        break;
                    case TreeViewObjectType.GameObject:
                        IsCreateRect = false;
                        createObjectService.CreateObjectState = CreateObjectState.None;
                        RemoveLayerObject(CurrentObject);
                        CurrentObject = new GroupSelectable();
                        CurrentObject.AddObject((ISelectableObject)obj.Owner);
                        AddLayerObject(CurrentObject);
                        RefreshCanvas();
                        CanAddTile = false;
                        propertyGrid1.SelectedObject = obj.Owner;
                        btnAddProperty.Enabled = false;
                        btnRemoveProperty.Enabled = false;
                        break;
                }
            }
        }

        private void SetCollisionTyleList(GameObjectCategory focusedObjectCategory)
        {
            List<string> collisionTypeList = new List<string>();
            foreach (DataRow r in CollisionTypeTable.Rows)
            {
                collisionTypeList.Add(r["Name"].ToString());
            }
            focusedObjectCategory.CollisionTypeList = collisionTypeList;
        }

        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddObject_Click(object sender, EventArgs e)
        {
            ChooseObjectTypeForm form = new ChooseObjectTypeForm();
            form.Interface = this;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ChooseObjectTypeEnum == ChooseObjectTypeEnum.Rectangle)
                {
                    var createObjectCategoryForm = form.CreateObjectCategoryForm;
                    GameObjectCategory gameObjectCategory = new GameObjectCategory();
                    gameObjectCategory.Id = createObjectCategoryForm.ObjectCategoryId;
                    gameObjectCategory.Name = createObjectCategoryForm.ObjectCategoryName;
                    gameObjectCategory.ObjectCategoryImage = createObjectCategoryForm.ObjCategoryImage;
                    gameObjectCategory.TileIndex = -1;
                    AddCollisionType(createObjectCategoryForm.CollisionTypeName);
                    gameObjectCategory.CollisionType = createObjectCategoryForm.CollisionTypeName;
                    AddGameObjectCategory(gameObjectCategory, TreeViewObjectType.CategoryRectangle);
                }
                treeViewObject.RootObject.Node.Expand();
            }
        }

        private void btnAddCollisionType_Click(object sender, EventArgs e)
        {
            if (addCollisionTypeForm.ShowDialog() == DialogResult.OK)
            {
                AddCollisionType(addCollisionTypeForm.CollisionTypeName);
                addCollisionTypeForm.CollisionTypeName = "";
            }
        }

        public void OnDoubleClick(TreeViewObject obj, CustomTreeView treeView)
        {
            if (treeView == treeViewObject)
            {
                switch (obj.TreeViewObjectType)
                {
                    case TreeViewObjectType.CategoryRectangle:
                    case TreeViewObjectType.CategoryObjectFromFile:
                    case TreeViewObjectType.CategoryObjectFromTile:
                        obj.Node.Collapse();
                        GameObjectCategory gameObjectCategory = (GameObjectCategory)obj.Owner;
                        RemoveLayerObject(CurrentObject);
                        CurrentObject = new GroupSelectable();
                        AddLayerObject(CurrentObject);
                        foreach (GameObject o in Objects.Objects)
                        {
                            if (o.ObjectCategory == gameObjectCategory)
                            {
                                CurrentObject.AddObject(o);
                            }
                        }
                        RefreshCanvas();
                        break;
                }
            }
        }

        public void AddTile(int rowIndex, int columnIndex, int tileIndex)
        {
            if (rowIndex < 0 || rowIndex >= TilesModel.TileRows)
                return;
            if (columnIndex < 0 || columnIndex >= TilesModel.TileColumns)
                return;
            if (TilesModel.Matrix[rowIndex, columnIndex] == tileIndex)
                return;
            UndoRedoManager.ModifiedTile(tileIndex, rowIndex, columnIndex, TilesModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveOut.ShowDialog() == DialogResult.OK)
            {
                RootNode = null;
                btnQuadtree.PerformClick();
                SaveService saveService = new SaveService(this);
                saveService.Save(saveOut.FileName);
            }
        }

        public CustomTreeView TreeViewObject { get { return treeViewObject; } }
        public CustomTreeView CollisionTypeTree { get { return collisionTypeTree; } }
        public CustomTreeView TreeViewCollisionTypeCollide { get { return treeViewCollisionTypeCollide; } }


        public TreeNodeCollection TreeViewObjectRootNode
        {
            get
            {
                return treeViewObject.Nodes;
            }
        }

        private void btnQuadtree_Click(object sender, EventArgs e)
        {
            RootNode = new QuadNode(new Rectangle(0, 0, canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.Width,
                canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.Height), Objects.Objects, "0");
            RefreshCanvas();
        }

        private void AddCollisionTypeCollide(CollisionTypeCollide collision)
        {
            foreach (var collisionTypeCollide in CollisionTypeCollides)
            {
                if (collisionTypeCollide.Collision1 == collision.Collision1 &&
                    collisionTypeCollide.Collision2 == collision.Collision2)
                {
                    return;
                }
            }
            CollisionTypeCollides.Add(collision);
            TreeViewObject treeViewObject = new TreeViewObject(
                treeViewCollisionTypeCollide.RootObject, treeViewCollisionTypeCollide,
                collision, collision.Collision1 + " - " + collision.Collision2, "Collision"
                );
        }

        private void btnCollisionTypeCollideAdd_Click(object sender, EventArgs e)
        {
            var form = new AddCollisionTypeCollideForm();
            form.CollisionType1ComboboxDataSource = CollisionTypeTable.Copy();
            form.CollisionType2ComboboxDataSource = CollisionTypeTable.Copy();
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddCollisionTypeCollide(new CollisionTypeCollide()
                {
                    Collision1 = form.CollisionType1,
                    Collision2 = form.CollisionType2
                });
            }
        }

        public void SelectTile(int rowIndex, int colIndex)
        {
            tilesheetCanvas.SelectedTilePoint = new Point(colIndex, rowIndex);
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            AddPropertyForm form = new AddPropertyForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                string propertyName = form.PropertyName;
                if (propertyGrid1.SelectedObject != null)
                {
                    List<BaseAction> multiActions = new List<BaseAction>();
                    var customClass = (GameObjectCategory)propertyGrid1.SelectedObject;
                    AddPropertyAction addPropertyAction = new AddPropertyAction(customClass, propertyName);
                    multiActions.Add(addPropertyAction);
                    foreach (GameObject obj in Objects.Objects)
                    {
                        addPropertyAction = new AddPropertyAction(obj, propertyName);
                        multiActions.Add(addPropertyAction);
                    }
                    UndoRedoManager.MultiAction(multiActions);
                    propertyGrid1.Refresh();
                }
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UndoRedoManager.PropertyChange((CustomClass)propertyGrid1.SelectedObject, e.OldValue, e.ChangedItem.Label);
            RefreshCanvas();
        }

        private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
        {
            //   MessageBox.Show("Selected Object Change");
        }

        private void btnRemoveProperty_Click(object sender, EventArgs e)
        {
            if (propertyGrid1.SelectedObject == null)
            {
                return;
            }
            RemovePropertyForm form = new RemovePropertyForm();
            var customClass = (GameObjectCategory)propertyGrid1.SelectedObject;
            form.ComboboxDataSource = customClass.GetCustomProperties();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<BaseAction> actions = new List<BaseAction>();
                actions.Add(new RemovePropertyAction(customClass, form.PropertyName));
                foreach (GameObject obj in Objects.Objects)
                {
                    if (obj.ObjectCategory.Id == customClass.Id)
                    {
                        actions.Add(new RemovePropertyAction(obj, form.PropertyName));
                    }
                }
                UndoRedoManager.MultiAction(actions);
                propertyGrid1.Refresh();
            }

        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            RefreshCanvas();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this);
            settingForm.ShowDialog();
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openDatFile.ShowDialog() == DialogResult.OK)
            {
                canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.RemoveObject(Objects);
                SaveService saveService = new SaveService(this);
                SaveModel m = saveService.ReadFile(openDatFile.FileName);
                this.CopyFrom(m);
                this.TilesModel.CopyFrom(m);

                m.TreeViewObject.TreeView = TreeViewObject;
                m.TreeViewObject.Load();

                m.TreeViewCollisionTypeCollide.TreeView = TreeViewCollisionTypeCollide;
                m.TreeViewCollisionTypeCollide.Load();

                //m.CollisionTypeTree.TreeView = CollisionTypeTree;
                //m.CollisionTypeTree.Load();

                CollisionTypeTree.RootObject.Node.Nodes.Clear();



                CollisionTypeTable.Rows.Clear();
                foreach (var collisionType in m.CollisionTypes)
                {
                    AddCollisionType(collisionType);
                }

                InitShowTile();
                canvasScrollTile.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.CanvasState = CanvasState.DRAWABLE;
                canvasScrollControl1.canvasWorldViewGroup.WorldViewGroup.EditorCanvas.AppendObject(Objects);
                RefreshCanvas();
                RefreshTileCanvas();

                foreach (var action in UndoRedoManager.UndoList)
                {
                    action.ObjectManager = this;
                }

                foreach (var action in UndoRedoManager.RedoList)
                {
                    action.ObjectManager = this;
                }
                RefreshUndoRedoEnable();
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        private void btnRemoveObject_Click(object sender, EventArgs e)
        {
            OnDelete((TreeViewObject)treeViewObject.SelectedNode.Tag, treeViewObject);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (CurrentObject != null)
            {
                if (btnGroup.Checked)
                {
                    UndoRedoManager.GroupObject(CurrentObject.Objects);
                }
                else
                {
                    if (CurrentObject.Objects.Count != 1)
                        return;
                    UndoRedoManager.UnGroupObject((GameObject)CurrentObject.Objects[0]);
                }
                RefreshCanvas();
            }
        }

        private void btnRemoveCollisionType_Click(object sender, EventArgs e)
        {

        }
    }
}
