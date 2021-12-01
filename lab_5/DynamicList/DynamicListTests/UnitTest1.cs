using DynamicList;
using Moq;
using System;
using System.Collections;
using Xunit;

namespace DynamicListTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethodAdd()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            int count = 0;

            // Act
            for (int i = 0; i < 10; i++)
            {
                list.Add("1");
                count++;
            }

            // Assert
            Assert.Equal(count, list.Count);

        }

        [Fact]
        public void TestMethodRemove()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            DynamicList<string> testList = new DynamicList<string>() { "0", "1", "2", "3", "4", "6", "7", "8", "9" };
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                list.Add(Convert.ToString(i));
                count++;
            }

            // Act
            list.Remove("5");
            count--;

            // Assert
            Assert.Equal(list, testList);
        }

        [Fact]
        public void TestMethodRemoveAt()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            DynamicList<string> testList = new DynamicList<string>() { "0", "1", "2", "3", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 10; i++)
            {
                list.Add(Convert.ToString(i));
            }

            // Act
            list.RemoveAt(4);

            // Assert
            Assert.Equal(list, testList);
        }

        [Fact]
        public void TestMethodClear()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(Convert.ToString(i));
            }

            // Act
            list.Clear();

            // Assert
            Assert.Empty(list);
        }

        [Fact]
        public void TestRemoveAtIncorrectData()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                list.Add(Convert.ToString(i));
                count++;
            }

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(10));
        }

        [Fact]
        public void TestMoqEnumerator()
        {
            DynamicList<int> list = new DynamicList<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var mock = new Mock<IEnumerable>();
            mock.Setup(c => c.GetEnumerator()).Returns(list.GetEnumerator());

            int expected = 0;
            foreach (var i in mock.Object)
            {
                Assert.Equal(expected++, i);
            }
        }

        [Fact]
        public void TestIndexatorIncorrectData()
        {
            // Arrange
            DynamicList<string> list = new DynamicList<string>();
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                list.Add(Convert.ToString(i));
                count++;
            }

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => list[-25]);
        }
    }
}
