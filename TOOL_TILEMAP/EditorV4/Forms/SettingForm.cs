using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Forms
{
    public interface SettingFormInterface
    {
        Color CurrentTileColor { get; set; }
        Color SelectedTileColor { get; set; }
        Color SelectedTileInWorldColor { get; set; }
        Color QuadtreeBorderColor { get; set; }
        Color TileObjectColor { get; set; }
        Color SelectingColorBorder { get; set; }
        Color SelectingBackColor { get; set; }
        void RefreshCanvas();
        void RefreshTileCanvas();
    }
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }
        bool canRefreshCanvas = false;
        Color oldCurrentTileColor;
        Color oldSelectedTileColor;
        Color oldSelectedTileInWorldColor;
        Color oldQuadtreeBorderColor;
        Color oldTileObjectColor;
        Color oldSelectingColorBorder;
        Color oldSelectingBackColor;
        public SettingForm(SettingFormInterface @interface)
            : this()
        {
            CurrentTileColor = @interface.CurrentTileColor;
            SelectedTileColor = @interface.SelectedTileColor;
            SelectedTileInWorldColor = @interface.SelectedTileInWorldColor;
            QuadtreeBorderColor = @interface.QuadtreeBorderColor;
            TileObjectColor = @interface.TileObjectColor;
            SelectingColorBorder = @interface.SelectingColorBorder;
            SelectingBackColor = @interface.SelectingBackColor;

            oldCurrentTileColor = @interface.CurrentTileColor;
            oldSelectedTileColor = @interface.SelectedTileColor;
            oldSelectedTileInWorldColor = @interface.SelectedTileInWorldColor;
            oldQuadtreeBorderColor = @interface.QuadtreeBorderColor;
            oldTileObjectColor = @interface.TileObjectColor;
            oldSelectingColorBorder = @interface.SelectingColorBorder;
            oldSelectingBackColor = @interface.SelectingBackColor;
            this.@interface = @interface;
            canRefreshCanvas = true;
        }
        SettingFormInterface @interface;

        Color CurrentTileColor
        {
            get { return colorCurrentTileColor.SelectedColor; }
            set
            {
                colorCurrentTileColor.SelectedColor = value;
            }
        }
        private void colorCurrentTileColor_OnSelectColorEvent(Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.CurrentTileColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }
        Color SelectedTileColor
        {
            get { return colorSelectedTileColor.SelectedColor; }
            set
            {
                colorSelectedTileColor.SelectedColor = value;
            }
        }
        private void ColorSelectedTileInWorldColor_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.SelectedTileInWorldColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }
        Color SelectedTileInWorldColor
        {
            get { return colorSelectedTileInWorldColor.SelectedColor; }
            set
            {
                colorSelectedTileInWorldColor.SelectedColor = value;
            }
        }

        private void ColorQuadtreeBorderColor_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.QuadtreeBorderColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }
        Color QuadtreeBorderColor
        {
            get { return colorQuadtreeBorderColor.SelectedColor; }
            set
            {
                colorQuadtreeBorderColor.SelectedColor = value;
                if (!canRefreshCanvas)
                    return;
                @interface.QuadtreeBorderColor = value;
            }
        }

        private void ColorTileObjectColor_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.TileObjectColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }
        Color TileObjectColor
        {
            get { return colorTileObjectColor.SelectedColor; }
            set
            {
                colorTileObjectColor.SelectedColor = value;
            }
        }
        private void ColorSelectedTileColor_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.SelectedTileColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }

        Color SelectingColorBorder
        {
            get { return colorSelectingColorBorder.SelectedColor; }
            set
            {
                colorSelectingColorBorder.SelectedColor = value;
            }
        }
        private void ColorSelectingColorBorder_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.SelectingColorBorder = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }
        Color SelectingBackColor
        {
            get { return colorSelectingBackColor.SelectedColor; }
            set
            {
                colorSelectingBackColor.SelectedColor = value;
            }
        }
        private void ColorSelectingBackColor_OnSelectColorEvent(System.Drawing.Color color)
        {
            if (!canRefreshCanvas)
                return;
            @interface.SelectingBackColor = color;
            @interface.RefreshCanvas();
            @interface.RefreshTileCanvas();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(DialogResult == DialogResult.OK))
            {
                @interface.CurrentTileColor = oldCurrentTileColor;
                @interface.SelectedTileColor = oldSelectedTileColor;
                @interface.SelectedTileInWorldColor = oldSelectedTileInWorldColor;
                @interface.QuadtreeBorderColor = oldQuadtreeBorderColor;
                @interface.TileObjectColor = oldTileObjectColor;
                @interface.SelectingColorBorder = oldSelectingColorBorder;
                @interface.SelectingBackColor = oldSelectingBackColor;
            }
        }
    }
}
