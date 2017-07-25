namespace SkeletonClassifier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public abstract class Skeleton : IComparable
    {
        public readonly int Frame;

        public Dictionary<int, Joint> Joints { get; set; }

        public Skeleton(int frame)
        {
            this.Frame = frame;
            Joints = new Dictionary<int, Joint>();
        }

        public void AddJoint(int joint, double x, double y, double z)
        {
            if (!this.Joints.Keys.Contains(joint))
            {
                this.Joints.Add(joint, new Joint() { x = x, y = y, z = z });
            }
        }
        
        public int CompareTo(object obj)
        {
            var other = obj as Skeleton;
            var ret = 0;
            if (other != null)
            {
                if (this.Frame < other.Frame) ret = -1;
                if (this.Frame == other.Frame) ret = 0;
                if (this.Frame > other.Frame) ret = 1;
            }
            else
            {
                throw new Exception();
            }

            return ret;
        }
    }

    public class Joint
    {
        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }
    }
}
