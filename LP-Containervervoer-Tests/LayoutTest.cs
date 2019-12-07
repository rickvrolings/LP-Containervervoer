using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using System;

namespace LP_Containervervoer_Tests
{
    public class LayoutTest
    {
        private const int _defaultMaxTopLoad = 120000;
        private const int _defaultWeight = 30000;

        [Test]
        public void ReturnLayout()
        {
            int width = 5;
            int height = 4;
            int length = 6;

            LayoutManager layoutManager = new LayoutManager(length, width, height);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(width, layoutManager.Layout.Length);
                Assert.AreEqual(length, layoutManager.Layout[0].Length);
            });
        }

        [Test]
        public void OneWidth()
        {
            int width = 1;
            int height = 1;
            int length = 1;

            LayoutManager layoutManager = new LayoutManager(length, width, height);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(width, layoutManager.Layout.Length);
                Assert.AreEqual(length, layoutManager.Layout[0].Length);
                Assert.AreEqual(height, layoutManager.Layout[0][0].MaxHeight);
            });
        }

        [Test]
        public void GenerateLayout()
        {
            int length = 1;
            int width = 1;
            int height = 1;
            LayoutManager layout = new LayoutManager(length, width, height);

            layout.GenerateLayout();
        }

        
    }
}