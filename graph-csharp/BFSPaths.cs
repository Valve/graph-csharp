using System.Collections.Generic;

namespace graph_csharp {
    public class BFSPaths {
        private bool[] _marked;
        private int[] _edgeTo;
        private readonly int _s;

        public BFSPaths(Graph g, int s) {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _s = s;
            bfs(g, s);
        }

        private void bfs(Graph g, int s) {
            var queue = new Queue<int>();
            _marked[s] = true;
            queue.Enqueue(s);
            while(queue.Count>0) {
                int v = queue.Dequeue();
                foreach(int w in g.Adjacent(v)) {
                    if(!_marked[w]) {
                        _edgeTo[w] = v;
                        _marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public bool HasPathTo(int v) {
            return _marked[v];
        }

        public IEnumerable<int> PathTo(int v) {
            if (!HasPathTo(v)) return null;
            var path = new Stack<int>();
            for (int x = v; x != _s; x = _edgeTo[x]) {
                path.Push(x);

            }
            path.Push(_s);
            return path;
        }
    }
}
