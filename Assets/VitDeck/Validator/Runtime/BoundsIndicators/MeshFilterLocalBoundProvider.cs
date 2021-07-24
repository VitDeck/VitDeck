using UnityEngine;

namespace VitDeck.Validator.BoundsIndicators
{
    public class MeshFilterLocalBoundProvider : IMeshLocalBoundsProvider
    {
        private readonly MeshFilter filter;

        public MeshFilterLocalBoundProvider( MeshFilter filter)
        {
            this.filter = filter;
        }
        
        public Bounds Bounds
        {
            get
            {
                if (!filter) return new Bounds();
                
                var mesh = filter.mesh;
                return mesh != null ? mesh.bounds : new Bounds();
            }
        }
    }
}