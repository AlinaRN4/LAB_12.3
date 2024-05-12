using Лабораторная_работа_12._3;
using ClassLibrary10lab;
namespace MyTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MakeTree_CreatesTreeWithCorrectLength()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(5);
            Assert.AreEqual(5, tree.Count);
        }

        [TestMethod]
        public void AddPoint_IncreasesCount()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MusicalInstrument data = new MusicalInstrument();
            data.RandomInit();
            tree.AddPoint(data);
           
            Assert.AreEqual(1, tree.Count);
        }
        [TestMethod]
        public void RemoveByName_RemovesElementFromTree()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(3);
            MusicalInstrument instrument1 = new MusicalInstrument();
            MusicalInstrument instrument2 = new MusicalInstrument();
            MusicalInstrument instrument3 = new MusicalInstrument();

            tree.Insert(instrument1);
            tree.Insert(instrument2);
            tree.Insert(instrument3);

            // Act
            tree.RemoveByName(instrument2.Name);

            // Assert
            Assert.AreEqual(2, tree.Count);
        }


        [TestMethod]
        public void ExistingElement_ReturnsTrue()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(3);
            MusicalInstrument guitar = new MusicalInstrument("Гитара");
            MusicalInstrument piano = new MusicalInstrument("Пианино");
            MusicalInstrument electricGuitar = new MusicalInstrument("Электрогитара");

            tree.Insert(guitar);
            tree.Insert(piano);
            tree.Insert(electricGuitar);

            Assert.IsTrue(tree.Count == 3);
        }
        [TestMethod]
        public void ExistingElement_ReturnsFalse()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(3);
            MusicalInstrument guitar = new MusicalInstrument("Гитара");
            MusicalInstrument piano = new MusicalInstrument("Пианино");
            MusicalInstrument electricGuitar = new MusicalInstrument("Электрогитара");

            tree.Insert(guitar);
            tree.Insert(piano);
            tree.Insert(electricGuitar);

            Assert.IsFalse(tree.Count == 2);
        }

        [TestMethod]
        public void AddPoint_NewElement_CorrectCount()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MusicalInstrument data = new MusicalInstrument();
            data.RandomInit();
            tree.AddPoint(data);

            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void FindMin_TreeNotEmpty_ReturnsMinElement()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(3);
            MusicalInstrument data = new MusicalInstrument();
            data.RandomInit();
            tree.AddPoint(data);

            MusicalInstrument data1 = new MusicalInstrument();
            data1.RandomInit();
            tree.AddPoint(data1);

            MusicalInstrument minElement = tree.FindMin();

            Assert.AreEqual(data, minElement);
        }

        [TestMethod]
        public void TransformToArray_WithElements_CorrectArrayTransformation()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(3);
            MusicalInstrument guitar = new MusicalInstrument("Гитара");
            MusicalInstrument piano = new MusicalInstrument("Пианино");
            MusicalInstrument electricGuitar = new MusicalInstrument("Электрогитара");

            tree.Insert(guitar);
            tree.Insert(piano);
            tree.Insert(electricGuitar);

            MusicalInstrument[] expectedArray = { guitar, piano, electricGuitar };
            MusicalInstrument[] actualArray = new MusicalInstrument[tree.Count];
            int currentIndex = 0;
            tree.TransformToFindTree();

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void TreeIsFull()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(1);
            MusicalInstrument key = new MusicalInstrument();
            key.RandomInit();
            tree.Insert(key);
            // Act & Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void TreeIsNull()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(0);
            MusicalInstrument key = new MusicalInstrument();
            key.RandomInit();
            tree.Insert(key);
            // Act & Assert
            Assert.IsFalse(tree.Count == 1);
        }

        [TestMethod]
        public void TreeAdd()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(1);
            MusicalInstrument key = new MusicalInstrument();
            key.RandomInit();
            tree.AddPoint(key);
            // Act & Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void TreeRemoveByName()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(3);

            MusicalInstrument guitar = new MusicalInstrument("Гитара");
            MusicalInstrument piano = new MusicalInstrument("Пианино");
            MusicalInstrument electricGuitar = new MusicalInstrument("Электрогитара");

            tree.Insert(guitar);
            tree.Insert(piano);
            tree.Insert(electricGuitar);

            // Act
            tree.RemoveByName("Пианино");
            // Act & Assert
            Assert.AreEqual(2, tree.Count);
        }

        [TestMethod]
        public void RemoveTree_ClearsTree()
        {
            // Arrange
            var tree = new MyTree<MusicalInstrument>(3);

            // Act
            tree.RemoveTree();

            // Assert
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void PointEquals_ReturnsTrueForEqualPoints()
        {
            // Arrange
            var point1 = new Point<int>(5);
            var point2 = new Point<int>(5);

            // Assert
            Assert.IsTrue(point1.Equals(point2));
        }

        [TestMethod]
        public void PointCompareTo_ComparePointsCorrectly()
        {
            // Arrange
            var point1 = new Point<int>(10);
            var point2 = new Point<int>(5);

            // Act
            int result = point1.CompareTo(point2);

            // Assert
            Assert.IsTrue(result > 0); // point1 > point2
        }
    }
}