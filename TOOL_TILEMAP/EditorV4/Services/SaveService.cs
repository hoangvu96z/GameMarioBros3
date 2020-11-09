using EditorV4.Controls.TreeViewControl;
using EditorV4.EditorObjects;
using EditorV4.Models.V2;
using EditorV4.Services.SaveModels;
using EditorV4.Ultils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorV4.Services
{

    public interface SaveInterface
    {
        QuadNode RootNode { get; }
        GroupSelectable Objects { get; }
        TilesModel TilesModel { get; }
        int IndexOfCollisionType(string collisionTypeName);
        List<CollisionTypeCollide> CollisionTypeCollides { get; }
        CustomTreeView TreeViewObject { get; }
        CustomTreeView CollisionTypeTree { get; }
        CustomTreeView TreeViewCollisionTypeCollide { get; }
        List<string> GetCollisionTypes();

    }
    public class SaveService
    {
        SaveInterface @interface;

        byte[] SerializeToBytes(object obj)
        {
            byte[] bytes;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                bytes = stream.ToArray();
            }
            return bytes;
        }

        object DeserializeFromBytes(byte[] bytes)
        {
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }

        //Serializing the List
        void Serialize(ISaveable maps, String filename)
        {
            //Create the stream to add object into it.
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary
            //ISaveableImpl saveable = new ISaveableImpl();
            //saveable.CopyFrom(maps);

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object
            formatter.Serialize(ms, maps);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }


        //Deserializing the List
        ISaveable Deserialize(String filename)
        {
            //Format the object as Binary
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            ISaveable maps = (ISaveable)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return maps;
        }

        public SaveModel ReadFile(String fileName)
        {
            SaveModel obj = (SaveModel)DeserializeFromBytes(File.ReadAllBytes(fileName));
            return obj;
        }

        public SaveService(SaveInterface @interface)
        {
            this.@interface = @interface;
        }

        public void Save(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string tilesheetPath = path + "\\tilesheet.png";
            string quadtreePath = path + "\\quadtree.dat";
            string objectsPath = path + "\\objects.dat";
            string matrixPath = path + "\\matrix.txt";
            string dataPath = path + "\\data.dat";
            string collisionTypeCollidePath = path + "\\collision_type_collides.dat";

            List<ISelectableObject> allObject = @interface.Objects.Objects.ToList();
            allObject.RemoveAll(x => ((GameObject)x).Active == false);

            SaveTilesheet(tilesheetPath);
            //SaveObjects(objectsPath, allObject);
            //SaveQuadTree(quadtreePath, allObject);
            SaveMatrix(matrixPath);
            //SaveCollisionTypeCollide(collisionTypeCollidePath);

            SaveData((MapEditor)@interface, dataPath);
        }

        private void SaveData(MapEditor obj, string dataPath)
        {
            var model = obj.CloneAs<SaveModel>();
            model.TreeViewObject = new TreeViewSave();
            model.TreeViewObject.TreeView = @interface.TreeViewObject;
            model.TreeViewObject.Store();

            model.TreeViewCollisionTypeCollide = new TreeViewSave();
            model.TreeViewCollisionTypeCollide.TreeView = @interface.TreeViewCollisionTypeCollide;
            model.TreeViewCollisionTypeCollide.Store();

            model.CollisionTypeTree = new TreeViewSave();
            model.CollisionTypeTree.TreeView = @interface.CollisionTypeTree;
            model.CollisionTypeTree.Store();

            model.CollisionTypes = @interface.GetCollisionTypes();
            model.CopyFrom(obj.TilesModel);
            byte[] bytes = SerializeToBytes(model);
            File.WriteAllBytes(dataPath, bytes);
        }

        private void SaveCollisionTypeCollide(string collisionTypeCollidePath)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@interface.CollisionTypeCollides.Count);
            builder.AppendLine();
            foreach (var collisionTypeCollide in @interface.CollisionTypeCollides)
            {
                builder.Append(@interface.IndexOfCollisionType(collisionTypeCollide.Collision1));
                builder.Append("\t");
                builder.Append(@interface.IndexOfCollisionType(collisionTypeCollide.Collision2));
                builder.AppendLine();
            }
            StreamWriter stream = new StreamWriter(collisionTypeCollidePath);
            stream.Write(builder.ToString());
            stream.Close();
        }

        private void SaveMatrix(string matrixPath)
        {
            var tilesModel = @interface.TilesModel;
            StringBuilder builder = new StringBuilder();
            MessageBox.Show("So Dong :"+ tilesModel.TileRows + "- So Cot: "+ tilesModel.TileColumns);

            for (int rowIndex = 0; rowIndex < tilesModel.TileRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < tilesModel.TileColumns; columnIndex++)
                {
                    builder.Append(tilesModel.Matrix[rowIndex, columnIndex]);
                    builder.Append("\t");
                }
                builder.AppendLine();
            }
            StreamWriter stream = new StreamWriter(matrixPath);
            stream.Write(builder.ToString());
            stream.Close();
        }

        void SaveQuadTree(QuadNode node, StringBuilder builder, List<ISelectableObject> allObjects)
        {
            builder.Append(node.Id);
            builder.Append("\t");
            builder.Append(node.X);
            builder.Append("\t");
            builder.Append(node.Y);
            builder.Append("\t");
            builder.Append(node.Width);
            builder.Append("\t");
            builder.Append(node.Height);
            if (node.TL != null)
            {
                builder.Append("\t");
                builder.Append(4);
                builder.Append("\t");
                builder.Append(0);
                builder.AppendLine();
                SaveQuadTree(node.TL, builder, allObjects);
                SaveQuadTree(node.TR, builder, allObjects);
                SaveQuadTree(node.BL, builder, allObjects);
                SaveQuadTree(node.BR, builder, allObjects);
            }
            else if (node.Objects != null)
            {
                builder.Append("\t");
                builder.Append(0);
                builder.Append("\t");
                builder.Append(node.Objects.Count);

                foreach (GameObject obj in node.Objects)
                {
                    builder.Append("\t");
                    builder.Append(allObjects.IndexOf(obj));
                }
                builder.AppendLine();
            }
            else
            {
                builder.Append("\t");
                builder.Append(0);
                builder.Append("\t");
                builder.Append(0);
                builder.AppendLine();
            }
        }
        private void SaveQuadTree(string quadtreePath, List<ISelectableObject> allObjects)
        {
            StringBuilder builder = new StringBuilder();
            SaveQuadTree(@interface.RootNode, builder, allObjects);
            StreamWriter stream = new StreamWriter(quadtreePath);
            stream.Write(builder.ToString());
            stream.Close();
        }

        private void SaveObjects(string objectsPath, List<ISelectableObject> allObjects)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(allObjects.Count);
            foreach (GameObject obj in allObjects)
            {
                if (!obj.Active)
                    continue;
                if (obj.ObjectCategory.CollisionType == null)
                    obj.ObjectCategory.CollisionType = "Enemy";
                builder.AppendLine();
                builder.Append(obj.ObjectCategory.Id);
                builder.Append("\t");
                builder.Append(@interface.IndexOfCollisionType(obj.ObjectCategory.CollisionType));
                builder.Append("\t");
                builder.Append(obj.X);
                builder.Append("\t");
                builder.Append(obj.Y);
                builder.Append("\t");
                builder.Append(obj.Width);
                builder.Append("\t");
                builder.Append(obj.Height);

            }
            StreamWriter stream = new StreamWriter(objectsPath);
            stream.Write(builder.ToString());
            stream.Close();
        }

        private void SaveTilesheet(string tilesheetPath)
        {
            @interface.TilesModel.Tilesheet.Save(tilesheetPath);
        }
    }
}
