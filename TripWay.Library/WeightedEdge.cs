namespace TripWay.Library
{
    public class WeightedEdge
    {
        private Vertex from;
        private Vertex to;
        private int weight;

        public WeightedEdge(Vertex from, Vertex to, int weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{this.from.ToString()} < {this.weight.ToString()} > {this.to.ToString()}";
        }

        public static bool operator <(WeightedEdge lhs, WeightedEdge rhs)
        {
            return lhs.weight < rhs.weight;
        }
        
        public static bool operator >(WeightedEdge lhs, WeightedEdge rhs)
        {
            return lhs.weight > rhs.weight;
        }

        public WeightedEdge Reversed()
        {
            return new WeightedEdge(to, from, weight);
        }

        public override bool Equals(object obj)
        {
            var convertedObj = obj as WeightedEdge;
            if (convertedObj != null)
                return this.from == convertedObj.from &&
                       this.to == convertedObj.to && this.weight == convertedObj.weight;
            
            return false;
        }
    }
}