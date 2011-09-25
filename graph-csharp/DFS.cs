

namespace graph_csharp {
    public class DFS {
        private readonly bool[] _marked;
        private int _count;
        public DFS(Graph g, int s) {
            _marked = new bool[g.V];
            dfs(g, s);
        }
        private void dfs(Graph g, int v) {
            _marked[v] = true;
            _count++;
            foreach (var adj in g.Adjacent(v)) {
                if (!_marked[adj]) dfs(g, adj);
            }
        }

        public bool Marked(int w) {
            return _marked[w];
        }

        public int Count {
            get { return _count; }
        }
    }
}
