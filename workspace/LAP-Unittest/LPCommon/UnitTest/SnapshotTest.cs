using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace LPCommon
{
#if TEST
    [TestClass]
    public class SnapshotTest
    {
        [ClassInitialize]
        public static void Init(TestContext TestContext)
        {
            
        }

        [TestMethod]
        public void Snapshot_CaptureInflatedRectangle()
        {
            Snapshot snapshot = new Snapshot();
            Rectangle rect = new Rectangle(new Point(100, 100), new Size(30, 50));

            MemoryStream stream = snapshot.CaptureInflatedRectangle(rect);

            Image image = Image.FromStream(stream);

            Size size = image.Size;

            Assert.AreEqual(30 + 20, size.Width);

            Assert.AreEqual(50 + 20, size.Height);

        }

    }

#endif
}
