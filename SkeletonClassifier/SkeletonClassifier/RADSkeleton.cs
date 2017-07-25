namespace SkeletonClassifier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class RADSkeleton : Skeleton
    {
        public new Dictionary<JointLocations, Joint> Joints { get; set; }

        private Dictionary<int, (double theta, double rho)> ThetaRho { get; set; }

        public RADSkeleton(int frame) : base(frame)
        {
            this.Joints = new Dictionary<JointLocations, Joint>();
            this.ThetaRho = new Dictionary<int, (double theta, double rho)>();
        }

        public new void AddJoint(int joint, double x, double y, double z)
        {
            var jointLocation = GetJointLocation(joint);
            if (jointLocation != JointLocations.None && !this.Joints.Keys.Contains(jointLocation))
            {
                this.Joints.Add(jointLocation, new Joint() { x = x, y = y, z = z });
            }
        }



        private static JointLocations GetJointLocation(int joint)
        {
            switch (joint)
            {
                case 1:
                    return JointLocations.Cent;
                case 4:
                    return JointLocations.Head;
                case 8:
                    return JointLocations.HandLeft;
                case 12:
                    return JointLocations.HandRight;
                case 16:
                    return JointLocations.FootLeft;
                case 20:
                    return JointLocations.FootRight;
                default:
                    return JointLocations.None;
            }
        }

    }

    public enum JointLocations
    {
        Cent,
        Head,
        HandLeft,
        HandRight,
        FootLeft,
        FootRight,
        None
    }

    
}
