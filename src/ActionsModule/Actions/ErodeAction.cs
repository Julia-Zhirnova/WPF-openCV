using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionsModule.Attributes;

namespace ActionsModule.Actions
{
    [Category("Preprocessing")]
    public class ErodeAction : ImageAction
    {
        private MorphShapes ms = MorphShapes.Ellipse;
        private double size = 3;
        private int iterations = 1;
        private BorderTypes borderTypes = BorderTypes.Constant;

        public ErodeAction()
        {
            this.Name = "Erode";
            this.Action = (m) =>
            {
                var ms = Cv2.GetStructuringElement(MorphShape, new Size(Size, Size));
                var cvt = m.Erode(ms, null, Iterations, BorderType, null);
                m.Dispose();
                ms.Dispose();
                HasError = false;
                return cvt;
            };
        }

        [ImportExport]
        [Enum(typeof(MorphShapes))]
        public MorphShapes MorphShape
        {
            get
            {
                return ms;
            }

            set
            {
                SetProperty(ref ms, value);
            }
        }

        [ImportExport]
        [Slider(3, 29, 2, isIntegerType: false)]
        public double Size
        {
            get
            {
                return size;
            }

            set
            {
                SetProperty(ref size, value);
            }
        }

        [ImportExport]
        [Slider(1, 10)]
        public int Iterations
        {
            get
            {
                return iterations;
            }

            set
            {
                SetProperty(ref iterations, value);
            }
        }

        [ImportExport]
        [Enum(typeof(BorderTypes))]
        public BorderTypes BorderType
        {
            get
            {
                return borderTypes;
            }

            set
            {
                SetProperty(ref borderTypes, value);
            }
        }
    }
}
