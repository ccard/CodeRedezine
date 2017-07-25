namespace SkeletonClassifier
{
    using System.Collections.Generic;
    using System.Linq;

    public class HJPDSkeletion : Skeleton
    {
        public int RefJoint { get; set; } = 3;

        public Dictionary<int, Joint> Displacements { get; set; }

        public HJPDSkeletion(int frame) : base(frame)
        {
            this.Displacements = new Dictionary<int, Joint>();
        }

        public static HJPDSkeletion Construct(Skeleton s, int refJoint = 3)
        {
            var skeleton = new HJPDSkeletion(s.Frame) {
                RefJoint = refJoint,
                Joints = s.Joints
            };

            skeleton.CalcDisplacements();

            return skeleton;
        }

        public void CalcDisplacements()
        {
            var refJoint = this.Joints[this.RefJoint];

            foreach(var joint in this.Joints.Where(t => t.Key != this.RefJoint))
            {
                this.Displacements.Add(joint.Key, CalcDisplacement(refJoint, joint.Value));
            }
        }

        private static Joint CalcDisplacement(Joint lhs, Joint rhs)
        {
            return new Joint()
            {
                x = rhs.x - lhs.x,
                y = rhs.y - lhs.y,
                z = rhs.z - lhs.z
            };
        }
    }
}
